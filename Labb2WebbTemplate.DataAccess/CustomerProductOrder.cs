using Microsoft.EntityFrameworkCore;
using System;
using Labb2WebbTemplate.shared.Entities;


namespace Labb2WebbTemplate.DataAccess;

public class CustomerProductOrderDbContext : DbContext
{

	public DbSet<Customer> Customers { get; set; }

	public DbSet<Product> Products { get; set; }

	public DbSet<Order> Orders { get; set; }

	public CustomerProductOrderDbContext(DbContextOptions options) : base(options)

	{


	}

}