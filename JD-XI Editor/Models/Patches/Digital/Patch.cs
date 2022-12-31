using System;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        private readonly Partial[] _partials;

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch
        /// </summary>
        public Patch()
        {
            _partials = new[] { new Partial(), new Partial(), new Partial() };

            Common = new Common();
            Modifiers = new Modifiers();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            PartialOne.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialOne));
            PartialTwo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialTwo));
            PartialThree.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialThree));
            Modifiers.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Modifiers));
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch using sysex dumps
        /// </summary>
        public Patch(SysExMessage common, SysExMessage[] partials, SysExMessage modifiers) : this()
        {
            CopyFrom(common, partials, modifiers);
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();
            PartialOne.Reset();
            PartialTwo.Reset();
            PartialThree.Reset();
            Modifiers.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (patch is Patch p)
            {
                Common.CopyFrom(p.Common);
                PartialOne.CopyFrom(p.PartialOne);
                PartialTwo.CopyFrom(p.PartialTwo);
                PartialThree.CopyFrom(p.PartialThree);
                Modifiers.CopyFrom(p.Modifiers);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <summary>
        ///     Copy data from sysex dumps
        /// </summary>
        /// <param name="common">Common sysex message</param>
        /// <param name="partials">SysEx messages </param>
        /// <param name="modifiers"></param>
        public void CopyFrom(SysExMessage common, SysExMessage[] partials, SysExMessage modifiers)
        {
            // Skipping 12 bytes from front because it's header and address offset
            // Skipping 2 bytes from end because it's checksum and sysex footer

            var commonBytes = common.GetBytes().Skip(12).ToArray();
            var partialsBytes = partials.Select(partial => partial.GetBytes().Skip(12).ToArray()).ToArray();
            var modifiersBytes = modifiers.GetBytes().Skip(12).ToArray();

            Common.CopyFrom(commonBytes.Take(commonBytes.Length - 2).ToArray());

            for (var i = 0; i < _partials.Length; i++)
            {
                _partials[i].CopyFrom(partialsBytes[i].Take(partialsBytes[i].Length - 2).ToArray());
            }

            Modifiers.CopyFrom(modifiersBytes.Take(modifiersBytes.Length - 2).ToArray());
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; set; }

        /// <summary>
        ///     Partial #1
        /// </summary>
        [DoNotNotify]
        public Partial PartialOne
        {
            get => _partials[0];
            set => _partials[0] = value;
        }

        /// <summary>
        ///     Partial #2
        /// </summary>
        [DoNotNotify]
        public Partial PartialTwo
        {
            get => _partials[1];
            set => _partials[1] = value;
        }

        /// <summary>
        ///     Partial #3
        /// </summary>
        [DoNotNotify]
        public Partial PartialThree
        {
            get => _partials[2];
            set => _partials[2] = value;
        }

        /// <summary>
        ///     Modifiers
        /// </summary>
        [DoNotNotify]
        public Modifiers Modifiers { get; set; }

        #endregion
    }
}