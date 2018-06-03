using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetLogoV1._0.Models;
using ProjetLogoV1._0.ViewModels;

namespace ProjetLogoV1._0.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Patients
        public ActionResult Index()
        {
            var patients = _context.Patients.Include(a => a.Adresse).Include(l => l.Lateralite).ToList();

            return View(patients);
        }

        [Route("Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var patient = _context.Patients.Include(a => a.Adresse).Include(l => l.Lateralite).SingleOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [Route("AjoutPatient")]
        public ActionResult AjoutPatient()
        {
            var lateralite = _context.Lateralites.ToList();

            var viewModel = new NewPatientViewModel
            {
                Lateralites = lateralite
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            if (patient.Id == 0)
            {
                _context.Patients.Add(patient);
            }
            else
            {
                var patientInDb = _context.Patients.Include(a => a.Adresse).Single(p => p.Id == patient.Id);

                patientInDb.Nom = patient.Nom;
                patientInDb.Prenom = patient.Prenom;
                patientInDb.DateNaissance = patient.DateNaissance;
                patientInDb.Email = patient.Email;
                patientInDb.TelFixe = patient.TelFixe;
                patientInDb.Gsm = patient.Gsm;
                patientInDb.PersonneContact = patient.PersonneContact;
                patientInDb.TelContact = patient.TelContact;
                patientInDb.LateraliteId = patient.LateraliteId;
                patientInDb.Adresse.Rue = patient.Adresse.Rue;
                patientInDb.Adresse.NumeroRue = patient.Adresse.NumeroRue;
                patientInDb.Adresse.BoitePostal = patient.Adresse.BoitePostal;
                patientInDb.Adresse.CodePostal = patient.Adresse.CodePostal;
                patientInDb.Adresse.Ville = patient.Adresse.Ville;
                patientInDb.Adresse.Pays = patient.Adresse.Pays;
                patientInDb.Anamnèse = patient.Anamnèse;
                patientInDb.Commentaire = patient.Commentaire;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }

        public ActionResult Editer(int id)
        {
            var patient = _context.Patients.Include(a => a.Adresse).SingleOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewPatientViewModel
            {
                Patient = patient,
                Lateralites = _context.Lateralites.ToList()
            };
            return View(viewModel);
        }
    }
}