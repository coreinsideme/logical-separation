using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.BLL.Interfaces
{
    internal interface ICartMapper
    {
        CartDto MapToDto(Cart cart);
        Cart MapToEntity(CartDto dto);
    }
}
