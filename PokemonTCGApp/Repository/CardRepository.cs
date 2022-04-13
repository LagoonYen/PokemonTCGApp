using MongoDB.Driver;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;

namespace PokemonTCGApp.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<Card> _cardDatabase;
        private readonly IMongoCollection<Set> _setDatabase;


        public CardRepository(IPokemonTCGDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            //_cardDatabase = database.GetCollection<Card>(settings.PokemonTCGCollectionName);
            //_setDatabase = database.GetCollection<Set>(settings.PokemonTCGCollectionName);
            _cardDatabase = database.GetCollection<Card>(settings.CardCollectionName);
            _setDatabase = database.GetCollection<Set>(settings.SetCollectionName);
        }

        public Card CreateCard(Card card)
        {
            _cardDatabase.InsertOne(card);
            return card;
        }

        public void DeleteCard(string id)
        {
            _cardDatabase.DeleteOne(card => card.Id == id);
        }

        public Card GetCard(string id)
        {
            return _cardDatabase.Find(card => card.Id == id).FirstOrDefault();
        }

        public List<Card> GetCards()
        {
            return _cardDatabase.Find(card => true).ToList();
        }

        public void UpdateCard(string id, Card card)
        {
            _cardDatabase.ReplaceOne(card => card.Id == id, card);
        }

        public Set CreateSet(Set set)
        {
            try
            {
                _setDatabase.InsertOne(set);
                return set;
            }
            catch
            {
                throw;
            }
        }

        public List<Set> GetSets()
        {
            try
            {
                return _setDatabase.Find(set => true).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
