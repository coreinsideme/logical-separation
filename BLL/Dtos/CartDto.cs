using System.Collections.Generic;

using LogicalSeparation.DAL.Entities;

namespace LogicalSeparation.BLL.Dtos
{
    internal class CartDto: Cart
    {
        public int Id { get; set; }

        public new List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
