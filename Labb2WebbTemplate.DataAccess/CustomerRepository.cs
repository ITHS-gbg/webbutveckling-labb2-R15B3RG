﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2WebbTemplate.DataAccess.Entities;

namespace Labb2WebbTemplate.DataAccess
{
	public class CustomerRepository
	{

		public List<Customer> Customers { get; set; } = new();
	}
}
