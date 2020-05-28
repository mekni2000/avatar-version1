using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	public enum SearchType
	{
		Like = 0,
		Equal = 1
	}

	[AttributeUsage(AttributeTargets.Property, Inherited = false)]
	public class SearchableAttribute : Attribute
	{
		public SearchType SearchTypeValue { get; set; }

		/// <summary>
		/// Make a property searchable From the filter
		/// </summary>
		/// <param name="searchType">the Search type , Like or Equal</param>
		public SearchableAttribute(SearchType searchType = 0)
		{
			this.SearchTypeValue = searchType;
		}
	}
}
