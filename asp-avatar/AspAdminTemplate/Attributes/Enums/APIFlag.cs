using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes.Enums
{
	[Flags]
	public enum APIFlag
	{
		Get = 1 << 0,
		List = 1 << 1,
		Paginated = 1 << 2,
		Post = 1 << 3,
		Delete = 1 << 4,
		Patch = 1 << 5,
		Put = 1 << 6,
		Get_Delete = Get | Delete,
		Get_Delete_Put = Get_Delete | Put,
		List_Post = List | Post,
		Paginated_Post = Paginated | Post,
		All = Get | Post | Delete | Patch | Put | Paginated
	}
}
