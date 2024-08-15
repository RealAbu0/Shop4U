using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop4UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardDetailsRepository _cardRepo;
        public CardController(ICardDetailsRepository cardRepo)
        {
            _cardRepo = cardRepo;
        }

        [HttpPost]
        public IActionResult AddCard(CardDetails card)
        {
            try
            {   
                _cardRepo.AddCard(card);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllCards()
        {
            var result = _cardRepo.GetAllCards();

            if(result.Count == 0) 
            {
                return BadRequest(new { Message = "No Cards!" });
            }

            return Ok(result);
        }
    }
}
