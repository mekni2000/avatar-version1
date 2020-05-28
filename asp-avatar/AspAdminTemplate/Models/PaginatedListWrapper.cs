using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Models
{
	public class PaginatedListWrapper<T>
	{
		public List<T> PaginatedList { get; set; }
		public string Previous { get; set; }
		public string Current { get; set; }
		public string Next { get; set; }

		public string TotalPages { get; set; }
		public string ResultsCount { get; set; }
	}
}
