using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Delay Patch
        /// </summary>
        public Patch()
        {
            Basic = new BasicData();
            Parameters = new Parameters();

            Basic.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Basic));
            Parameters.PropertyChanged += (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Parameters.Reset();
        }

        #region Fields

        /// <summary>
        ///     Basic effect patch data
        /// </summary>
        private BasicData _basic;

        /// <summary>
        ///     Delay parameters
        /// </summary>
        private Parameters _parameters;

        #endregion

        #region Properties

        /// <summary>
        ///     Basic Data
        /// </summary>
        public BasicData Basic
        {
            get => _basic;
            set
            {
                if (value != _basic)
                {
                    _basic = value;
                    NotifyOfPropertyChange(nameof(Basic));
                }
            }
        }

        /// <summary>
        ///     Delay parameters
        /// </summary>
        public Parameters Parameters
        {
            get => _parameters;
            set
            {
                if (value != _parameters)
                {
                    _parameters = value;
                    NotifyOfPropertyChange(nameof(Parameters));
                }
            }
        }

        #endregion
    }
}