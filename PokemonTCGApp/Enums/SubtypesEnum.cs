using System.ComponentModel;

namespace PokemonTCGApp.Enums
{
    public enum SubtypesEnum
    {
        //BREAK,
        //Baby,
        [Description("基礎")]
        Basic = 1,
        //EX,
        [Description("GX")]
        GX = 2,
        //Goldenrod Game Corner,
        [Description("物品")]
        Item = 3,
        //LEGEND,
        //Level-Up,
        //MEGA,
        //Pokémon Tool,
        //Pokémon Tool F,
        [Description("連擊")]
        RapidStrike = 4,
        //Restored,
        //Rocket's Secret Machine,
        [Description("一擊")]
        SingleStrike = 5,
        Special,
        Stadium,
        [Description("進化一")]
        Stage1,
        [Description("進化二")]
        Stage2,
        [Description("支援者")]
        Supporter,
        [Description("TAGTEAM")]
        TAGTEAM,
        //Technical Machine,
        [Description("V")]
        V,
        [Description("VMAX")]
        VMAX,
        [Description("VUnion")]
        VUnion,
        [Description("VSTAR")]
        VSTAR,
        [Description("光輝寶可夢")]
        Sparkling
    }
}
