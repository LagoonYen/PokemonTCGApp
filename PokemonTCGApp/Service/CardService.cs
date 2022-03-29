using MongoDB.Driver;
using PokemonTCGApp.Model;

namespace PokemonTCGApp.Service
{
    public class CardService : ICardService
    {
        private readonly IMongoCollection<CardTest> _cardTests;

        public CardService(IPokemonTCGDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _cardTests = database.GetCollection<CardTest>(settings.PokemonTCGCollectionName);
        }

        public CardTest CreateCard(CardTest card)
        {
            _cardTests.InsertOne(card);
            return card;
        }

        public void DeleteCard(string id)
        {
            _cardTests.DeleteOne(cardTest => cardTest.Id == id);
        }

        public CardTest GetCard(string id)
        {
            return _cardTests.Find(cardTest => cardTest.Id == id).FirstOrDefault();
        }

        public List<CardTest> GetCards()
        {
            return _cardTests.Find(CardTest => true).ToList();
        }

        public void UpdateCard(string id, CardTest card)
        {
            _cardTests.ReplaceOne(cardTest => cardTest.Id == id, card);
        }
    }
}
