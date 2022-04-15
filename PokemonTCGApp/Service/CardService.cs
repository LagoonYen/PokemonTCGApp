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
            try
            {
                _cardRepository.CreateCard(card);
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
                _cardRepository.DeleteCard(id);
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
                return _cardRepository.GetCard(id);
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
                return _cardRepository.GetCards();
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
                _cardRepository.UpdateCard(id, card);
            }
            catch
            {
                throw;
            }
        }

        public Set CreateSet(RequestCreateSet req)
        {
            Set set = new()
            {
                Series = req.Series,
                Name = req.Name,
                SeriesId = req.SeriesId,
                //Image = req.Image,
                ReleaseTime = req.ReleaseTime,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                UpdateAdmin = "小焰"
            };

            _cardRepository.CreateSet(set);
            return set;
        }

        public List<Set> GetSets()
        {
            try
            {
                var result = _cardRepository.GetSets();
                return result.OrderBy(x => x.ReleaseTime).OrderBy(x => x.SeriesId).ToList();
            }
            catch
            {
                throw;
            }
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
