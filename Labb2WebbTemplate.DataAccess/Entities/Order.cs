namespace Labb2WebbTemplate.DataAccess.Entities;

public class Order
{
	public int CustomerId { get; set; }

	public int ProductId { get; set; }

	public int OrderId { get; set; }

	public DateTime CreatedDate { get; set; }

	public List<Order> Orders { get; set; } = new();
}