using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NSwag.Annotations;

using LogicalSeparation.BLL.Dtos;
using LogicalSeparation.BLL.Interfaces;

namespace LogicalSeparation.Web.Controllers.v1
{
    [Route("api/v1/carts")]
    [ApiController]
    public class CartsV1Controller : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsV1Controller(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCartInfo(int id)
        {
            return Ok(_cartService.GetCart(id));
        }

        [HttpPost("{cartId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddItem(int cartId, CartItemDto itemDto)
        {
            _cartService.AddItem(cartId, itemDto);
            return Ok();
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteItem(int cartId, int itemId)
        {
            _cartService.RemoveItem(cartId, itemId);
            return Ok();
        }
    }
}
