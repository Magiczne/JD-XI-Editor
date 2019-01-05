using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Utils.Enums;
using PropertyChanged;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models.Patches.DrumKit
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Patch()
        {
            Common = new Common();
            Partials = new Dictionary<DrumKey, Partial.Partial>();
            InitPartials();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch using sysex dumps
        /// </summary>
        public Patch(SysExMessage common, Dictionary<DrumKey, SysExMessage> partials) : this()
        {
            CopyFrom(common, partials);
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

        /// <summary>
        ///     Copy data from sysex dumps
        /// </summary>
        /// <param name="common"></param>
        /// <param name="partials"></param>
        public void CopyFrom(SysExMessage common, Dictionary<DrumKey, SysExMessage> partials)
        {
            // Skipping 12 bytes from front because it's header and address offset
            // Skipping 2 bytes from end because it's checksum and sysex footer

            var commonBytes = common.GetBytes().Skip(12).ToArray();
            Common.CopyFrom(commonBytes.Take(commonBytes.Length - 2).ToArray());

            foreach (var partial in partials)
            {
                var key = partial.Key;
                var bytes = partial.Value.GetBytes().Skip(12).ToArray();

                Partials[key].CopyFrom(bytes.Take(bytes.Length - 2).ToArray());
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
                Partials.Add((DrumKey) key.Value, partial);
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
        public Dictionary<DrumKey, Partial.Partial> Partials { get; }

        #endregion
    }
}