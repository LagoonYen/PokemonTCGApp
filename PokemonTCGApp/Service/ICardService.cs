
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;

namespace PokemonTCGApp.Service
{
    public interface ICardService
    {
        List<Card> GetCards();
        Card GetCard(string id);
        Card CreateCard(Card card);
        void UpdateCard(string id, Card card);
        void DeleteCard(string id);
        List<SupertypesEnumViewModel> GetAllSupertypesEnum();
        List<SubtypesEnumViewModel> GetAllSubtypesEnum();
        List<RaritiesEnumViewModel> GetAllRaritiesEnum();
        List<TypesEnumViewModel> GetAllTypesEnum();
    }
}
