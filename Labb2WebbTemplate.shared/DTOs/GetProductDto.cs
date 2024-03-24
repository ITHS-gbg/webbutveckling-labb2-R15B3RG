using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2WebbTemplate.shared.DTOs
{
    public class GetProductDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public string ProductType { get; set; }

		public int Inventory { get; set; }

		public bool InventoryBalance { get; set; }
	}
}
