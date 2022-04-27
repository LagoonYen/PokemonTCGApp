using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonTCGApp.Model.DTOModel;
using PokemonTCGApp.Service;
using static PokemonTCGApp.Model.EnumExtension;

namespace PokemonTCGApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontendController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IFrontendService _frontendService;

        public FrontendController(ICardService cardService, IFrontendService frontendService)
        {
            _cardService = cardService;
            _frontendService = frontendService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<SearchCardsViewModel>> SearchCards()
        {
            try
            {
                //if (req == null) { req = new RequestVueTable(); }
                //if (req.@params == null) { req.@params = new Params(); }
                //if (req == null) { req = new Dictionary<string, object>(); }
                
                //var id = req["Id"] as string;
                var result = _frontendService.SearchCards();

                //var cVueTableList = new VueTableList<SearchCardsViewModel>(result.ToList(), req.@params.Sort, req.@params.Per_page, req.@params.Page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
