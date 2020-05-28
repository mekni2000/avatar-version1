using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes.Enums
{
	[Flags]
	public enum CRUDFlag
	{
		None = 0,
		Create	= 1 << 0,
		Edit	= 1 << 1,
		Delete	= 1 << 2,
		Details	= 1 << 3,
		All = Create | Edit | Delete | Details
	}
}
