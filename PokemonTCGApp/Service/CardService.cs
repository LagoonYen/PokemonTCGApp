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

        public IEnumerable<CardViewModel> GetCards()
        {
            try
            {
                var result = _cardRepository.GetCards();

                var cardViewModel = result.Select(x => new CardViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Supertype = x.Supertype,
                    Subtypes = x.Subtypes,
                    Rarity = x.Rarity,
                    Enviroment = x.Enviroment,
                    Types = x.Types,
                    EvolvesFrom = x.EvolvesFrom,
                    EvolvesTo = x.EvolvesTo,
                    FlavorText = x.FlavorText,
                    Hp = x.Hp,
                    TrainerEffect = x.TrainerEffect,
                    Abilities = x.Abilities,
                    Attacks = x.Attacks,
                    Weaknesses = x.Weaknesses,
                    Resistances = x.Resistances,
                    SetId = x.SetId,
                    SetInfo = x.SetId == null ? null : GetSet(x.SetId),
                    Number = x.Number,
                    CreateTime = x.CreateTime,
                    UpdateAdmin = x.UpdateAdmin,
                    UpdateTime = x.UpdateTime,
                    Image = x.Image,
                }).OrderBy(x => x.SetId).OrderBy(x => x.Number).ToList(); ;

                foreach (var card in cardViewModel)
                {
                    if (card.Image != null)
                    {
                        card.Image = GetImage(Convert.ToBase64String(card.Image));
                        card.Imgbase64 = Encoding.UTF8.GetString(card.Image);
                    }
                }
                return cardViewModel;
            }
            catch
            {
                throw;
            }
        }
        
        public CardViewModel GetCard(string id)
        {
            try
            {
                var result = _cardRepository.GetCard(id);
                var cardViewModel = new CardViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Supertype = result.Supertype,
                    Subtypes = result.Subtypes,
                    Rarity = result.Rarity,
                    Enviroment = result.Enviroment,
                    Types = result.Types,
                    Hp = result.Hp,
                    EvolvesFrom = result.EvolvesFrom,
                    EvolvesTo = result.EvolvesTo,
                    TrainerEffect = result.TrainerEffect,
                    Abilities = result.Abilities,
                    Attacks = result.Attacks,
                    Weaknesses = result.Weaknesses,
                    Resistances = result.Resistances,
                    SetId = result.SetId,
                    Number = result.Number,
                    FlavorText = result.FlavorText,
                    CreateTime = result.CreateTime,
                    UpdateAdmin = result.UpdateAdmin,
                    UpdateTime = result.UpdateTime,
                };

                if (result.Image != null)
                {
                    cardViewModel.Image = GetImage(Convert.ToBase64String(result.Image));
                    cardViewModel.Imgbase64 = Encoding.UTF8.GetString(result.Image);
                }
                return cardViewModel;
            }
            catch
            {
                throw;
            }
        }

        public string UpsertCard(RequestUpsertCard req)
        {
            try
            {
                if (req.Supertype == null || req.Name == null || req.Subtypes == null || req.Rarity == null)
                {
                    throw new Exception("請填寫基本系列資料");
                }

                var cardobject = new Card()
                {
                    Id = req.Id == "" ? null : req.Id,
                    SetId = req.SetId,
                    Number = req.Number,
                    Name = req.Name,
                    Supertype = req.Supertype,
                    Subtypes = req.Subtypes,
                    Rarity = req.Rarity,
                    Enviroment = req.Enviroment,
                    Types = req.Types,
                    Hp = req.Hp,
                    EvolvesFrom = req.EvolvesFrom,
                    EvolvesTo = req.EvolvesTo,
                    FlavorText = req.FlavorText,
                    Abilities = req.Abilities,
                    Attacks = req.Attacks,
                    Weaknesses = req.Weaknesses,
                    Resistances = req.Resistances,
                    TrainerEffect = req.TrainerEffect,
                    CreateTime = req.Id == "" ? DateTime.Now : req.CreateTime,
                    UpdateTime = DateTime.Now,
                    UpdateAdmin = "小焰"
                };

                if (req.File?.Length > 0)
                {
                    string image = JsonConvert.SerializeObject(req.File);

                    string base64EncodedExternalImage = Convert.ToBase64String(Encoding.UTF8.GetBytes(image));
                    byte[] fileBytes = Convert.FromBase64String(base64EncodedExternalImage);
                    cardobject.Image = fileBytes;
                    cardobject = _cardRepository.UpsertCard(cardobject);

                    return "Upsert並上傳新圖片";
                }

                cardobject = _cardRepository.UpsertCard(cardobject);
                return "Upsert無上傳新圖片";
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

        public IEnumerable<SetViewModel> GetSets()
        {
            try
            {
                var result = _cardRepository.GetSets();
                var setViewModel = result.Select(x => new SetViewModel
                {
                    Id = x.Id,
                    SeriesId = x.SeriesId,
                    Series = x.Series,
                    Name = x.Name,
                    ReleaseTime = x.ReleaseTime,
                    CreateTime = x.CreateTime,
                    UpdateTime = x.UpdateTime,
                    UpdateAdmin = x.UpdateAdmin,
                    Image = x.Image,
                }).OrderBy(x => x.ReleaseTime).OrderBy(x => x.SeriesId).ToList();

                foreach (var set in setViewModel)
                {
                    if (set.Image != null)
                    {
                        set.Image = GetImage(Convert.ToBase64String(set.Image));
                        set.Imgbase64 = Encoding.UTF8.GetString(set.Image);
                    }
                }
                return setViewModel;
            }
            catch
            {
                throw;
            }
        }

        public SetViewModel GetSet(string id)
        {
            try
            {
                var result = _cardRepository.GetSet(id);
                var setViewModel = new SetViewModel
                {
                    Id = result.Id,
                    SeriesId = result.SeriesId,
                    Series = result.Series,
                    Name = result.Name,
                    ReleaseTime = result.ReleaseTime,
                    CreateTime = result.CreateTime,
                    UpdateTime = result.UpdateTime,
                    UpdateAdmin = result.UpdateAdmin,
                    Image = result.Image,
                };

                if (result.Image != null)
                {
                    setViewModel.Image = GetImage(Convert.ToBase64String(result.Image));
                    setViewModel.Imgbase64 = Encoding.UTF8.GetString(result.Image);
                }
                return setViewModel;
            }
            catch
            {
                throw;
            }
        }

        public string UpsertSet(RequestUpsertSet req)
        {
            try
            {
                if(req.SeriesId == null || req.Name == null || req.Series == null)
                {
                    throw new Exception("請填寫基本系列資料");
                }

                var setobject = new Set()
                {
                    Id = req.Id == string.Empty ? null : req.Id,
                    Series = req.Series,
                    Name = req.Name,
                    SeriesId = req.SeriesId,
                    ReleaseTime = req.ReleaseTime,
                    CreateTime = req.Id == string.Empty ? DateTime.Now : req.CreateTime,
                    UpdateTime = DateTime.Now,
                    UpdateAdmin = "小焰"
                };

                if (req.File?.Length > 0)
                {
                    string image = JsonConvert.SerializeObject(req.File);

                    string base64EncodedExternalImage = Convert.ToBase64String(Encoding.UTF8.GetBytes(image));
                    byte[] fileBytes = Convert.FromBase64String(base64EncodedExternalImage);
                    setobject.Image = fileBytes;
                    setobject = _cardRepository.UpsertSet(setobject);
                    return "Upsert並上傳新圖片";
                }

                setobject = _cardRepository.UpsertSet(setobject);
                return "Upsert無上傳新圖片";
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
                _cardRepository.DeleteSet(id);
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
                byte[]? bytes = null;
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

        public IEnumerable<SupertypesEnumViewModel> GetAllSupertypesEnum()
        {
            try
            {
                var result = Enum.GetValues<SupertypesEnum>().Select(x => new SupertypesEnumViewModel
                {
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

        public IEnumerable<SubtypesEnumViewModel> GetAllSubtypesEnum()
        {
            try
            {
                var result = Enum.GetValues<SubtypesEnum>().Select(x => new SubtypesEnumViewModel
                {
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

        public IEnumerable<RaritiesEnumViewModel> GetAllRaritiesEnum()
        {
            try
            {
                var result = Enum.GetValues<RaritiesEnum>().Select(x => new RaritiesEnumViewModel
                {
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

        public IEnumerable<TypesEnumViewModel> GetAllTypesEnum()
        {
            try
            {
                var result = Enum.GetValues<TypesEnum>().Select(x => new TypesEnumViewModel
                {
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

        public IEnumerable<EnviromentsEnumViewModel> GetAllEnviromentsEnum()
        {
            try
            {
                var result = Enum.GetValues<EnviromentEnum>().Select(x => new EnviromentsEnumViewModel
                {
                    Name = x.ToString(),
                    Desc = x.GetDescription()
                }).ToList();

                if (result.Count == 0)
                {
                    throw new Exception("未取得正確環境列表");
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
