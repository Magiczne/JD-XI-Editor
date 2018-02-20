using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Effects;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Effect 1 Patch
        /// </summary>
        public Patch()
        {
            Basic = new BasicData();
            Parameters = new ThruEffectParameters();

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (Basic.Type)
                    {
                        case EffectType.Thru:
                            Parameters = new ThruEffectParameters();
                            break;
                        case EffectType.Distortion:
                            Parameters = new DistortionParameters();
                            break;
                        case EffectType.Fuzz:
                            Parameters = new FuzzParameters();
                            break;
                        case EffectType.Compressor:
                            Parameters = new CompressorParameters();
                            break;
                        case EffectType.BitCrusher:
                            Parameters = new BitCrusherParameters();
                            break;
                        default:
                            Parameters = new ThruEffectParameters();
                            break;
                    }

                    Parameters.PropertyChanged += (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
                }

                NotifyOfPropertyChange(nameof(Basic));
            };
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
        ///     Effect parameters
        /// </summary>
        private EffectParameters _parameters;

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
        ///     Effect parameters
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