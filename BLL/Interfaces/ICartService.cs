using System.Collections.Generic;

using LogicalSeparation.DAL.Entities;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.BLL.Interfaces
{
    internal interface ICartService
    {
        void Create(int id);

        IReadOnlyCollection<CartItemDto> GetItems(int cartId);

        void AddItem(int cartId, CartItemDto item);

        void RemoveItem(int cartId, int itemId);
    }
}
