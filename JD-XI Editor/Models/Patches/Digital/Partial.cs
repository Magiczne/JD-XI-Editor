using System.Collections.Generic;
using Caliburn.Micro;

// ReSharper disable InvertIf

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

        #region Fields

        /// <summary>
        ///     Oscillator
        /// </summary>
        private Oscillator _oscillator;

        /// <summary>
        ///     Filter
        /// </summary>
        private Filter _filter;

        /// <summary>
        ///     Amplifier
        /// </summary>
        private Amplifier _amplifier;

        /// <summary>
        ///     LFO
        /// </summary>
        private Lfo _lfo;

        /// <summary>
        ///     Mod LFO
        /// </summary>
        private ModLfo _modLfo;

        /// <summary>
        ///     Aftertouch
        /// </summary>
        private Aftertouch _aftertouch;

        /// <summary>
        ///     Misc data
        /// </summary>
        private Other _other;

        #endregion

        #region Properties

        /// <summary>
        ///     Oscillator
        /// </summary>
        public Oscillator Oscillator
        {
            get => _oscillator;
            set
            {
                if (value != _oscillator)
                {
                    _oscillator = value;
                    NotifyOfPropertyChange(nameof(Oscillator));
                }
            }
        }

        /// <summary>
        ///     Filter
        /// </summary>
        public Filter Filter
        {
            get => _filter;
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    NotifyOfPropertyChange(nameof(Filter));
                }
            }
        }

        /// <summary>
        ///     Amplifier
        /// </summary>
        public Amplifier Amplifier
        {
            get => _amplifier;
            set
            {
                if (value != _amplifier)
                {
                    _amplifier = value;
                    NotifyOfPropertyChange(nameof(Amplifier));
                }
            }
        }

        /// <summary>
        ///     LFO
        /// </summary>
        public Lfo Lfo
        {
            get => _lfo;
            set
            {
                if (value != _lfo)
                {
                    _lfo = value;
                    NotifyOfPropertyChange(nameof(Lfo));
                }
            }
        }

        /// <summary>
        ///     Mod LFO
        /// </summary>
        public ModLfo ModLfo
        {
            get => _modLfo;
            set
            {
                if (value != _modLfo)
                {
                    _modLfo = value;
                    NotifyOfPropertyChange(nameof(ModLfo));
                }
            }
        }

        /// <summary>
        ///     Aftertouch
        /// </summary>
        public Aftertouch Aftertouch
        {
            get => _aftertouch;
            set
            {
                if (value != _aftertouch)
                {
                    _aftertouch = value;
                    NotifyOfPropertyChange(nameof(Aftertouch));
                }
            }
        }

        /// <summary>
        ///     Misc data
        /// </summary>
        public Other Other
        {
            get => _other;
            set
            {
                if (value != _other)
                {
                    _other = value;
                    NotifyOfPropertyChange(nameof(Other));
                }
            }
        }

        #endregion
    }
}