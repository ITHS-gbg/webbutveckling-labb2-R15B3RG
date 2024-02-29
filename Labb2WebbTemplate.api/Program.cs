using Labb2WebbTemplate.DataAccess;
using Labb2WebbTemplate.DataAccess.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<CustomerRepository>();

var app = builder.Build();

app.MapGet("/products", (ProductRepository repo) =>
{
	return repo.Products;
});

app.MapGet("/products/{id:int}", (ProductRepository repo, int id) =>
{
	var product = repo.Products.FirstOrDefault(p => p.Id == id);

	if (product is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No pet exists with the given Id: {id}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(product);
});

app.MapPost("/products", (ProductRepository repo, Product newProduct) =>
{

	if (repo.Products.Any(p => p.Id == newProduct.Id))
	{
		return Results.BadRequest($"A product is already registered with the id: {newProduct.Id}");
	}

	repo.Products.Add(newProduct);

	return Results.Ok();

});

//------------------------------------------------------------------------------------------------------------

app.MapGet("/customers", (CustomerRepository repo) => 
{
	return repo.Customers;
});


app.MapGet("/customers/{id:int}", (CustomerRepository repo, int id) =>
{
	var customer = repo.Customers.FirstOrDefault(c => c.Id == id);

	if (customer is null) //Använd gärna alltid "is null" istället för "== null"
	{
		return Results.NotFound($"No customer exists with the given Id: {id}");  //Här vill vi INTE göra en ActionResult!
	}

	return Results.Ok(customer);
});

app.MapPost("/customers", (CustomerRepository repo, Customer newCustomer) =>
{

	if (repo.Customers.Any(c => c.Id == newCustomer.Id))
	{
		return Results.BadRequest($"Customer with the Id: {newCustomer.Id} already exists");
	}

	repo.Customers.Add(newCustomer);

	return Results.Ok();

});

app.Run();
