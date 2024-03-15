using System.ComponentModel.DataAnnotations;

namespace Labb2WebbTemplate.DataAccess.Entities;

public class Order
{
	[Key]
	public int OrderId { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
	public DateTime CreatedDate { get; set; }
	public List<Product> Products { get; set; } = new ();
}