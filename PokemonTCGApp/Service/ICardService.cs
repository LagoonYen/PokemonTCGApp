
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;

namespace PokemonTCGApp.Service
{
    public interface ICardService
    {
        //Card
        IEnumerable<CardViewModel> GetCards();
        CardViewModel GetCard(string id);
        string UpsertCard(RequestUpsertCard req);
        void DeleteCard(string id);

        //Set
        IEnumerable<SetViewModel> GetSets();
        SetViewModel GetSet(string id);
        string UpsertSet(RequestUpsertSet req);
        void DeleteSet(string id);

        //Enumn
        List<SupertypesEnumViewModel> GetAllSupertypesEnum();
        List<SubtypesEnumViewModel> GetAllSubtypesEnum();
        List<RaritiesEnumViewModel> GetAllRaritiesEnum();
        List<TypesEnumViewModel> GetAllTypesEnum();
    }
}
