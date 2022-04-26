using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Repository
{
    public interface ICardRepository
    {
        //Card
        IEnumerable<Card> GetCards();
        Card GetCard(string id);
        Card UpsertCard(Card card);
        void DeleteCard(string id);

        //Set
        List<Set> GetSets();
        Set GetSet(string id);
        Set UpsertSet(Set set);
        void DeleteSet(string id);
    }
}
