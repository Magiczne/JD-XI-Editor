using JD_XI_Editor.Models.Patches.Program.Abstract;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Reverb
{
    internal class Patch : EffectPatch
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
    }
}