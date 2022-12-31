using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;
using PropertyChanged;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AnalogPatch
        /// </summary>
        public Patch()
        {
            Name = "Init Tone";
            Lfo = new Lfo();
            Oscillator = new Oscillator();
            Filter = new Filter();
            Amplifier = new Amplifier();
            Common = new Common();
            LfoModControl = new LfoModControl();

            Lfo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Lfo));
            Oscillator.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Oscillator));
            Filter.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Filter));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            LfoModControl.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(LfoModControl));
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AnalogPatch using sysex dump
        /// </summary>
        public Patch(SysExMessage message) : this()
        {
            CopyFrom(message);
        }

        /// <inheritdoc />
        public void Reset()
        {
            Name = "Init Tone";
            Lfo.Reset();
            Oscillator.Reset();
            Filter.Reset();
            Amplifier.Reset();
            Common.Reset();
            LfoModControl.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (patch is Patch p)
            {
                Name = p.Name;
                Lfo.CopyFrom(p.Lfo);
                Oscillator.CopyFrom(p.Oscillator);
                Filter.CopyFrom(p.Filter);
                Amplifier.CopyFrom(p.Amplifier);
                Common.CopyFrom(p.Common);
                LfoModControl.CopyFrom(p.LfoModControl);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <summary>
        ///     Copy data from sysex dump
        /// </summary>
        public void CopyFrom(SysExMessage message)
        {
            /** 
             * 12   -> SysEx header & address offset
             * 13   -> Tone Name(12) + Reserve(1)
             * 9    -> LFO
             * 10   -> Oscillator
             * 10   -> Filter
             * 7    -> Amplifier
             * 7    -> Common(6) + Reserve(1)
             * 8    -> LFO Mod Control(4) + Reserve(4)
             * 1    -> Checksum
             * 1    -> Footer (0xF7)
             */

            var data = message.GetBytes().Skip(12).ToArray();

            if (data.Length - 2 != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Name = Encoding.ASCII.GetString(data.Take(12).ToArray());

            Lfo.CopyFrom(data.Skip(13).Take(9).ToArray());
            Oscillator.CopyFrom(data.Skip(22).Take(10).ToArray());
            Filter.CopyFrom(data.Skip(32).Take(10).ToArray());
            Amplifier.CopyFrom(data.Skip(42).Take(7).ToArray());
            Common.CopyFrom(data.Skip(49).Take(7).ToArray());
            LfoModControl.CopyFrom(data.Skip(56).Take(8).ToArray());
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name.Length > 12 ? Name.Substring(0, 12) : Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(ByteUtils.RepeatReserve(12 - nameBytes.Length, 0x20));

            bytes.Add(0x00);

            bytes.AddRange(Lfo.GetBytes());
            bytes.AddRange(Oscillator.GetBytes());
            bytes.AddRange(Filter.GetBytes());
            bytes.AddRange(Amplifier.GetBytes());
            bytes.AddRange(Common.GetBytes());
            bytes.AddRange(LfoModControl.GetBytes());

            return bytes.ToArray();
        }

        #region Properies

        /// <summary>
        ///     Expected Dump Length
        /// </summary>
        public int DumpLength { get; } = 64;

        /// <summary>
        ///     Patch name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     LFO
        /// </summary>
        [DoNotNotify]
        public Lfo Lfo { get; set; }

        /// <summary>
        ///     Oscillator
        /// </summary>
        [DoNotNotify]
        public Oscillator Oscillator { get; set; }

        /// <summary>
        ///     Filter (Low Pass)
        /// </summary>
        [DoNotNotify]
        public Filter Filter { get; set; }

        /// <summary>
        ///     Amplifier
        /// </summary>
        [DoNotNotify]
        public Amplifier Amplifier { get; set; }

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; set; }

        /// <summary>
        ///     Lfo Mod Control
        /// </summary>
        [DoNotNotify]
        public LfoModControl LfoModControl { get; set; }

        #endregion
    }
}