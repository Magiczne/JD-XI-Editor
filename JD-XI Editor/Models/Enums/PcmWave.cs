using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum PcmWave : int
    {
        [Description("000: Off")]
        Off = 0x00,

        [Description("001: Calculator Saw")]
        CalcSaw = 0x01,

        [Description("002: Distorded Sawtooth Wavetooth")]
        DistordedSaw,

        [Description("003: GR-300 Sawtooth")]
        Gr300Saw,

        [Description("004: Lead Wave 1")]
        LeadWave1,

        [Description("005: Lead Wave 2")]
        LeadWave2,

        [Description("006: Unison Sawtooth")]
        UnisonSaw,

        [Description("007: Sawtooth + Sub Wave")]
        SawtoothWithSub,

        [Description("008: Square Lead Wave")]
        SquareLeadWave1,

        [Description("009: Square Lead Wave+")]
        SquareLeadWave2,

        [Description("010: Feedback Wave")]
        FeedbackWave,

        [Description("011: Bad Axe")]
        BadAxe,

        [Description("012: Cutting Lead")]
        CuttingLead,

        [Description("013: Distorted TB Square")]
        DistordedTbSquare,

        [Description("014: Sync Sweep")]
        SyncSweep,

        [Description("015: Sawtooth Sync")]
        SawSync,

        [Description("016: Unison Sync")]
        UnisonSync,

        [Description("017: Sync Wave")]
        SyncWave,

        [Description("018: Cutters")]
        Cutters,

        [Description("019: Nasty")]
        Nasty,

        [Description("020: Bagpipe Wave")]
        BagpipeWave,

        [Description("021: Wave Scan")]
        WaveScan,

        [Description("022: Wire String")]
        WireString,

        [Description("023: Lead Wave 3")]
        LeadWave3,

        [Description("024: PWM Wave 1")]
        PwmWave1,

        [Description("025: PWM Wave 2")]
        PwmWave2,

        [Description("026: MIDI Clav")]
        MidiClav,

        [Description("027: Huge MIDI")]
        HugeMidi,

        [Description("028: Wobble Bass 1")]
        WobbleBass1,

        [Description("029: Wobble Bass 2")]
        WobbleBass2,

        [Description("030: Hollow Bass")]
        HollowBass,

        [Description("031: Synth Bass Wave")]
        SynBassWave,

        [Description("032: Solid Bass")]
        SolidBass,

        [Description("033: House Bass")]
        HouseBass,

        [Description("034: 4OP FM Bass")]
        OpFmBass,

        [Description("035: Fine Wine")]
        FineWine,

        [Description("036: Bell Wave 1")]
        BellWave1,

        [Description("037: Bell Wave 1+")]
        BellWave1Plus,

        [Description("038: Bell Wave 2")]
        BellWave2,

        [Description("039: Digital Wave 1")]
        DigiWave1,

        [Description("040: Digital Wave 2")]
        DigiWave2,

        [Description("041: Organ Bell")]
        OrgBell,

        [Description("042: Gamelan")]
        Gamelan,

        [Description("043: Crystal")]
        Crystal,

        [Description("044: Finger Bell")]
        FingerBell,

        [Description("045: Dipthong Wave")]
        DipthongWave,

        [Description("046: Dipthong Wave+")]
        DipthongWavePlus,

        [Description("047: Hollo Wave 1")]
        HolloWave1,

        [Description("048: Hollo Wave 2")]
        HolloWave2,

        [Description("049: Hollo Wave 2+")]
        HolloWave2Plus,

        [Description("050: Heaven Wave")]
        HeavenWave,

        [Description("051: Doo")]
        Doo,

        [Description("052: MMM Vox")]
        MmmVox,

        [Description("053: Eeh Formant")]
        EehFormant,

        [Description("054: Iih Formant")]
        IihFormat,

        [Description("055: Synth Vox 1")]
        SynVox1,

        [Description("056: Synth Vox 2")]
        SynVox2,

        [Description("057: Organ Vox")]
        OrgVox,

        [Description("058: Male Ooh")]
        MaleOoh,

        [Description("059: Large Choir 1")]
        LargeChrF1,

        [Description("060: Large Choir 2")]
        LargeChrF2,

        [Description("061: Female Oohs")]
        FemaleOohs,

        [Description("062: Female Aahs")]
        FemaleAahs,

        [Description("063: Atmospheric")]
        Atmospheric,

        [Description("064: Air Pad 1")]
        AirPad1,

        [Description("065: Air Pad 2")]
        AirPad2,

        [Description("066: Air Pad 3")]
        AirPad3,

        [Description("067: VP-330 Choir")]
        Vp330Choir,

        [Description("068: Synth Strings 1")]
        SynStrings1,

        [Description("069: Synth Strings 2")]
        SynStrings2,

        [Description("070: Synth Strings 3")]
        SynStrings3,

        [Description("071: Synth Strings 4")]
        SynStrings4,

        [Description("072: Synth Strings 5")]
        SynStrings5,

        [Description("073: Synth Strings 6")]
        SynStrings6,

        [Description("074: Revalation")]
        Revalation,

        [Description("075: Alan\'s Pad")]
        AlansPad,

        [Description("076: LFO Polyphonic")]
        LfoPoly,

        [Description("077: Boreal Pad Left")]
        BorealPadL,

        [Description("078: Boreal Pad Right")]
        BorealPadR,

        [Description("079: HPF Pad L")]
        HpfPadL,

        [Description("080: HPF Pad R")]
        HpfPadR,

        [Description("081: Sweep Pad")]
        SweepPad,

        [Description("082: Chubby Ld")]
        ChubbyLead,

        [Description("083: Fantasy Pad")]
        FantasyPad,

        [Description("084: Legend Pad")]
        LegendPad,

        [Description("085: D-50 Stack")]
        D50Stack,

        [Description("086: Chords Of Canada Left")]
        ChordOfCanadaL,

        [Description("087: Chords Of Canada Right")]
        ChordOfCanadaR,

        [Description("088: Fireflies")]
        Fireflies,

        [Description("089: Jazzy Bubbles")]
        JazzyBlues,

        [Description("090: Synth FX 1")]
        SynthFx1,

        [Description("091: Synth FX 2")]
        SynthFx2,

        [Description("092: X-Mod Wave 1")]
        XModWave1,

        [Description("093: X-Mod Wave 2")]
        XModWave2,

        [Description("094: Synth Vox Noise")]
        SynVoxNoise,

        [Description("095: Dentist Nz")]
        DentistNz,

        [Description("096: Atmosphere")]
        Atmosphere,

        [Description("097: Anklungs")]
        Anklungs,

        [Description("098: Xylo Seq")]
        XyloSeqm,

        [Description("099: O\'Skool Hit")]
        OldSkoolHit,

        [Description("100: Orchestra Hit")]
        OrchestraHit,

        [Description("101: Punch Hit")]
        PunchHit,

        [Description("102: Philly Hit")]
        PhillyHit,

        [Description("103: Classic Hse Hit")]
        ClassicHseHit,

        [Description("104: Tao Hit")]
        TaoHit,

        [Description("105: Smear Hit")]
        SmearHit,

        [Description("106: 808 Kick 1Lp")]
        Tr808Kick1Lp,

        [Description("107: 808 Kick 2Lp")]
        Tr808Kick2Lp,

        [Description("108: 909 Kick Lp")]
        Tr909KickLp,

        [Description("109: JD Piano")]
        JdPiano,

        [Description("110: Electric Grand")]
        ElectricGrand,

        [Description("111: Stage EP")]
        StageElectricPiano,

        [Description("112: Wurly")]
        Wurly,

        [Description("113: EP Hard")]
        ElectricPianoHard,

        [Description("114: FM EP 1")]
        FmElectricPiano1,

        [Description("115: FM EP 2")]
        FmElectricPiano2,

        [Description("116: FM EP 3")]
        FmElectricPiano3,

        [Description("117: Harpsi Wave")]
        HarpsiWave,

        [Description("118: Clav Wave 1")]
        ClavWave1,

        [Description("119: Clav Wave 2")]
        ClawWave2,

        [Description("120: Vibe Wave")]
        VibeWave,

        [Description("121: Organ Wave 1")]
        OrganWave1,

        [Description("122: Organ Wave 2")]
        OrganWave2,

        [Description("123: PercussiveOrgan 1")]
        PercOrgan1,

        [Description("124: Percussive Organ 2")]
        PercOrgan2,

        [Description("125: Vintage Organ")]
        VintageOrgan,

        [Description("126: Harmonica")]
        Harmonica,

        [Description("127: Accoustic Guitar")]
        AccousticGuitar,

        [Description("128: Nylon Gtr")]
        NylonGuitar,

        [Description("129: Baritone Strat")]
        BaritoneStart,

        [Description("130: Funk Guitar")]
        FunkGuitar,

        [Description("131: Jazz Guitar")]
        JazzGuitar,

        [Description("132: Distorted Guitar")]
        DistortedGuitar,

        [Description("133: Distorted Mute Gtr")]
        DistortedMutedGuitar,

        [Description("134: FatAc. Bass")]
        FatAccousticBass,

        [Description("135: Fingerd Bass")]
        FingeredBass,

        [Description("136: Picked Bass")]
        PickedBass,

        [Description("137: Fretless Bass")]
        FretlessBass,

        [Description("138: Slap Bass")]
        SlapBass,

        [Description("139: Strings 1")]
        Strings1,

        [Description("140: Strings 2")]
        Strings2,

        [Description("141: Strings 3 Left")]
        Strings3Left,

        [Description("142: Strings 3 Right")]
        Strings3Right,

        [Description("143: Pizzagogo")]
        Pizzagogo,

        [Description("144: Harp Harm")]
        HarpHarm,

        [Description("145: Harp Wave")]
        HarpWave,

        [Description("146: Pop Brass Attack")]
        PopBrassAttack,

        [Description("147: Pop Brass")]
        PopBrass,

        [Description("148: Tp Section")]
        TpSection,

        [Description("149: Studio Tp")]
        StudioTp,

        [Description("150: Tp Vib Mari")]
        TpVibMari,

        [Description("151: Tp Hrmn Mt")]
        TpHrmnMt,

        [Description("152: FM Brass")]
        FmBrass,

        [Description("153: Trombone")]
        Trombone,

        [Description("154: Wide Sax")]
        WideSax,

        [Description("155: Flute Wave")]
        FluteWave,

        [Description("156: Flute Push")]
        FlutePush,

        [Description("157: Electric Sitar")]
        ElectricSitar,

        [Description("158: Sitar Drone")]
        SitarDrone,

        [Description("159: Agogo")]
        Agogo,

        [Description("160: Steel Drums")]
        SteelDrums
    }
}