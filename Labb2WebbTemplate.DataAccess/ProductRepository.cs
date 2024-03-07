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

		public async Task UpdateProduct(int id, Product newProduct)
		{
			var oldProduct = await context.Products.FindAsync(id);
			if (oldProduct is null)
			{
				return;
			}
			oldProduct.Name = newProduct.Name;
			oldProduct.Description = newProduct.Description;
			oldProduct.Price = newProduct.Price;
			oldProduct.Inventory = newProduct.Inventory;
			oldProduct.ProductType = newProduct.ProductType;
			oldProduct.InventoryBalance = newProduct.InventoryBalance;
			await context.SaveChangesAsync();
		}

		public async Task DeleteProduct(int id)
		{
			var selectedProduct = await context.Products.FindAsync(id);

			if (selectedProduct is null)
			{
				return;
			}

			context.Products.Remove(selectedProduct);
			await context.SaveChangesAsync();
			
		}
	}
}

