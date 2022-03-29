using PokemonTCGApp.Model;

namespace PokemonTCGApp.Service
{
    public interface ICardService
    {
        List<CardTest> GetCards();
        CardTest GetCard(string id);
        CardTest CreateCard(CardTest card);
        void UpdateCard(string id, CardTest card);
        void DeleteCard(string id);
    }
}
