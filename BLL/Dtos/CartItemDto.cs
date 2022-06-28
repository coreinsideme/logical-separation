using LogicalSeparation.DAL.Entities;

namespace LogicalSeparation.BLL.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; } = null;

        public decimal Price { get; set; }

        public uint Quantity { get; set; }
    }
}
