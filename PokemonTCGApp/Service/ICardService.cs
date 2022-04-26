
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
        IEnumerable<SupertypesEnumViewModel> GetAllSupertypesEnum();
        IEnumerable<SubtypesEnumViewModel> GetAllSubtypesEnum();
        IEnumerable<RaritiesEnumViewModel> GetAllRaritiesEnum();
        IEnumerable<TypesEnumViewModel> GetAllTypesEnum();

        IEnumerable<EnviromentsEnumViewModel> GetAllEnviromentsEnum();
    }
}
