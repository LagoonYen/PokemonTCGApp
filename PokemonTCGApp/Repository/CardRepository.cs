using MongoDB.Driver;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<Card> _cardDatabase;

        public CardRepository(IPokemonTCGDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _cardDatabase = database.GetCollection<Card>(settings.PokemonTCGCollectionName);
        }
        public Card CreateCard(Card card)
        {
            _cardDatabase.InsertOne(card);
            return card;
        }

        public void DeleteCard(string id)
        {
            _cardDatabase.DeleteOne(cardTest => cardTest.Id == id);
        }

        public Card GetCard(string id)
        {
            return _cardDatabase.Find(cardTest => cardTest.Id == id).FirstOrDefault();
        }

        public List<Card> GetCards()
        {
            return _cardDatabase.Find(CardTest => true).ToList();
        }

        public void UpdateCard(string id, Card card)
        {
            _cardDatabase.ReplaceOne(cardTest => cardTest.Id == id, card);
        }
    }
}
