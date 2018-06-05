using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du patient est requis.")]
        [StringLength(55)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom du patient est requis.")]
        [StringLength(55)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Date de naissance requise.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Email du patient requis.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int? TelFixe { get; set; }

        [Display(Name = "Gsm")]
        public int? Gsm { get; set; }

        [StringLength(55)]
        public string PersonneContact { get; set; }

        public int? TelContact { get; set; }

        [Required(ErrorMessage = "Anamnèse requise.")]
        [StringLength(2000)]
        public string Anamnèse { get; set; }

        [StringLength(250)]
        public string Commentaire { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }

        [ForeignKey("Lateralite")]
        public int LateraliteId { get; set; }

    }
}