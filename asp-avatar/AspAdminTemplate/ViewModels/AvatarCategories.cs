using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.ViewModels
{
    public class AvatarCategories
    {
        public int id { get; set; }
        public string name { get; set; }
        public IFormFile avatar { get; set; }
        public string Avatar { get; set; }
    }
}
