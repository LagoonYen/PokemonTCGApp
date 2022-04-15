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
            _cardDatabase = database.GetCollection<Card>(settings.CardCollectionName);
            _setDatabase = database.GetCollection<Set>(settings.SetCollectionName);
        }

        public Card CreateCard(Card card)
        {
            try
            {
                _cardDatabase.InsertOne(card);
                return card;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteCard(string id)
        {
            try
            {
                _cardDatabase.DeleteOne(card => card.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public Card GetCard(string id)
        {
            try
            {
                return _cardDatabase.Find(card => card.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<Card> GetCards()
        {
            try
            {
                return _cardDatabase.Find(card => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateCard(string id, Card card)
        {
            try
            {
                _cardDatabase.ReplaceOne(card => card.Id == id, card);
            }
            catch
            {
                throw;
            }
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
