using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Models.avatar
{
    public class forms
    {
        public int id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nom { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string NumeroAbonnement { get; set; }
        [Required]
        public string nomFilm { get; set; }
    }
}
