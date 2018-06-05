using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetLogoV1._0.Models
{
    public class Fonction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la fonction est requis.")]
        [Display(Name = "Nom de la fonction")]
        [StringLength(55)]
        public string Nom { get; set; }
    }
}