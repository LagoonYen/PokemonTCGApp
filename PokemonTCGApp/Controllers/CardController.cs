using Microsoft.AspNetCore.Mvc;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
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
        public ActionResult<List<Card>> GetCards()
        {
            return cardService.GetCards();
            //try
            //{

            //    return cardService.GetCards();
                
            //}
            //catch
            //{
                
            //}
        }

        // GET api/<CardController>/5
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Card> GetCard(string id)
        {
            return cardService.GetCard(id);
        }

        // POST api/<CardController>
        [HttpPost]
        [Route("[action]")]
        public ActionResult<Card> CreateCard([FromBody] Card card)
        {
            cardService.CreateCard(card);

            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }

        // PUT api/<CardController>/5
        [HttpPut]
        [Route("[action]")]
        public ActionResult UpdateCard(string id, [FromBody] Card card)
        {
            var existingCard = cardService.GetCard(id);

            if(existingCard == null)
            {
                return NotFound($"Card with Id = {id} not found");
            }

            cardService.UpdateCard(id, card);

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
