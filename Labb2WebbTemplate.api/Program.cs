using Labb2WebbTemplate.DataAccess;
using Labb2WebbTemplate.DataAccess.Entities;
using System;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CustomerProductOrderDb");

builder.Services.AddDbContext<CustomerProductOrderDbContext>(

	options => 
		
		options.UseSqlServer(connectionString)

);

//builder.Services.AddSingleton<ProductRepository>();
//builder.Services.AddSingleton<CustomerRepository>();

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();

var app = builder.Build();

app.MapGet("/products", async (ProductRepository repo) =>  //Detta är nu ändrat. Fortsätt nedtill med Niklas
{
	return await repo.GetAllProducts();
});

app.MapGet("/products/{id:int}", async(ProductRepository repo, int id) =>
{
	var product = await repo.GetProductById(id); // <------ Ska det finnas en Async och en Await här????????

	if (product is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No product exists with the given Id: {id}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(product);
});

app.MapPost("/products", async (ProductRepository repo, Product newProduct) =>
{
	var existingProduct = await repo.GetProductById(newProduct.Id);

	if (existingProduct is not null)
	{
		return Results.BadRequest($"A product is already registered with the id: {newProduct.Id}");
	}

	await repo.AddProduct(newProduct);

	return Results.Ok();
});

app.MapPut("/products/{id}", async(ProductRepository repo, int id, Product prod) =>
{
	await repo.UpdateProduct(id, prod);

	return Results.Ok();

});

app.MapDelete("/products/{id}", async(ProductRepository repo, int id) =>
{
	await repo.DeleteProduct(id);

	return Results.Ok();

});

//------------------------------------------------------------------------------------------------------------

app.MapGet("/customers", async (CustomerRepository repo) => 
{
	return await repo.GetAllCustomers();
});


app.MapGet("/customers/{id:int}", async (CustomerRepository repo, int id) =>
{
	var customer = await repo.GetCustomerById(id);

	if (customer is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No customer exists with the given Id: {id}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(customer);
});

app.MapPost("/customers", async(CustomerRepository repo, Customer newCustomer) =>
{
	var existingCustomer = await repo.GetCustomerById(newCustomer.Id);

	if (existingCustomer is not null)
	{
		return Results.BadRequest($"Customer with the Id: {newCustomer.Id} already exists");
	}

	await repo.AddCustomer(newCustomer);

	return Results.Ok();

});

app.MapPut("/customers/{id}", async (CustomerRepository repo, int id, Customer customer) =>
{
	await repo.UpdateCustomer(id, customer);

	return Results.Ok();

});

app.MapGet("/customers/{email}", async (CustomerRepository repo, string email) =>
{
	var customer = await repo.GetCustomerByEmail(email);

	if (customer is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No customer exists with the given Email: {email}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(customer);
});

//---------------------------------------------------------------------------------

app.MapPost("/orders", async (OrderRepository repo, CreateOrderDto createOrderDto) =>
{
	var newOrder = await repo.CreateOrder(createOrderDto);

	if (newOrder is null)
	{
		return Results.BadRequest("Failed to create order");
	}

	return Results.Ok();
});

app.MapGet("/orders/{id:int}", async (OrderRepository repo, int id) =>
{
	var order = await repo.GetOrderById(id);

	if (order is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No order exists with the given Id: {id}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(order);
});

app.Run();
