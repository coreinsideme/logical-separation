using System.Linq;

using LogicalSeparation.BLL.Dtos;
using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Interfaces;

namespace LogicalSeparation.BLL.Mappers
{
    internal class CartMapper: ICartMapper
    {
        private readonly ICartItemMapper _cartItemMapper;

        public CartMapper(ICartItemMapper cartItemMapper)
        {
            this._cartItemMapper = cartItemMapper;
        }

        public CartDto MapToDto(Cart cart)
        {
            return new CartDto { Id = cart.Id, Items = cart.Items.Select(i => _cartItemMapper.MapToDto(i)).ToList() };
        }

        public Cart MapToEntity(CartDto dto)
        {
            return new Cart  { Id = dto.Id, Items = dto.Items.Select(i => _cartItemMapper.MapToEntity(i)).ToList() };
        }
    }
}
