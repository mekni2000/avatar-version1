using AspAdminTemplate.Models.avatar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.ViewModels
{
    public class categorySubCategories
    {
        public int id { get; set; }
        public string Nom { get; set; }
        [DataType(DataType.Date)]
        public string miseAjour { get; set; }
        [DataType(DataType.Upload)]

        public string Telechargement { get; set; }
        public int categorieid { get; set; }

        public List<category> Cat { get; set; }

        public IFormFile file { get; set; }
        public string FileUrl { get; set; }
    }
}
