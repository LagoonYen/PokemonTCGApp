using MongoDB.Driver;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Repository;

namespace PokemonTCGApp.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public Card CreateCard(Card card)
        {
            _cardRepository.CreateCard(card);
            return card;
        }

        public void DeleteCard(string id)
        {
            _cardRepository.DeleteCard(id);
        }

        public Card GetCard(string id)
        {
            return _cardRepository.GetCard(id);
        }

        public List<Card> GetCards()
        {
            return _cardRepository.GetCards();
        }

        public void UpdateCard(string id, Card card)
        {
            _cardRepository.UpdateCard(id, card);
        }
    }
}
