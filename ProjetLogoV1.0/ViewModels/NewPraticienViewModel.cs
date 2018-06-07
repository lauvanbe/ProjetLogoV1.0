using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.ViewModels
{
    public class NewPraticienViewModel
    {
        public Specialisation Specialisation { get; set; }

        public Fonction Fonction { get; set; }

        public Praticien Praticien { get; set; }
    }
}