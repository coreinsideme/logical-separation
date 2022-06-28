using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NSwag.Annotations;

using LogicalSeparation.BLL.Dtos;
using LogicalSeparation.BLL.Interfaces;


namespace LogicalSeparation.Web.Controllers.v2
{
    [Route("api/v2/carts")]
    [ApiController]
    public class CartsV2Controller : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsV2Controller(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCartInfo(int id)
        {
            return Ok(_cartService.GetItems(id));
        }

        [HttpPost("{cartId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddItem(int cartId, CartItemDto itemDto)
        {
            return RedirectToAction("AddItem", "CartsV1Controller", new { cartId, itemDto });
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteItem(int cartId, int itemId)
        {
            return RedirectToAction("DeleteItem", "CartsV2Controller", new { cartId, itemId }); ;
        }
    }
}
