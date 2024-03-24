namespace Labb2WebbTemplate.shared.DTOs;

public class CreateOrderDto
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; }
}