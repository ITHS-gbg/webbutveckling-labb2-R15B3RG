using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
			var order = new Order
			{
				CustomerId = createOrderDto.CustomerId,
				CreatedDate = DateTime.Now
			};

			foreach (var productId in createOrderDto.ProductIds)
			{
				
				var product = await context.Products.FindAsync(productId);
				if (product != null)
				{
					
					order.Products.Add(product);
				}
			}

	
			context.Orders.Add(order);
			await context.SaveChangesAsync();

			return order;
		}

		public async Task<Order?> GetOrderById(int id)
		{
			return await context.Orders
				.Include(o => o.Products) 
				.Include(o => o.Customer)
				.FirstOrDefaultAsync(o => o.OrderId == id);
				
		}
	}

}
