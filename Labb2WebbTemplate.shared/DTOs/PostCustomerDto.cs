using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2WebbTemplate.shared.DTOs
{
	public class PostCustomerDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

		public string Address { get; set; }
	}
}
