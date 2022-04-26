using PokemonTCGApp.Model.DTOModel;
using PokemonTCGApp.Repository;
using System.Text;

namespace PokemonTCGApp.Service
{
    public class FrontendService : IFrontendService
    {
        private readonly ICardService _cardService;
        private readonly ICardRepository _cardRepository;

        public FrontendService(ICardService cardService, ICardRepository cardRepository)
        {
            _cardService = cardService;
            _cardRepository = cardRepository;
        }

        public IEnumerable<SearchCardsViewModel> SearchCards()
        {
            try
            { 
                var result = _cardRepository.GetCards();

                var searchCardsViewModel = result.Select(x => new SearchCardsViewModel
                {
                    Id = x.Id,
                    SetId = x.SetId,
                    Image = x.Image,
                }).OrderBy(x => x.SetId).OrderBy(x => x.Number).ToList(); ;

                foreach (var card in searchCardsViewModel)
                {
                    if (card.Image != null)
                    {
                        card.Image = _cardService.GetImage(Convert.ToBase64String(card.Image));
                        card.Imgbase64 = Encoding.UTF8.GetString(card.Image);
                    }
                }
                return searchCardsViewModel;
            }
            catch
            {
                throw;
            }
        }
    }
}
