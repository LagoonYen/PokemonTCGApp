using PokemonTCGApp.Model.DTOModel;

namespace PokemonTCGApp.Service
{
    public interface IFrontendService
    {
        IEnumerable<SearchCardsViewModel> SearchCards();
    }
}
