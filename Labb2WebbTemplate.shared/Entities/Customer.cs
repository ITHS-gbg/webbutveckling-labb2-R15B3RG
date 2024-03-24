using System.ComponentModel.DataAnnotations;

namespace Labb2WebbTemplate.shared.Entities;

public class Customer
{
	public int Id { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	[EmailAddress]
	public string Email { get; set; }

	[Phone]
	public string PhoneNumber { get; set; }

	public string Address { get; set; }
}