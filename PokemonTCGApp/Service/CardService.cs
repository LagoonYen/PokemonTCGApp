using MongoDB.Driver;
using Newtonsoft.Json;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;
using PokemonTCGApp.Repository;
using System.Text;

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

        public string UpsertSet(RequestSaveSet req)
        {
            try
            {
                if(req.SeriesId == null || req.Name == null || req.Series == null)
                {
                    throw new Exception("請填寫基本系列資料");
                }

                Set setobject = new()
                {
                    Id = req.Id,
                    Series = req.Series,
                    Name = req.Name,
                    SeriesId = req.SeriesId,
                    ReleaseTime = req.ReleaseTime,
                    CreateTime = req.Id == null ? DateTime.Now : req.CreateTime,
                    UpdateTime = DateTime.Now,
                    //To do
                    UpdateAdmin = "小焰"
                };

                if (req.File?.Length > 0)
                {
                    string image = JsonConvert.SerializeObject(req.File);

                    string base64EncodedExternalImage = Convert.ToBase64String(Encoding.UTF8.GetBytes(image));
                    byte[] fileBytes = Convert.FromBase64String(base64EncodedExternalImage);
                    setobject.Image = fileBytes;
                    setobject = _cardRepository.UpsertSet(setobject);

                    if (setobject.Id?.Trim() != "")
                    {
                        return "圖片更新成功";
                    }
                }
                return "圖片更新失敗";
            }
            catch
            {
                throw;
            }
        }

        public byte[] GetImage(string sBase64String)
        {
            try
            {
                byte[] bytes = null;
                if (!string.IsNullOrEmpty(sBase64String))
                {
                    bytes = Convert.FromBase64String(sBase64String);
                }
                return bytes;
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
                var result = _cardRepository.GetSets();
                foreach(var set in result)
                {
                    if(set.Image != null)
                    {
                        set.Image = GetImage(Convert.ToBase64String(set.Image));
                        set.Imgbase64 = Encoding.UTF8.GetString(set.Image);
                    }
                }
                //result = result(s =>
                //{
                //    Id = s.Id,
                //    Name = s.Name,
                //    //Image = GetImage(Convert.ToBase64String(s.Image)),
                //    UpdateAdmin = s.UpdateAdmin,
                //    UpdateTime = s.UpdateTime,
                //    CreateTime = s.CreateTime,
                //    ReleaseTime = s.ReleaseTime,
                //    Series = s.Series,
                //    SeriesId = s.SeriesId,
                //});
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
