using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Analog
{
    internal class AnalogPatch : PropertyChangedBase
    {
        #region Fields

        /// <summary>
        ///     Patch name
        /// </summary>
        private string _name;

        /// <summary>
        ///     Common
        /// </summary>
        private AnalogCommon _common;

        /// <summary>
        ///     Oscillator
        /// </summary>
        private AnalogOscillator _oscillator;

        /// <summary>
        ///     LFO
        /// </summary>
        private AnalogLfo _lfo;

        /// <summary>
        ///     Filter (Low Pass)
        /// </summary>
        private AnalogFilter _filter;

        /// <summary>
        ///     Amplifier
        /// </summary>
        private AnalogAmplifier _amplifier;

        #endregion

        #region Properies
        
        /// <summary>
        ///     Patch name
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(nameof(Name));
                }
            }
        }

        /// <summary>
        ///     Common
        /// </summary>
        public AnalogCommon Common
        {
            get => _common;
            set
            {
                if (value != _common)
                {
                    _common = value;
                    NotifyOfPropertyChange(nameof(Common));
                }
            }
        }

        /// <summary>
        ///     Oscillator
        /// </summary>
        public AnalogOscillator Oscillator
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
        ///     LFO
        /// </summary>
        public AnalogLfo Lfo
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
        ///     Filter (Low Pass)
        /// </summary>
        public AnalogFilter Filter
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
        public AnalogAmplifier Amplifier
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

        #endregion

        /// <summary>
        /// Creates new instance of AnalogPatch
        /// </summary>
        public AnalogPatch()
        {
            Name = "Init Tone";
            Common = new AnalogCommon();
            Oscillator = new AnalogOscillator();
            Lfo = new AnalogLfo();
            Filter = new AnalogFilter();
            Amplifier = new AnalogAmplifier();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            Oscillator.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Oscillator));
            Lfo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Lfo));
            Filter.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Filter));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
        }

        /// <summary>
        /// Reset data to initial patch
        /// </summary>
        public void Reset()
        {
            Name = "Init Tone";
            Common.Reset();
            Oscillator.Reset();
            Lfo.Reset();
            Filter.Reset();
            Amplifier.Reset();
        }

        /// <summary>
        /// Get patch byte data
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(Enumerable.Repeat<byte>(0x20, 12 - nameBytes.Length));
            bytes.Add(0x00);    //Reserve

            bytes.AddRange(Lfo.GetLfoSectionBytes());

            bytes.AddRange(Oscillator.GetBytes());

            bytes.AddRange(Filter.GetBytes());

            bytes.AddRange(Amplifier.GetBytes());

            bytes.AddRange(Common.GetBytes());
            bytes.Add(0x00);    //Reserve

            bytes.AddRange(Lfo.GetLfoModSectionBytes());
            bytes.AddRange(Enumerable.Repeat<byte>(0x00, 4));   //Reserve

            return bytes.ToArray();
        }
    }
}