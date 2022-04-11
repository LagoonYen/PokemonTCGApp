using System.ComponentModel;

namespace PokemonTCGApp.Model
{
    /// <summary>
    /// 卡牌主分類
    /// </summary>
    public enum SupertypesEnum
    {
        [Description("能量卡")]
        Energy = 0,

        [Description("寶可夢卡")]
        Pokémon = 1,

        [Description("訓練家卡")]
        Trainer = 2
    }

    /// <summary>
    /// 卡牌次分類
    /// </summary>
    public enum SubtypesEnum
    {
        //[Description("基礎")]
        //Basic = 1,
        //[Description("GX")]
        //GX = 2,
        //[Description("物品")]
        //Item = 3,
        //[Description("連擊")]
        //RapidStrike = 4,
        //[Description("一擊")]
        //SingleStrike = 5,
        //[Description("匯流")]
        //FusionStrike = 6,
        //[Description("特殊能量")]
        //Special = 7,
        //[Description("競技場")]
        //Stadium = 8,
        //[Description("進化一")]
        //Stage1 = 9,
        //[Description("進化二")]
        //Stage2 = 10,
        //[Description("支援者")]
        //Supporter = 11,
        //[Description("TAGTEAM")]
        //TAGTEAM = 12,
        //[Description("V")]
        //V = 13,
        //[Description("VMAX")]
        //VMAX = 14,
        //[Description("VUnion")]
        //VUnion = 15,
        //[Description("VSTAR")]
        //VSTAR = 16,
        //[Description("光輝寶可夢")]
        //Sparkling = 17

        [Description("Basic")]
        基礎 = 1,
        [Description("GX")]
        GX = 2,
        [Description("Item")]
        物品 = 3,
        [Description("RapidStrike")]
        連擊 = 4,
        [Description("SingleStrike")]
        一擊 = 5,
        [Description("FusionStrike")]
        匯流 = 6,
        [Description("Special")]
        特殊能量 = 7,
        [Description("Stadium")]
        競技場 = 8,
        [Description("Stage1")]
        進化一 = 9,
        [Description("Stage2")]
        進化二 = 10,
        [Description("Supporter")]
        支援者 = 11,
        [Description("TAGTEAM")]
        TAGTEAM = 12,
        [Description("V")]
        V = 13,
        [Description("VMAX")]
        VMAX = 14,
        [Description("VUnion")]
        VUnion = 15,
        [Description("VSTAR")]
        VSTAR = 16,
        [Description("Sparkling")]
        光輝寶可夢 = 17,
    }

    /// <summary>
    /// 卡牌稀有度等級
    /// </summary>
    public enum RaritiesEnum
    {
        [Description("常見")]  // 寶可夢、物品卡、能量卡
        C = 1,

        [Description("不常見")]  //寶可夢、支援者卡、物品卡、競技場卡、能量卡
        U = 2,

        [Description("稀有")]  //寶可夢、支援者卡、物品卡、競技場卡
        R = 3,

        [Description("雙重稀有")]  //寶可夢EX、寶可夢GX、寶可夢V
        RR = 4,

        [Description("三重稀有")]  //寶可夢VMAX、寶可夢V-UNION、寶可夢VSTAR
        RRR = 5,

        [Description("非常稀有")]  //寶可夢GX、寶可夢V、支援者卡
        SR = 6,

        [Description("超級稀有")]  //寶可夢GX、寶可夢VMAX、支援者卡
        HR = 7,

        [Description("極其稀有")]  //寶可夢、寶可夢GX、寶可夢V、寶可夢VMAX、物品卡、競技場卡、能量卡
        UR = 8,

        [Description("稜柱之星稀有")]  //稜柱之星
        PR = 9,

        [Description("訓練家稀有")]  //支援者卡、物品卡
        TR = 10,

        [Description("奇幻稀有")]  //寶可夢
        AR = 11,

        [Description("光輝")]  //寶可夢
        K = 12,

        [Description("角色稀有")]  //寶可夢
        CHR = 13,

        [Description("角色非常稀有")]  //寶可夢V、寶可夢VMAX
        CSR = 14,

        [Description("異色")]  //寶可夢
        S = 15,

        [Description("異色非常稀有")]  //寶可夢GX、寶可夢V、寶可夢VMAX
        SSR = 16,
    }

    /// <summary>
    /// 卡牌寶可夢屬性
    /// </summary>
    public enum TypesEnum
    {
        //[Description("無屬性")]
        //Colorless = 0,

        //[Description("暗系")]
        //Darkness = 1,

        //[Description("龍系")]
        //Dragon = 2,

        //[Description("妖精系")]
        //Fairy = 3,

        //[Description("鬥系")]
        //Fighting = 4,

        //[Description("火系")]
        //Fire = 5,

        //[Description("草系")]
        //Grass = 6,

        //[Description("電系")]
        //Lightning = 7,

        //[Description("鋼系")]
        //Metal = 8,

        //[Description("超系")]
        //Psychic = 9,

        //[Description("水系")]
        //Water = 10,

        [Description("Colorless")]
        無屬性 = 0,

        [Description("Darkness")]
        暗系 = 1,

        [Description("Dragon")]
        龍系 = 2,

        [Description("Fairy")]
        妖精系 = 3,

        [Description("Fighting")]
        鬥系 = 4,

        [Description("Fire")]
        火系 = 5,

        [Description("Grass")]
        草系 = 6,

        [Description("Lightning")]
        電系 = 7,

        [Description("Metal")]
        鋼系 = 8,

        [Description("Psychic")]
        超系 = 9,

        [Description("Water")]
        水系 = 10,
    }
}
