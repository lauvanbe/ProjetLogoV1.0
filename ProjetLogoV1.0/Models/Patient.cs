using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetLogoV1._0.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du patient est requis.")]
        [StringLength(55)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom du patient est requis.")]
        [StringLength(55)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Date de naissance requise.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Email du patient requis.")]
        [Display(Name = "Adresse Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Téléphone fixe")]
        public int? TelFixe { get; set; }

        [Display(Name = "Gsm")]
        public int? Gsm { get; set; }

        [StringLength(55)]
        [Display(Name = "Personne de contact")]
        public string PersonneContact { get; set; }

        [Display(Name = "Téléphone personne de contact")]
        public int? TelContact { get; set; }

        [Required(ErrorMessage = "Anamnèse requise.")]
        [StringLength(2000)]
        [Display(Name = "Anamnèse")]
        public string Anamnèse { get; set; }

        [StringLength(250)]
        [Display(Name = "Commentaire")]
        public string Commentaire { get; set; }

        public Adresse Adresse { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }

        public Lateralite Lateralite { get; set; }

        [ForeignKey("Lateralite")]
        public int LateraliteId { get; set; }

    }
}