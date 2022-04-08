﻿using Microsoft.AspNetCore.Mvc;
using PokemonTCGApp.Model;
using PokemonTCGApp.Model.DataModel;
using PokemonTCGApp.Service;
using System.Net;

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

        /// <summary>
        /// 取得全卡片清單
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Card>> GetCards()
        {
            try
            {
                return Ok(cardService.GetCards());
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
                return Ok(cardService.GetCard(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 新建卡片
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Card> CreateCard([FromBody] Card card)
        {
            try
            {
                cardService.CreateCard(card);

                return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 編輯卡片
        /// </summary>
        /// <param name="id">原卡片Id</param>
        /// <param name="card">卡片資料</param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCard(string id, [FromBody] Card card)
        {
            try
            {
                var existingCard = cardService.GetCard(id);

                if(existingCard == null)
                {
                    return NotFound($"Card with Id = {id} not found");
                }

                cardService.UpdateCard(id, card);

                return NoContent();
            }
            catch(Exception ex)
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
                var card = cardService.GetCard(id);

                if(card == null)
                {
                    return NotFound($"Card with Id = {id} not found");
                }

                cardService.DeleteCard(id);

                return Accepted($"Card with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}