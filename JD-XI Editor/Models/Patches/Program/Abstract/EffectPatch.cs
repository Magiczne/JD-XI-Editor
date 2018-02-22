using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Abstract
{
    internal abstract class EffectPatch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Parameters.Reset();
        }

        /// <inheritdoc />
        public abstract byte[] GetBytes();

        #region Fields

        /// <summary>
        ///     Basic effect patch data
        /// </summary>
        private IPatchPart _basic;

        /// <summary>
        ///     Delay parameters
        /// </summary>
        private EffectParameters _parameters;

        #endregion

        #region Properties

        /// <summary>
        ///     Basic Data
        /// </summary>
        public IPatchPart Basic
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
        public EffectParameters Parameters
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