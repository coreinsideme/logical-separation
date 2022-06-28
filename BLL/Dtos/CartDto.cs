using System.Collections.Generic;

using LogicalSeparation.DAL.Entities;

namespace LogicalSeparation.BLL.Dtos
{
    public class CartDto: Cart
    {
        public new List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
