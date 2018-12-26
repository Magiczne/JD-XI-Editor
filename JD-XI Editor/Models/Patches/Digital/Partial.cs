using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Partial : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of partial
        /// </summary>
        public Partial()
        {
            Oscillator = new Oscillator();
            Filter = new Filter();
            Amplifier = new Amplifier();
            Lfo = new Lfo();
            ModLfo = new ModLfo();
            Aftertouch = new Aftertouch();
            Other = new Other();

            Oscillator.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Oscillator));
            Filter.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Filter));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
            Lfo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Lfo));
            ModLfo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(ModLfo));
            Aftertouch.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Aftertouch));
            Other.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Other));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Oscillator.Reset();
            Filter.Reset();
            Amplifier.Reset();
            Lfo.Reset();
            ModLfo.Reset();
            Aftertouch.Reset();
            Other.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Partial partial)
            {
                Oscillator.CopyFrom(partial.Oscillator);
                Filter.CopyFrom(partial.Filter);
                Amplifier.CopyFrom(partial.Amplifier);
                Lfo.CopyFrom(partial.Lfo);
                ModLfo.CopyFrom(partial.ModLfo);
                Aftertouch.CopyFrom(partial.Aftertouch);
                Other.CopyFrom(partial.Other);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            /**
             * 10   -> Oscillator
             * 11   -> Filter
             * 7    -> Amplifier
             * 10   -> LFO
             * 10   -> Mod LFO
             * 4    -> Aftertouch
             * 9    -> Other
             */

            Oscillator.CopyFrom(data.Take(10).ToArray());
            Filter.CopyFrom(data.Skip(10).Take(11).ToArray());
            Amplifier.CopyFrom(data.Skip(21).Take(7).ToArray());
            Lfo.CopyFrom(data.Skip(28).Take(10).ToArray());
            ModLfo.CopyFrom(data.Skip(38).Take(10).ToArray());
            Aftertouch.CopyFrom(data.Skip(48).Take(4).ToArray());
            Other.CopyFrom(data.Skip(52).Take(9).ToArray());
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Oscillator.GetBytes());
            bytes.AddRange(Filter.GetBytes());
            bytes.AddRange(Amplifier.GetBytes());
            bytes.AddRange(Lfo.GetBytes());
            bytes.AddRange(ModLfo.GetBytes());
            bytes.AddRange(Aftertouch.GetBytes());
            bytes.AddRange(Other.GetBytes());

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 61;

        /// <summary>
        ///     Oscillator
        /// </summary>
        [DoNotNotify]
        public Oscillator Oscillator { get; }

        /// <summary>
        ///     Filter
        /// </summary>
        [DoNotNotify]
        public Filter Filter { get; }

        /// <summary>
        ///     Amplifier
        /// </summary>
        [DoNotNotify]
        public Amplifier Amplifier { get; }

        /// <summary>
        ///     LFO
        /// </summary>
        [DoNotNotify]
        public Lfo Lfo { get; }

        /// <summary>
        ///     Mod LFO
        /// </summary>
        [DoNotNotify]
        public ModLfo ModLfo { get; }

        /// <summary>
        ///     Aftertouch
        /// </summary>
        [DoNotNotify]
        public Aftertouch Aftertouch { get; }

        /// <summary>
        ///     Misc data
        /// </summary>
        [DoNotNotify]
        public Other Other { get; }

        #endregion
    }
}