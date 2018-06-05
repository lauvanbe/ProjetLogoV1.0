using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using ProjetLogoV1._0.Dtos;
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
 
        public ViewResult Index()
        {

            var patients = _context.Patients.Include(a => a.Adresse).Include(l => l.Lateralite).ToList();
            if (User.IsInRole(NomRole.CanManagePatients))
            {
                return View("index", patients);
            }
            
             return View("ReadOnlyPatient", patients);
            
 
        }

        [Route("DetailPatient/{id}")]
        public ActionResult DetailPatient(int id)
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
                Patient = new Patient(),
                Lateralites = lateralite
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewPatientViewModel
                {
                    Patient = patient,
                    Lateralites = _context.Lateralites.ToList()
                };

                return View("AjoutPatient", viewModel);
            }

            if (patient.Id == 0)
            {
                _context.Patients.Add(patient);
            }
            else
            {
                var patientInDb = _context.Patients.Include(a => a.Adresse).Single(p => p.Id == patient.Id);

                Mapper.Map(patientInDb, patient);

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }

        public ActionResult EditerPatient(int id)
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