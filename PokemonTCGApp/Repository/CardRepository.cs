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

        public Card UpsertCard(Card card)
        {
            try
            {
                var cardObj = _cardDatabase.Find(x => x.Id == card.Id).FirstOrDefault();
                if (cardObj == null)
                {
                    _cardDatabase.InsertOne(card);
                }
                else
                {
                    _cardDatabase.ReplaceOne(x => x.Id == card.Id, card);
                }
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

        public Set UpsertSet(Set set)
        {
            try
            {
                var setObj = _setDatabase.Find(x => x.Id == set.Id).FirstOrDefault();
                if (setObj == null)
                {
                    _setDatabase.InsertOne(set);
                }
                else
                {
                    _setDatabase.ReplaceOne(x => x.Id == set.Id, set);
                }
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

        public Set GetSet(string id)
        {
            try
            {
                return _setDatabase.Find(set => set.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteSet(string id)
        {
            try
            {
                _setDatabase.DeleteOne(set => set.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
