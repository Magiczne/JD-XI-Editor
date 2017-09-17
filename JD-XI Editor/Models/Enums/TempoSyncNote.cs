using System.ComponentModel;

namespace JD_XI_Editor.Models.Enums
{
    internal enum TempoSyncNote
    {
        [Description("16")]
        SixteenWholeNotes,      

        [Description("12")]
        TwelveWholeNotes,       

        [Description("8")]
        OctupleWholeNote,       

        [Description("4")]
        QuadrupleWholeNote,     

        [Description("2")]
        DoubleWholeNote,        

        [Description("1")]
        WholeNote,              

        [Description("3/4")]
        ThreeFourths,           

        [Description("2/3")]
        TwoThirds,              

        [Description("1/2")]
        HalfNote,               

        [Description("3/8")]
        ThreeEights,            

        [Description("1/3")]
        OneThird,               

        [Description("1/4")]
        QuarterNote,            

        [Description("3/16")]
        ThreeSixteenths,        

        [Description("1/6")]
        OneSixth,               

        [Description("1/8")]
        EightNote,              

        [Description("3/32")]
        ThreeThirtyTwos,        

        [Description("1/12")]
        OneTwelve,              

        [Description("1/16")]
        SixteenthNote,          

        [Description("1/24")]
        OneTwentyFourth,        

        [Description("1/32")]
        ThirtySecondNote        
    }
}
