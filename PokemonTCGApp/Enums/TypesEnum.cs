using System.ComponentModel;

namespace PokemonTCGApp.Enums
{
    public enum TypesEnum
    {
        [Description("無屬性")]
        Colorless = 0,

        [Description("暗系")]
        Darkness = 1,

        [Description("龍系")]
        Dragon = 2,

        [Description("妖精系")]
        Fairy = 3,

        [Description("鬥系")]
        Fighting = 4,

        [Description("火系")]
        Fire = 5,

        [Description("草系")]
        Grass = 6,

        [Description("電系")]
        Lightning = 7,

        [Description("鋼系")]
        Metal = 8,

        [Description("超系")]
        Psychic = 9,

        [Description("水系")]
        Water = 10,
    }
}
