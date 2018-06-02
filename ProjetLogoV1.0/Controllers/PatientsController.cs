using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetLogoV1._0.Models;

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
            return View();
        }
    }
}