using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class ComposedAttribute : Attribute
	{
		public ComposedAttribute()
		{
		}
	}
}
