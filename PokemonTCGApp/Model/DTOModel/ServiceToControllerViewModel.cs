using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Model.DTOModel
{
    public class EnumViewModel
    {
        public int Value { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
    }

    public class SupertypesEnumViewModel : EnumViewModel
    {
    }

    public class SubtypesEnumViewModel : EnumViewModel
    {
    }

    public class RaritiesEnumViewModel : EnumViewModel
    {
    }

    public class TypesEnumViewModel : EnumViewModel
    {
    }

    public class CardViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Supertype { get; set; }

        public List<string>? Subtypes { get; set; }

        public string Rarity { get; set; }

        public List<string> Types { get; set; }

        public int? Hp { get; set; }

        public string EvolvesFrom { get; set; }

        public List<string>? EvolvesTo { get; set; }

        public string TrainerEffect { get; set; }

        public List<Ability>? Abilities { get; set; }

        public List<Attack>? Attacks { get; set; }

        public List<Weakness>? Weaknesses { get; set; }

        public List<Resistance>? Resistances { get; set; }

        public string SetId { get; set; }

        public Set? SetInfo { get; set; }

        public int? Number { get; set; }

        public string FlavorText { get; set; }

        public byte[]? Image { get; set; }

        public string UpdateAdmin { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Imgbase64 { get; set; }
    }
}
