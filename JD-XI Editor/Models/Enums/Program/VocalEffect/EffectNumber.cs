using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums.Program.VocalEffect
{
    internal enum EffectNumber : byte
    {
        [Description("1. Vocoder: Ensemble")] VocoderEnsemble = 0x0,
        [Description("2. Vocoder: 5th Stack")] Vocoder5ThStack = 0x1,
        [Description("3. Vocoder: Robot")] VocoderRobot,
        [Description("4. Vocoder: Sawtooth")] VocoderSaw,
        [Description("5. Vocoder: Squarr")] VocoderSquare,
        [Description("6. Vocoder: Rise Up")] VocoderRiseUp,
        [Description("7. Vocoder: Auto Vibrato")] VocoderAutoVibrato,
        [Description("8. Vocoder: Pitch Envelope")] VocoderPitchEnvelope,
        [Description("9. Vocoder: VP-330")] VocoderVp330,
        [Description("10. Vocoder: Noise")] VocoderNoise,
        [Description("11. Auto Pitch: Electric Pitch 1")] AutoPitchElectricPitch1,
        [Description("12. Auto Pitch: Electric Pitch 2")] AutoPitchElectricPitch2,
        [Description("13. Auto Pitch: Hard Pitch")] AutoPitchHardPitch,
        [Description("14. Auto Pitch: Soft Pitch")] AutoPitchSoftPitch,
        [Description("15. Auto Pitch: Formant +")] AutoPitchFormantUp,
        [Description("16. Auto Pitch: Formant -")] AutoPitchFormantDown,
        [Description("17. Auto Pitch: Octave +")] AutoPitchOctaveUp,
        [Description("18. Auto Pitch: Octave -")] AutoPitchOctaveDown,
        [Description("19. Auto Pitch: To Soprano")] AutoPitchToSoprano,
        [Description("20. Auto Pitch: To Bass")] AutoPitchToBass,
        [Description("20. Voice In")] VoiceIn
    }
}