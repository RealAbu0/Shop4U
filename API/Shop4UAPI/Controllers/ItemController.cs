using Connections.Repositories;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop4UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("get-soft-drinks")]
        public async Task<IActionResult> GetAllSoftDrinks()
        {
            var result = await _itemRepository.GetAllSoftDrinks();
            if (result.ToList().Count == 0)
                return NotFound(new { Message = "No Soft Drinks Are Found!" });
            return Ok(result);
        }

        [HttpGet("get-candy")]
        public async Task<IActionResult> GetAllCandy()
        {
            var result = await _itemRepository.GetAllCandy();
            if(result.ToList().Count == 0)
                return NotFound(new { Message = "No Candys Are Found!" });
            return Ok(result);
        }

        [HttpGet("get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _itemRepository.GetAllItems();
            if (result.ToList().Count == 0)
                return NotFound(new { Message = "No Items Are Found!" });
            return Ok(result);
        }
    }
}
