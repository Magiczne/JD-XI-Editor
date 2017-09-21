using Caliburn.Micro;

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

        #region Fields

        /// <summary>
        ///     Common
        /// </summary>
        private Common _common;

        /// <summary>
        ///     Partial #1
        /// </summary>
        private Partial _partialOne;

        /// <summary>
        ///     Partial #2
        /// </summary>
        private Partial _partialTwo;

        /// <summary>
        ///     Partial #3
        /// </summary>
        private Partial _partialThree;

        /// <summary>
        ///     Modifiers
        /// </summary>
        private Modifiers _modifiers;

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
                    NotifyOfPropertyChange(nameof(Common));
                }
            }
        }

        /// <summary>
        ///     Partial #1
        /// </summary>
        public Partial PartialOne
        {
            get => _partialOne;
            set
            {
                if (value != _partialOne)
                {
                    _partialOne = value;
                    NotifyOfPropertyChange(nameof(PartialOne));
                }
            }
        }

        /// <summary>
        ///     Partial #2
        /// </summary>
        public Partial PartialTwo
        {
            get => _partialTwo;
            set
            {
                if (value != _partialTwo)
                {
                    _partialTwo = value;
                    NotifyOfPropertyChange(nameof(PartialTwo));
                }
            }
        }

        /// <summary>
        ///     Partial #3
        /// </summary>
        public Partial PartialThree
        {
            get => _partialThree;
            set
            {
                if (value != _partialThree)
                {
                    _partialThree = value;
                    NotifyOfPropertyChange(nameof(PartialThree));
                }
            }
        }

        /// <summary>
        ///     Modifiers
        /// </summary>
        public Modifiers Modifiers
        {
            get => _modifiers;
            set
            {
                if (value != _modifiers)
                {
                    _modifiers = value;
                    NotifyOfPropertyChange(nameof(Modifiers));
                }
            }
        }

        #endregion
    }
}