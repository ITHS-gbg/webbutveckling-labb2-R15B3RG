using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess;
using Labb2WebbTemplate.DataAccess.Entities;

namespace Labb2WebbTemplate.DataAccess;

	public class CustomerRepository(CustomerProductOrderDbContext context)
	{
		public async Task<IEnumerable<Customer>> GetAllCustomers()
		{
			return context.Customers;
		}

		public async Task<Customer?> GetCustomerById(int id)
		{
			return await context.Customers.FindAsync(id);
		}

		public async Task AddCustomer(Customer newCustomer)
		{
			await context.Customers.AddAsync(newCustomer);
			await context.SaveChangesAsync();
		}

		public async Task UpdateCustomerName(int id, string name)
		{
			var oldCustomer = await context.Customers.FindAsync(id);
			if (oldCustomer is null)
			{
				return;
			}

			oldCustomer.FirstName = name;
			oldCustomer.LastName = name;
			await context.SaveChangesAsync();
		}
	}

