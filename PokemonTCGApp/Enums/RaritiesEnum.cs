namespace PokemonTCGApp.Enums
{
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
        RR = 5,

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
}
