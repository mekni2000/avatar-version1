using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Models
{
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole () : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

    }
}
