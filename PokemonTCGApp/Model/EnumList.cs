using System.ComponentModel;

namespace PokemonTCGApp.Model
{
    /// <summary>
    /// 卡牌主分類
    /// </summary>
    public enum SupertypesEnum
    {
        [Description("能量卡")]
        Energy,

        [Description("寶可夢卡")]
        Pokémon,

        [Description("訓練家卡")]
        Trainer,
    }

    /// <summary>
    /// 卡牌次分類
    /// </summary>
    public enum SubtypesEnum
    {
        [Description("Basic")]
        基礎,
        [Description("Stage1")]
        進化一,
        [Description("Stage2")]
        進化二,
        [Description("Supporter")]
        支援者,
        [Description("Item")]
        物品,
        [Description("Stadium")]
        競技場,
        [Description("BasicEnergy")]
        基礎能量,
        [Description("Special")]
        特殊能量,
        [Description("GX")]
        GX,
        [Description("TAGTEAM")]
        TAGTEAM,
        [Description("PrismStar")]
        稜柱之星,
        [Description("RapidStrike")]
        連擊,
        [Description("SingleStrike")]
        一擊,
        [Description("FusionStrike")]
        匯流,
        [Description("V")]
        V,
        [Description("VMAX")]
        VMAX,
        [Description("VUnion")]
        VUnion,
        [Description("VSTAR")]
        VSTAR,
        [Description("Sparkling")]
        光輝寶可夢,
        //[Description("Basic")]
        //基礎 = 1,
        //[Description("Stage1")]
        //進化一 = 2,
        //[Description("Stage2")]
        //進化二 = 3,
        //[Description("Supporter")]
        //支援者 = 4,
        //[Description("Item")]
        //物品 = 5,
        //[Description("Stadium")]
        //競技場 = 6,
        //[Description("BasicEnergy")]
        //基礎能量 = 7,
        //[Description("Special")]
        //特殊能量 = 8,
        //[Description("GX")]
        //GX = 9,
        //[Description("TAGTEAM")]
        //TAGTEAM = 10,
        //[Description("RapidStrike")]
        //連擊 = 11,
        //[Description("SingleStrike")]
        //一擊 = 12,
        //[Description("FusionStrike")]
        //匯流 = 13,
        //[Description("V")]
        //V = 14,
        //[Description("VMAX")]
        //VMAX = 15,
        //[Description("VUnion")]
        //VUnion = 16,
        //[Description("VSTAR")]
        //VSTAR = 17,
        //[Description("Sparkling")]
        //光輝寶可夢 = 18,
    }

    /// <summary>
    /// 卡牌稀有度等級
    /// </summary>
    public enum RaritiesEnum
    {
        //[Description("常見")]  // 寶可夢、物品卡、能量卡
        //C = 1,

        //[Description("不常見")]  //寶可夢、支援者卡、物品卡、競技場卡、能量卡
        //U = 2,

        //[Description("稀有")]  //寶可夢、支援者卡、物品卡、競技場卡
        //R = 3,

        //[Description("雙重稀有")]  //寶可夢EX、寶可夢GX、寶可夢V
        //RR = 4,

        //[Description("三重稀有")]  //寶可夢VMAX、寶可夢V-UNION、寶可夢VSTAR
        //RRR = 5,

        //[Description("非常稀有")]  //寶可夢GX、寶可夢V、支援者卡
        //SR = 6,

        //[Description("超級稀有")]  //寶可夢GX、寶可夢VMAX、支援者卡
        //HR = 7,

        //[Description("極其稀有")]  //寶可夢、寶可夢GX、寶可夢V、寶可夢VMAX、物品卡、競技場卡、能量卡
        //UR = 8,

        //[Description("稜柱之星稀有")]  //稜柱之星
        //PR = 9,

        //[Description("訓練家稀有")]  //支援者卡、物品卡
        //TR = 10,

        //[Description("奇幻稀有")]  //寶可夢
        //AR = 11,

        //[Description("光輝")]  //寶可夢
        //K = 12,

        //[Description("角色稀有")]  //寶可夢
        //CHR = 13,

        //[Description("角色非常稀有")]  //寶可夢V、寶可夢VMAX
        //CSR = 14,

        //[Description("異色")]  //寶可夢
        //S = 15,

        //[Description("異色非常稀有")]  //寶可夢GX、寶可夢V、寶可夢VMAX
        //SSR = 16,

        [Description("常見")]  // 寶可夢、物品卡、能量卡
        C,

        [Description("不常見")]  //寶可夢、支援者卡、物品卡、競技場卡、能量卡
        U,

        [Description("稀有")]  //寶可夢、支援者卡、物品卡、競技場卡
        R,

        [Description("雙重稀有")]  //寶可夢EX、寶可夢GX、寶可夢V
        RR,

        [Description("三重稀有")]  //寶可夢VMAX、寶可夢V-UNION、寶可夢VSTAR
        RRR,

        [Description("非常稀有")]  //寶可夢GX、寶可夢V、支援者卡
        SR,

        [Description("超級稀有")]  //寶可夢GX、寶可夢VMAX、支援者卡
        HR,

        [Description("極其稀有")]  //寶可夢、寶可夢GX、寶可夢V、寶可夢VMAX、物品卡、競技場卡、能量卡
        UR,

        [Description("稜柱之星稀有")]  //稜柱之星
        PR,

        [Description("訓練家稀有")]  //支援者卡、物品卡
        TR,

        [Description("奇幻稀有")]  //寶可夢
        AR,

        [Description("光輝")]  //寶可夢
        K,

        [Description("角色稀有")]  //寶可夢
        CHR,

        [Description("角色非常稀有")]  //寶可夢V、寶可夢VMAX
        CSR,

        [Description("異色")]  //寶可夢
        S,

        [Description("異色非常稀有")]  //寶可夢GX、寶可夢V、寶可夢VMAX
        SSR,
    }

    /// <summary>
    /// 卡牌寶可夢屬性
    /// </summary>
    public enum TypesEnum
    {
        [Description("Colorless")]
        無屬性,

        [Description("Darkness")]
        暗系,

        [Description("Dragon")]
        龍系,

        [Description("Fairy")]
        妖精系,

        [Description("Fighting")]
        鬥系,

        [Description("Fire")]
        火系,

        [Description("Grass")]
        草系,

        [Description("Lightning")]
        電系,

        [Description("Metal")]
        鋼系,

        [Description("Psychic")]
        超系,

        [Description("Water")]
        水系,
    }

    /// <summary>
    /// 卡牌環境
    /// </summary>
    public enum EnviromentEnum
    {
        [Description("A")]
        A,

        [Description("B")]
        B,

        [Description("C")]
        C,

        [Description("D")]
        D,

        [Description("E")]
        E,

        [Description("F")]
        F,

        [Description("G")]
        G,
    }
}
