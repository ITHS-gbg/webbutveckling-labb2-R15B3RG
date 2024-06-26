﻿namespace Labb2WebbTemplate.shared.Entities;

public class Product
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public double Price { get; set; }

	public string ProductType { get; set; }

	public int Inventory { get; set; }

	public bool InventoryBalance { get; set; }

}