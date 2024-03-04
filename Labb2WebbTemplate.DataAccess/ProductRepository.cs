using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess.Entities;

namespace Labb2WebbTemplate.DataAccess
{
	public class ProductRepository(CustomerProductOrderDbContext context)
	{
		public async Task AddProduct(Product newProduct)
		{
			await context.Products.AddAsync(newProduct);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return context.Products;
		}

		public async Task<Product> GetProductById(int id)
		{
			return await context.Products.FindAsync(id);
		}

		public async Task UpdateProductName(int id, string name)
		{
			var oldProduct = await context.Products.FindAsync(id);
			if (oldProduct is null)
			{
				return;
			}
			oldProduct.Name = name;
			await context.SaveChangesAsync();
		}
	}
}

