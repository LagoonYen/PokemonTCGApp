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

    public class EnviromentsEnumViewModel : EnumViewModel
    {

    }

    public class CardViewModel : Card
    {
        public Set SetInfo { get; set; }
        public string Imgbase64 { get; set; }
    }

    public class SetViewModel : Set
    {
        public string Imgbase64 { get; set; }
    }

    public class SearchCardsViewModel
    {
        public string Id { get; set; }
        public string SetId { get; set; }
        public int Number { get; set; }
        public byte[] Image { get; set; }
        public string Imgbase64 { get; set; }
    }
}
