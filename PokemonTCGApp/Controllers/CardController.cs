using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Model.DTOModel;
using PokemonTCGApp.Service;
using System.Net;
using static PokemonTCGApp.Model.EnumExtension;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonTCGApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// 取得全卡片清單
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CardViewModel>> GetCards(RequestVueTable req)
        {
            try
            {
                if (req == null) { req = new RequestVueTable(); }
                if (req.@params == null) { req.@params = new Params(); }
                if (req.@params.FilterQuery == null) { req.@params.FilterQuery = new Dictionary<string, object>(); }

                var id = req.@params.FilterQuery["Id"] as string;
                var result = _cardService.GetCards();

                if (!result.Any()) throw new Exception("查無卡片");

                var cVueTableList = new VueTableList<CardViewModel>(result.ToList(), req.@params.Sort, req.@params.Per_page, req.@params.Page);
                return Ok(cVueTableList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得單一卡片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Card> GetCard(string id)
        {
            try
            {
                return Ok(_cardService.GetCard(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 新建or更新卡片
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Card> UpsertCard([FromBody]RequestUpsertCard req)
        {
            try
            {
                var result = _cardService.UpsertCard(req);

                //return CreatedAtAction(nameof(GetCard), new { id = req.Id }, req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">原卡片Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteCard(string id)
        {
            try
            {
                var card = _cardService.GetCard(id);

                if(card == null)
                {
                    return NotFound($"Card with Id = {id} not found");
                }

                _cardService.DeleteCard(id);

                return Accepted($"Card with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 新建卡牌系列
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> UpsertSet([FromBody]RequestUpsertSet req)
        {
            try
            {
                var result = _cardService.UpsertSet(req);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得全系列清單
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Set>> GetSets(RequestVueTable req)
        {
            try
            {
                if (req == null) { req = new RequestVueTable(); }
                if (req.@params == null) { req.@params = new Params(); }
                if (req.@params.FilterQuery == null) { req.@params.FilterQuery = new Dictionary<string, object>(); }

                var Id = req.@params.FilterQuery["Id"] as string;

                var result = _cardService.GetSets();

                if (!result.Any()) throw new Exception("查無系列");

                var cVueTableList = new VueTableList<SetViewModel>(result.ToList(), req.@params.Sort, req.@params.Per_page, req.@params.Page);
                return Ok(cVueTableList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得單一系列
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SetViewModel> GetSet(string id)
        {
            try
            {
                return Ok(_cardService.GetSet(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得全系列列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SetViewModel> GetAllSets()
        {
            try
            {
                var result = _cardService.GetSets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// 刪除系列
        /// </summary>
        /// <param name="id">原系列Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteSet(string id)
        {
            try
            {
                var card = _cardService.GetSet(id);

                if (card == null)
                {
                    return NotFound($"Set with Id = {id} not found");
                }

                _cardService.DeleteSet(id);

                return Accepted($"Set with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得卡牌主分類
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Card>> GetAllSupertypesEnum()
        {
            try
            {
                var result = _cardService.GetAllSupertypesEnum();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得卡牌次分類
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Card>> GetAllSubtypesEnum()
        {
            try
            {
                var result = _cardService.GetAllSubtypesEnum();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得卡牌稀有度
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Card>> GetAllRaritiesEnum()
        {
            try
            {
                var result = _cardService.GetAllRaritiesEnum();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 取得卡牌寶可夢屬性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<TypesEnumViewModel>> GetAllTypesEnum()
        {
            try
            {
                var result = _cardService.GetAllTypesEnum();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
