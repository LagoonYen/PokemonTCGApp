using Microsoft.AspNetCore.Mvc;
using PokemonTCGApp.Model;
using PokemonTCGApp.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonTCGApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService cardService;

        public CardController(ICardService cardService)
        {
            this.cardService = cardService;
        }
        // GET: api/<CardController>

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<CardTest>> GetCards()
        {
            return cardService.GetCards();
        }

        // GET api/<CardController>/5
        [HttpGet]
        [Route("[action]")]
        public ActionResult<CardTest> GetCard(string id)
        {
            return cardService.GetCard(id);
        }

        // POST api/<CardController>
        [HttpPost]
        [Route("[action]")]
        public ActionResult<CardTest> CreateCard([FromBody] CardTest cardTest)
        {
            cardService.CreateCard(cardTest);

            return CreatedAtAction(nameof(GetCard), new { id = cardTest.Id }, cardTest);
        }

        // PUT api/<CardController>/5
        [HttpPut]
        [Route("[action]")]
        public ActionResult UpdateCard(string id, [FromBody] CardTest cardTest)
        {
            var existingCard = cardService.GetCard(id);

            if(existingCard == null)
            {
                return NotFound($"Card with Id = {id} not found");
            }

            cardService.UpdateCard(id, cardTest);

            return NoContent();
        }

        // DELETE api/<CardController>/5
        [HttpDelete]
        [Route("[action]")]
        public ActionResult DeleteCard(string id)
        {
            var card = cardService.GetCard(id);

            if(card == null)
            {
                return NotFound($"Card with Id = {id} not found");
            }

            cardService.DeleteCard(id);

            return Ok($"Card with Id = {id} deleted");
        }
    }
}
