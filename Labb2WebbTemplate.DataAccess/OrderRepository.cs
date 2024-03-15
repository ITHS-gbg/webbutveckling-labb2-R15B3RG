using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.DataAccess
{
	public class OrderRepository
	{
		private readonly CustomerProductOrderDbContext context;

		public OrderRepository(CustomerProductOrderDbContext dbContext)
		{
			context = dbContext;
		}

		public async Task<Order?> CreateOrder(CreateOrderDto createOrderDto)
		{
			// Skapa en ny order baserat på uppgifterna i DTO:n
			var order = new Order
			{
				CustomerId = createOrderDto.CustomerId,
				CreatedDate = DateTime.Now
			};

			// Loopa igenom varje produkt-ID i listan från DTO:n
			foreach (var productId in createOrderDto.ProductIds)
			{
				// Hämta produktobjektet från databasen baserat på produkt-ID
				var product = await context.Products.FindAsync(productId);
				if (product != null)
				{
					// Lägg till produkten i orderns lista över produkter
					order.Products.Add(product);
				}
			}

			// Lägg till den nya ordern i databasen och spara ändringar
			context.Orders.Add(order);
			await context.SaveChangesAsync();

			return order;
		}

		public async Task<Order?> GetOrderById(int id)
		{
			return await context.Orders
				.Include(o => o.Products) // Inkludera produkter för den specifika ordern
				.FirstOrDefaultAsync(o => o.OrderId == id);
		}
	}

}
