using System;
using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Utils.Enums;
using PropertyChanged;

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

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();

            foreach (var partial in Partials)
            {
                partial.Value.Reset();
            }
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (patch is Patch p)
            {
                Common.CopyFrom(p.Common);

                foreach (var partial in Partials)
                {
                    partial.Value.CopyFrom(p.Partials[partial.Key]);
                }
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        /// <summary>
        ///     Init partials with basic data
        /// </summary>
        private void InitPartials()
        {
            foreach (var key in EnumHelper.GetAllValuesAndDescriptions(typeof(DrumKey)))
            {
                var partial = new Partial.Partial((DrumKey) key.Value);
                partial.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Partials));
                Partials.Add(key.Description, partial);
            }
        }

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; }

        /// <summary>
        ///     Partials
        /// </summary>
        [DoNotNotify]
        public Dictionary<string, Partial.Partial> Partials { get; }

        #endregion
    }
}