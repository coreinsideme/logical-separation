using LogicalSeparation.DAL.Common;

namespace LogicalSeparation.DAL.Entities
{
	public class CartItem: BaseEntity
	{
		public string Name { get; set; }

		public Image Image { get; set; }

		public decimal Price { get; set; }

		public uint Quantity { get; set; }
	}
}
