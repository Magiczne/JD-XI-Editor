using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Logging;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Models.Patches.Program.Effects;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;
using Timer = System.Timers.Timer;

namespace JD_XI_Editor.Managers
{
    internal class EffectsPatchManager : IEffectsPatchManager
    {
        #region Fields

        /// <summary>
        ///     Timer used to determine timeouts when reading data from device
        /// </summary>
        private readonly Timer _timer = new Timer(4000);

        /// <summary>
        ///     Device instance
        /// </summary>
        private InputDevice _device;

        /// <summary>
        ///     Count of dump messages received
        /// </summary>
        private int _dumpCount;

        /// <summary>
        ///     SysEx dumps from device
        /// </summary>
        private readonly Dictionary<Effect, SysExMessage> _dataDumps = new Dictionary<Effect, SysExMessage>();

        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger _logger;

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Methods

        public EffectsPatchManager()
        {
            _logger = LoggerFactory.FullSet(typeof(EffectsPatchManager));
            _timer.Elapsed += OnTimerElapsed;
        }

        /// <summary>
        ///     Offset for specified effect
        /// </summary>
        private static byte[] EffectOffset(Effect effect) => new byte[] {0x18, 0x00, (byte) effect, 0x00};

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private byte[] EffectDumpRequest(Effect effect)
        {
            switch (effect)
            {
                case Effect.Effect1:
                case Effect.Effect2:
                    return new byte[] {0x00, 0x00, 0x01, 0x11};

                case Effect.Delay:
                    return new byte[] {0x00, 0x00, 0x00, 0x64};

                case Effect.Reverb:
                    return new byte[] {0x00, 0x00, 0x00, 0x63};

                default:
                    throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
            }
        }

        /// <summary>
        ///     Expected dump length
        /// </summary>
        private int ExpectedDumpLength(Effect effect)
        {
            switch (effect)
            {
                case Effect.Effect1:
                case Effect.Effect2:
                    return 145;

                case Effect.Delay:
                    return 100;

                case Effect.Reverb:
                    return 99;

                default:
                    throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
            }
        }

        #endregion

        #region Callbacks

        /// <summary>
        ///     Callback called when data dump is received from device
        /// </summary>
        private void OnSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            // At 11 byte we have effect type, so we check value there
            var effect = (Effect) e.Message[10];

            var expectedDumpLength = ExpectedDumpLength(effect) + SysExUtils.DumpPaddingSize;
            var actualDumpLength = e.Message.Length;
            if (actualDumpLength != expectedDumpLength)
            {
                throw new InvalidDumpSizeException(expectedDumpLength, actualDumpLength);
            }

            _logger.Receive($"Received {effect}");


            _dataDumps.Add(effect, e.Message);

            _dumpCount++;

            if (_dumpCount == 4)
            {
                _timer.Stop();

                _device.StopRecording();
                _device.Dispose();

                DataDumpReceived?.Invoke(this, new EffectsPatchDumpReceivedEventArgs(new Patch(_dataDumps)));
            }
        }

        /// <summary>
        ///     Callback called when timer waiting for data dump from device elapses
        /// </summary>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            if (!_device.IsDisposed)
            {
                _device.StopRecording();
                _device.Dispose();
            }

            OperationTimedOut?.Invoke(this, new TimeoutException("Read data operation timed out"));
        }

        #endregion

        #region IPatchManager

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var effectPatch = (Patch)patch;

            using (var output = new OutputDevice(deviceId))
            {
                _logger.DataDump("Dumping Effect 1");
                output.Send(SysExUtils.GetMessage(EffectOffset(Effect.Effect1), effectPatch.Effect1.GetBytes()));

                _logger.DataDump("Dumping Effect 2");
                output.Send(SysExUtils.GetMessage(EffectOffset(Effect.Effect2), effectPatch.Effect2.GetBytes()));

                _logger.DataDump("Dumping Delay");
                output.Send(SysExUtils.GetMessage(EffectOffset(Effect.Delay), effectPatch.Delay.GetBytes()));

                _logger.DataDump("Dumping Reverb");
                output.Send(SysExUtils.GetMessage(EffectOffset(Effect.Reverb), effectPatch.Reverb.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            // Reset dump count counter and dumps container
            _dumpCount = 0;
            _dataDumps.Clear();

            // Initialize input device
            _device = new InputDevice(inputDeviceId);

            // Setup event handler for receiving SysEx messages
            _device.SysExMessageReceived += OnSysExMessageReceived;

            // Start recording input from device
            _device.StartRecording();

            // Start timer before running task, so we have timer on the same thread
            // as the callbacks for timer and input device
            _timer.Start();

            // Request data dump from device on separate thread
            Task.Run(() =>
            {
                // Need to make 50ms delay between requests to ensure
                // that device will not hung up

                using (var output = new OutputDevice(outputDeviceId))
                {
                    _logger.Send("Request Effect 1");
                    output.Send(SysExUtils.GetRequestDumpMessage(EffectOffset(Effect.Effect1), EffectDumpRequest(Effect.Effect1)));
                    Thread.Sleep(50);

                    _logger.Send("Request Effect 2");
                    output.Send(SysExUtils.GetRequestDumpMessage(EffectOffset(Effect.Effect2), EffectDumpRequest(Effect.Effect2)));
                    Thread.Sleep(50);

                    _logger.Send("Request Delay");
                    output.Send(SysExUtils.GetRequestDumpMessage(EffectOffset(Effect.Delay), EffectDumpRequest(Effect.Delay)));
                    Thread.Sleep(50);

                    _logger.Send("Request Reverb");
                    output.Send(SysExUtils.GetRequestDumpMessage(EffectOffset(Effect.Reverb), EffectDumpRequest(Effect.Reverb)));
                    Thread.Sleep(50);
                }
            });
        }

        #endregion

        #region IEffectsPatchManager

        /// <inheritdoc />
        public void DumpEffect(EffectPatch patch, Effect effect, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                _logger.DataDump($"Dumping {effect}");
                output.Send(SysExUtils.GetMessage(EffectOffset(effect), patch.GetBytes()));
            }
        }

        #endregion
    }
}