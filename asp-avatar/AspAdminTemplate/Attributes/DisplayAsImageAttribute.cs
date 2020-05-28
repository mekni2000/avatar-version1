using AspAdminTemplate.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class DisplayAsImageAttribute : Attribute
	{
		public string BaseUrl { get; set; }
		public ImageBackground ImageBackground { get; set; }
	}
}
