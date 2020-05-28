using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class CompositionAttribute : Attribute
	{
		public string ForeignKey { get; set; }
		public string BaseUrl { get; set; }
		public string Endpoint { get; set; }
		public bool IsPaginated { get; set; } = false;

		public CompositionAttribute(string foreignKey)
		{
			ForeignKey = foreignKey;
		}
	}
}
