using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.Dtos
{
    public class PraticienDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro INAMI est requis.")]
        [Range(11, 11)]
        public int Inami { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(55)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(55)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Email du praticien requis.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int TelFixe { get; set; }

        public int Gsm { get; set; }

        [Required(ErrorMessage = "Veuillez spécifier si les déplacements sont possible.")]
        public bool Deplacement { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }

        [ForeignKey("Specialisation")]
        public int SpecialisationId { get; set; }

        [ForeignKey("Fonction")]
        public int FonctionId { get; set; }
    }
}