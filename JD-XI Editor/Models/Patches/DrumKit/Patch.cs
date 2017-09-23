using System.Collections.Generic;
using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Patch()
        {
            Common = new Common();
            Partials = new Dictionary<string, Partial.Partial>();
            InitPartials();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();
            InitPartials();
        }

        /// <summary>
        ///     Init partials with basic data
        /// </summary>
        private void InitPartials()
        {
            Partials.Clear();

            var keys = new List<string>
            {
                "BD1", "RIM", "BD2", "CLAP", "BD3", "SD1", "CHH", "SD2", "PHH", "SD3", "OHH", "SD4",
                "TOM1", "PRC1", "TOM2", "PRC2", "TOM3", "PRC3", "CYM1", "PRC4", "CYM2", "PRC5", "CYM3", "HIT",
                "OTH1", "OTH2", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4", "A4", "A#4", "B4", "C5", "C#5"
            };

            foreach (var key in keys)
            {
                var partial = new Partial.Partial();
                partial.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Partials));
                Partials.Add(key, partial);
            }
        }

        #region Fields

        /// <summary>
        ///     Common
        /// </summary>
        private Common _common;

        /// <summary>
        ///     Partials
        /// </summary>
        private Dictionary<string, Partial.Partial> _partials;

        #endregion

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        public Common Common
        {
            get => _common;
            set
            {
                if (value != _common)
                {
                    _common = value;
                    _common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));

                    NotifyOfPropertyChange(nameof(Common));
                }
            }
        }

        /// <summary>
        ///     Partials
        /// </summary>
        public Dictionary<string, Partial.Partial> Partials
        {
            get => _partials;
            set
            {
                if (value != _partials)
                {
                    _partials = value;
                    NotifyOfPropertyChange(nameof(Partials));
                }
            }
        }

        #endregion
    }
}