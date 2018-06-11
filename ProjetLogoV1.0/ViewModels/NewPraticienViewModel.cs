using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.ViewModels
{
    public class NewPraticienViewModel
    {
        public IEnumerable<Specialisation> Specialisations { get; set; }

        public IEnumerable<Fonction> Fonctions { get; set; }

        public Praticien Praticien { get; set; }
    }
}