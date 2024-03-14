using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess;
using Labb2WebbTemplate.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

		public async Task UpdateCustomer(int id, Customer newCustomer)
		{
			var oldCustomer = await context.Customers.FindAsync(id);
			if (oldCustomer is null)
			{
				return;
			}

		if (newCustomer.FirstName != String.Empty)
		{
			oldCustomer.FirstName = newCustomer.FirstName;
		}

		if (newCustomer.LastName != String.Empty)
		{
			oldCustomer.LastName = newCustomer.LastName;
		}

		if (newCustomer.Email != String.Empty)
		{
			oldCustomer.Email = newCustomer.Email;
		}

		if (newCustomer.PhoneNumber != String.Empty)
		{
			oldCustomer.PhoneNumber = newCustomer.PhoneNumber;
		}

		if (newCustomer.Address != String.Empty)
		{
			oldCustomer.Address = newCustomer.Address;
		}

		await context.SaveChangesAsync();
		}

	public async Task<Customer?> GetCustomerByEmail(string email)
	{
		return await context.Customers.FirstOrDefaultAsync(c => c.Email == email);
	}
}

