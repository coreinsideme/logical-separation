using System.Collections.Generic;
using LogicalSeparation.DAL.Common;

namespace LogicalSeparation.DAL.Entities
{
	public class Cart: BaseEntity
	{
		public List<CartItem> Items { get; set; } = new List<CartItem>();
	}
}
