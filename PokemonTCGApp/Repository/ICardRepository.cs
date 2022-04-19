using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Repository
{
    public interface ICardRepository
    {
        List<Card> GetCards();
        Card GetCard(string id);
        Card CreateCard(Card card);
        void UpdateCard(string id, Card card);
        void DeleteCard(string id);
        Set UpsertSet(Set set);
        List<Set> GetSets();
    }
}
