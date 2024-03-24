using Labb2WebbTemplate.shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2WebbTemplate.shared.DTOs
{
	public class GetOrderDto
	{
		[Key]
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public DateTime CreatedDate { get; set; }
		public List<Product> Products { get; set; } = new();
	}
}
