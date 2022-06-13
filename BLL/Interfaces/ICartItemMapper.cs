using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.BLL.Interfaces
{
    internal interface ICartItemMapper
    {
        CartItemDto MapToDto(CartItem item);
        CartItem MapToEntity(CartItemDto dto);
    }
}
