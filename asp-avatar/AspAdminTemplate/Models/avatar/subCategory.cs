using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Models.avatar
{
    public class subCategory
    {
        public int id { get; set; }
        public string Nom { get; set; }
        [DataType(DataType.Date)]
        public string miseAjour { get; set; }
        public string Telechargement { get; set; }

        public string FileUrl { get; set; }
        public category Category { get; set; }
    }
}
