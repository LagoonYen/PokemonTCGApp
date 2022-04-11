using MongoDB.Driver;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;
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

        public List<SupertypesEnumViewModel> GetAllSupertypesEnum()
        {
            try
            {
                var result = Enum.GetValues<SupertypesEnum>().Select(x => new SupertypesEnumViewModel
                {
                    Value = (int)x,
                    Name = x.ToString(),
                    Desc = x.GetDescription()
                }).ToList();

                if (result.Count == 0)
                {
                    throw new Exception("未取得正確主分類列表");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public List<SubtypesEnumViewModel> GetAllSubtypesEnum()
        {
            try
            {
                var result = Enum.GetValues<SubtypesEnum>().Select(x => new SubtypesEnumViewModel
                {
                    Value = (int)x,
                    Name = x.ToString(),
                    Desc = x.GetDescription()
                }).ToList();

                if (result.Count == 0)
                {
                    throw new Exception("未取得正確主分類列表");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public List<RaritiesEnumViewModel> GetAllRaritiesEnum()
        {
            try
            {
                var result = Enum.GetValues<RaritiesEnum>().Select(x => new RaritiesEnumViewModel
                {
                    Value = (int)x,
                    Name = x.ToString(),
                    Desc = x.GetDescription()
                }).ToList();

                if(result.Count == 0)
                {
                    throw new Exception("未取得正確稀有度列表");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public List<TypesEnumViewModel> GetAllTypesEnum()
        {
            try
            {
                var result = Enum.GetValues<TypesEnum>().Select(x => new TypesEnumViewModel
                {
                    Value = (int)x,
                    Name = x.ToString(),
                    Desc = x.GetDescription()
                }).ToList();

                if (result.Count == 0)
                {
                    throw new Exception("未取得正確稀有度列表");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
