using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Utils;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        #region Fields

        /// <summary>
        ///     Patch name
        /// </summary>
        private string _name;

        #endregion

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
            if (!(patch is Patch))
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }

            var castPatch = (Patch) patch;

            Name = castPatch.Name;
            //TODO: Copy all patch parts
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

        #region Properies

        /// <summary>
        ///     Patch name
        /// </summary>
        /// TODO(magiczne): Take use of Fody.PropertyChanged
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