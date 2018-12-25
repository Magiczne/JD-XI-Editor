using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Analog;
using JD_XI_Editor.Models.Enums.Common;
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
        ///     Get patch byte data
        /// </summary>
        /// <returns></returns>
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

            bytes.AddRange(ByteUtils.RepeatReserve(4));

            return bytes.ToArray();
        }

        /// <summary>
        ///     Get patch object from sysex dump
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Patch FromSysEx(SysExMessage message)
        {
            // Bytes order:
            // 64   -> Data length (Excluding header, address offset, checksum and footer)
            //
            // 12   -> SysEx header & address offset
            // 13   -> Tone Name(12) + Reserve(1)
            // 9    -> LFO
            // 10   -> Oscillator
            // 10   -> Filter
            // 7    -> Amplifier
            // 7    -> Common(6) + Reserve(1)
            // 8    -> LFO Mod Control(4) + Reserve(4)
            // 1    -> Checksum
            // 1    -> Footer (0xF7)

            var bytes = message.GetBytes().Skip(12).Take(64).ToArray();

            var lfo = bytes.Skip(13).Take(9).ToArray();
            var osc = bytes.Skip(13 + 9).Take(10).ToArray();
            var flt = bytes.Skip(13 + 9 + 10).Take(10).ToArray();
            var amp = bytes.Skip(13 + 9 + 10 + 10).Take(7).ToArray();
            var com = bytes.Skip(13 + 9 + 10 + 10 + 7).Take(7).ToArray();
            var mod = bytes.Skip(13 + 9 + 10 + 10 + 7 + 7).Take(8).ToArray();

            var patch = new Patch
            {
                Name = Encoding.ASCII.GetString(bytes.Take(12).ToArray()),
                Lfo =
                {
                    Shape = (LfoShape) lfo[0],
                    Rate = lfo[1],
                    FadeTime = lfo[2],
                    TempoSync = ByteUtils.ByteToBoolean(lfo[3]),
                    SyncNote = (SyncNote) lfo[4],
                    PitchDepth = lfo[5] - 64,
                    FilterDepth = lfo[6] - 64,
                    AmpDepth = lfo[7] - 64,
                    KeyTrigger = ByteUtils.ByteToBoolean(lfo[8])
                },
                Oscillator =
                {
                    Shape = (OscillatorShape) osc[0],
                    Pitch = osc[1] - 64,
                    Detune = osc[2] - 64,
                    PulseWidth = osc[3],
                    PulseWidthModDepth = osc[4],
                    EnvelopeVelocitySensitivity = osc[5] - 64,
                    Attack = osc[6],
                    Decay = osc[7],
                    EnvelopeDepth = osc[8] - 64,
                    SubOsc = (SubOscillatorStatus) osc[9]
                },
                Filter =
                {
                    On = ByteUtils.ByteToBoolean(flt[0]),
                    Cutoff = flt[1],
                    CutoffKeyfollow = (flt[2] - 64) * 10,
                    Resonance = flt[3],
                    EnvelopeVelocitySensitivity = flt[4] - 64,
                    Envelope =
                    {
                        Attack = flt[5],
                        Decay = flt[6],
                        Sustain = flt[7],
                        Release = flt[8],
                    },
                    EnvelopeDepth = flt[9] - 64
                },
                Amplifier =
                {
                    Level = amp[0],
                    LevelKeyfollow = (amp[1] - 64) * 10,
                    LevelVelSensitivity = amp[2] - 64,
                    Envelope =
                    {
                        Attack = amp[3],
                        Decay = amp[4],
                        Sustain = amp[5],
                        Release = amp[6]
                    }
                },
                Common =
                {
                    Portamento = ByteUtils.ByteToBoolean(com[0]),
                    PortamentoTime = com[1],
                    Legato = ByteUtils.ByteToBoolean(com[2]),
                    OctaveShift = com[3] - 64,
                    PitchBendRangeUp = com[4],
                    PitchBendRangeDown = com[5]
                },
                LfoModControl =
                {
                    PitchModControl = mod[0] - 64,
                    FilterModControl = mod[1] - 64,
                    AmpModControl = mod[2] - 64,
                    RateModControl = mod[3] - 64
                }
            };

            return patch;
        }

        #region Properies

        /// <summary>
        ///     Patch name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     LFO
        /// </summary>
        [DoNotNotify]
        public Lfo Lfo { get; }

        /// <summary>
        ///     Oscillator
        /// </summary>
        [DoNotNotify]
        public Oscillator Oscillator { get; }

        /// <summary>
        ///     Filter (Low Pass)
        /// </summary>
        [DoNotNotify]
        public Filter Filter { get; }

        /// <summary>
        ///     Amplifier
        /// </summary>
        [DoNotNotify]
        public Amplifier Amplifier { get; }

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; }

        /// <summary>
        ///     Lfo Mod Control
        /// </summary>
        [DoNotNotify]
        public LfoModControl LfoModControl { get; }

        #endregion
    }
}