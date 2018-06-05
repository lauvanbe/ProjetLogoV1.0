using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetLogoV1._0.Models
{
    public class Specialisation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la spécialisation est requis.")]
        [Display(Name = "Nom de la spécialisation")]
        [StringLength(55)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La description de la spécialisation est requise.")]
        [Display(Name = "Description de la spécialisation")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}