using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class DisplayCRUDAttribute : Attribute
	{
		public bool Create { get; set; }
		public bool Details { get; set; }
		public bool Update { get; set; }
		public bool Delete { get; set; }

		public DisplayCRUDAttribute(bool create=true, bool details=true, bool update=true, bool delete=true)
		{
			Create = create;
			Details = details;
			Update = update;
			Delete = delete;
		}
	}
}
