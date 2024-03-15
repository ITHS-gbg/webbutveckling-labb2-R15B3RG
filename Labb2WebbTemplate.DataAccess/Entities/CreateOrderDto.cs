namespace Labb2WebbTemplate.DataAccess.Entities;

public class CreateOrderDto
{
	public int CustomerId { get; set; }
	public List<int> ProductIds { get; set; }
}