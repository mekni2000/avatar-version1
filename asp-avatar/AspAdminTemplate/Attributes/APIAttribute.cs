using AspAdminTemplate.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Class,AllowMultiple = true, Inherited = false)]
	public class APIAttribute: Attribute
	{
		public APIFlag ApiFlag { get; set; }
		public string BaseUrl { get; set; }
		public string Endpoint { get; set; }
		public Type RequestVM { get; set; }
		public Type CustomResponseVM { get; set; }
		public APIAttribute(APIFlag apiFlag,string baseUrl, string endpoint, Type requestVM = null, Type customResponseVM = null)
		{
			ApiFlag = apiFlag;
			BaseUrl = baseUrl;
			Endpoint = endpoint;
			RequestVM = requestVM;
			CustomResponseVM = customResponseVM;
		}
	}
}
