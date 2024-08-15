using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop4UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("get-all-cart")]
        public async Task<IActionResult> GetAllCart()
        {
            var result = await _cartRepository.GetAllCart();

            if(result.ToList().Count == 0)
            {
                return NotFound(new {essage = "Cart Is Empty"});
            }

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllCartByUserId(int userId)
        {
            if(userId == null) 
            {
                return NotFound(new { Message = "No User!" });
            }

            var result = await _cartRepository.GetAllCartByUserID(userId);

            if(result.ToList().Count == 0)
            {
                return NotFound(new { Message = "No Cart Was Found!" });
            }

            return Ok(result);
        }

        [HttpPost("{userId:int}/{usernameId}/add-to-cart")]
        public async Task<IActionResult> AddToCart(int userId, Item item)
        {
            var result =  _cartRepository.AddCart(item, userId);
            return Ok(new {Message = "Item Added To Cart!"});
        }

        [HttpDelete("{cartId}")]
        public async  Task<IActionResult> DeleteCartById(int cartId) 
        {
            var result = await _cartRepository.DeleteCartByCartId(cartId);

            return Ok(new {Message = "Item Has Been Removed!"});
        }

        [HttpDelete("{userId:int}/delete-all")]
        public async Task<IActionResult> DeleteCartByUserId(int userId)
        {
            var result = await _cartRepository.DeleteAllCart(userId);

            return Ok(new {Message = "All Cart Items Has Been Removed!"});
        }


    }
}
