using System.Collections.Generic;

using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.BLL.Interfaces
{
    public interface ICartService
    {
        void Create(int id);

        CartDto GetCart(int cartId);

        IReadOnlyCollection<CartItemDto> GetItems(int cartId);

        void AddItem(int cartId, CartItemDto item);

        void RemoveItem(int cartId, int itemId);
    }
}
