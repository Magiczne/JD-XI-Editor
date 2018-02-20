using Caliburn.Micro;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of effects patch
        /// </summary>
        public Patch()
        {
            Effect1 = new Effect1.Patch();
            Effect2 = new Effect2.Patch();
            Delay = new Delay.Patch();
            Reverb = new Reverb.Patch();

            Effect1.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Effect1));
            Effect2.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Effect2));
            Delay.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Delay));
            Reverb.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Reverb));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Effect1.Reset();
            Effect2.Reset();
            Delay.Reset();
            Reverb.Reset();
        }

        #region Fields

        /// <summary>
        ///     Effect 1
        /// </summary>
        private Effect1.Patch _effect1;

        /// <summary>
        ///     Effect 2
        /// </summary>
        private Effect2.Patch _effect2;

        /// <summary>
        ///     Delay patch
        /// </summary>
        private Delay.Patch _delay;
        
        /// <summary>
        ///     Reverb patch
        /// </summary>
        private Reverb.Patch _reverb;

        #endregion

        #region Properties

        /// <summary>
        ///     Effect 1
        /// </summary>
        public Effect1.Patch Effect1
        {
            get => _effect1;
            set
            {
                if (value != _effect1)
                {
                    _effect1 = value;
                    NotifyOfPropertyChange(nameof(Effect1));
                }
            }
        }

        /// <summary>
        ///     Effect 2
        /// </summary>
        public Effect2.Patch Effect2
        {
            get => _effect2;
            set
            {
                if (value != _effect2)
                {
                    _effect2 = value;
                    NotifyOfPropertyChange(nameof(Effect2));
                }
            }
        }

        /// <summary>
        ///     Delay patch
        /// </summary>
        public Delay.Patch Delay
        {
            get => _delay;
            set
            {
                if (value != _delay)
                {
                    _delay = value;
                    NotifyOfPropertyChange(nameof(Delay));
                }
            }
        }

        /// <summary>
        ///     Reverb patch
        /// </summary>
        public Reverb.Patch Reverb
        {
            get => _reverb;
            set
            {
                if (value != _reverb)
                {
                    _reverb = value;
                    NotifyOfPropertyChange(nameof(Reverb));
                }
            }
        }

        #endregion
    }
}