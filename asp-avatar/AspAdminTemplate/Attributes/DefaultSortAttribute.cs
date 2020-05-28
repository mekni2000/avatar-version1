using AspAdminTemplate.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class DefaultSortAttribute :Attribute
	{
		public SortType SortType { get; set; }

		public DefaultSortAttribute(SortType sortType=SortType.Asc)
		{
			SortType = sortType;
		}
	}
}
