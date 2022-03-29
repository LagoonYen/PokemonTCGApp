using System.ComponentModel;

namespace PokemonTCGApp.Enums
{
    public enum SupertypesEnum
    {
        [Description("能量卡")]
        Energy = 0,

        [Description("寶可夢卡")]
        Pokémon = 1,

        [Description("訓練家卡")]
        Trainer = 2
    }
}
