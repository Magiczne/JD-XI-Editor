using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Utils;
using PropertyChanged;

// ReSharper disable SwitchStatementMissingSomeCases

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class Patch : EffectPatch<BasicData, EffectParameters>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Effect 1 Patch
        /// </summary>
        public Patch()
        {
            var thruEffectParameters = new ThruEffectParameters();
            FlangerParameters = new FlangerParameters();
            PhaserParameters = new PhaserParameters();
            RingModulationParameters = new RingModulationParameters();
            SlicerParameters = new SlicerParameters();

            Basic = new BasicData();
            Parameters = new ThruEffectParameters();

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (Basic.Type)
                    {
                        case Effect2Type.Thru:
                            Parameters = thruEffectParameters;
                            break;
                        case Effect2Type.Flanger:
                            Parameters = FlangerParameters;
                            break;
                        case Effect2Type.Phaser:
                            Parameters = PhaserParameters;
                            break;
                        case Effect2Type.RingMod:
                            Parameters = RingModulationParameters;
                            break;
                        case Effect2Type.Slicer:
                            Parameters = SlicerParameters;
                            break;
                        default:
                            Parameters = new ThruEffectParameters();
                            break;
                    }

                    Parameters.PropertyChanged +=
                        (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
                }

                NotifyOfPropertyChange(nameof(Basic));
            };
        }

        /// <inheritdoc />
        public override void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Basic.CopyFrom(data.Take(5).ToArray());

            // Basic.PropertyChanges takes care of switching between parameters, so we don't
            // need to do anything more than that and we're just passing data to the method
            // that copies data from sysex dump
            Parameters.CopyFrom(data.Skip(17).Take(128).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Basic.GetBytes());
            bytes.AddRange(ByteUtils.RepeatReserve(12));
            bytes.AddRange(Parameters.GetBytes());

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 145;

        /// <summary>
        ///     Flanger parameters
        /// </summary>
        [DoNotNotify]
        public FlangerParameters FlangerParameters { get; set; }

        /// <summary>
        ///     Phaser parameters
        /// </summary>
        [DoNotNotify]
        public PhaserParameters PhaserParameters { get; set; }

        /// <summary>
        ///     Ring Modulation parameters
        /// </summary>
        [DoNotNotify]
        public RingModulationParameters RingModulationParameters { get; set; }

        /// <summary>
        ///     Slicer paremeters
        /// </summary>
        [DoNotNotify]
        public SlicerParameters SlicerParameters { get; set; }

        #endregion
    }
}