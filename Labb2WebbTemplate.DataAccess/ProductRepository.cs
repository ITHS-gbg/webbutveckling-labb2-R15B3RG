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

			if (newProduct.Name != String.Empty)
			{
				oldProduct.Name = newProduct.Name;
			}

			if (newProduct.Description != String.Empty)
			{
				oldProduct.Description = newProduct.Description;
			}

			if (newProduct.Price != 0)
			{
				oldProduct.Price = newProduct.Price;
			}

			if (newProduct.Inventory > -1)
			{
				oldProduct.Inventory = newProduct.Inventory;
			}

			if (newProduct.InventoryBalance != true)
			{
				oldProduct.InventoryBalance = newProduct.InventoryBalance;
			}

			if (newProduct.ProductType != String.Empty)
			{
				oldProduct.ProductType = newProduct.ProductType;
			}
			
			
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

