using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ICT13580048EndB.Model
{
	public class Product
	{

		[NotNull]
		[MaxLength(100)]
		public string Carband { get; set; }
		public string Brand { get; set; }
		public String Genaration { get; set; }
		public int Years { get; set; }
		public String Mile { get; set; }
		public String Color { get; set; }
		public String Deler { get; set; }

		public String Tel { get; set; }
		public String Price { get; set; }
		public string Address { get; set; }

		[NotNull]
		[MaxLength(200)]
		public String Description
		{ get; set; }



	}
}
