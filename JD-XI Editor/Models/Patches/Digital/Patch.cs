using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Patch
        /// </summary>
        public Patch()
        {
            Common = new Common();
            PartialOne = new Partial();
            PartialTwo = new Partial();
            PartialThree = new Partial();
            Modifiers = new Modifiers();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            PartialOne.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialOne));
            PartialTwo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialTwo));
            PartialThree.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(PartialThree));
            Modifiers.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Modifiers));
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
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        #region Properties

        /// <summary>
        ///     Common
        /// </summary>
        [DoNotNotify]
        public Common Common { get; }

        /// <summary>
        ///     Partial #1
        /// </summary>
        [DoNotNotify]
        public Partial PartialOne { get; }

        /// <summary>
        ///     Partial #2
        /// </summary>
        [DoNotNotify]
        public Partial PartialTwo { get; }

        /// <summary>
        ///     Partial #3
        /// </summary>
        [DoNotNotify]
        public Partial PartialThree { get; }

        /// <summary>
        ///     Modifiers
        /// </summary>
        [DoNotNotify]
        public Modifiers Modifiers { get; }

        #endregion
    }
}