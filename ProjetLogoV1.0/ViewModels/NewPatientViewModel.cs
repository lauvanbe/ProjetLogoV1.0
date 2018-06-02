using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.ViewModels
{
    public class NewPatientViewModel
    {
        public IEnumerable<Lateralite> Lateralites { get; set; }
        public Patient Patient { get; set; }
    }
}