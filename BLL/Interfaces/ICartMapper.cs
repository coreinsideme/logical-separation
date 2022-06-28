using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.BLL.Interfaces
{
    public interface ICartMapper
    {
        CartDto MapToDto(Cart cart);
        Cart MapToEntity(CartDto dto);
    }
}
