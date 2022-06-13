using LogicalSeparation.BLL.Dtos;
using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Interfaces;

namespace LogicalSeparation.BLL.Mappers
{
    internal class CartItemMapper: ICartItemMapper
    {
        public CartItemDto MapToDto(CartItem item)
        {
            return new CartItemDto { Id = item.Id, Image = item.Image, Name = item.Name, Price = item.Price, Quantity = item.Quantity };
        }
        
        public CartItem MapToEntity(CartItemDto dto)
        {
            return new CartItem { Id = dto.Id, Image = dto.Image, Name = dto.Name, Price = dto.Price, Quantity = dto.Quantity };
        }
    }
}
