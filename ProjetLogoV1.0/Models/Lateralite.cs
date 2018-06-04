using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetLogoV1._0.Models
{
    public class Lateralite
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Latéralité requise.")]
        [StringLength(55)]
        [Display(Name = "Latéralité")]
        public string nom { get; set; }

        public IList<Patient> Patients { get; set; }
    }
}