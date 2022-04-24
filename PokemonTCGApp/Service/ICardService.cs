
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;

namespace PokemonTCGApp.Service
{
    public interface ICardService
    {
        IEnumerable<CardViewModel> GetCards();
        Card GetCard(string id);
        string CreateCard(RequestCreateCard req);
        void UpdateCard(string id, Card card);
        void DeleteCard(string id);

        List<Set> GetSets();
        string UpsertSet(RequestUpsertSet req);

        List<SupertypesEnumViewModel> GetAllSupertypesEnum();
        List<SubtypesEnumViewModel> GetAllSubtypesEnum();
        List<RaritiesEnumViewModel> GetAllRaritiesEnum();
        List<TypesEnumViewModel> GetAllTypesEnum();
        Set GetSet(string id);
        void DeleteSet(string id);
    }
}
