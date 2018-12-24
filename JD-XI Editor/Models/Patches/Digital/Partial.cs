using System.Collections.Generic;
using Caliburn.Micro;
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