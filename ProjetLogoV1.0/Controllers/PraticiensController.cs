using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetLogoV1._0.Models;
using ProjetLogoV1._0.ViewModels;

namespace ProjetLogoV1._0.Controllers
{
    public class PraticiensController : Controller
    {
        private ApplicationDbContext _context;

        public PraticiensController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Praticien

        public ViewResult Index()
        {
            var praticien = _context.Praticiens.Include(a => a.Adresse).Include(s => s.Specialisation).Include(f => f.Fonction).ToList();

            if (User.IsInRole(NomRole.CanManagePatients))
            {
                return View("Index", praticien);
            }
            return View("ReadOnlyPraticien", praticien);
        }

        [Route("DetailPraticien/{id}")]
        public ActionResult DetailPraticien(int id)
        {
            var praticien = _context.Praticiens.Include(a => a.Adresse).Include(s => s.Specialisation).Include(f => f.Fonction).SingleOrDefault(p => p.Id == id);

            if (praticien == null)
            {
                return HttpNotFound();
            }
            return View(praticien);
        }

        [Route("AjoutPraticien")]
        public ActionResult AjoutPraticien()
        {

            var viewModel = new NewPraticienViewModel
            {
                Praticien = new Praticien(),
                Fonction = new Fonction(),
                Specialisation = new Specialisation()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Praticien praticien, Fonction fonction, Specialisation specialisation)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewPraticienViewModel
                {
                    Praticien = praticien,
                    Fonction = fonction,
                    Specialisation = specialisation
                };

                return View("AjoutPraticien", viewModel);
            }

            if (praticien.Id == 0)
            {
                _context.Praticiens.Add(praticien);
            }
            else
            {
                var praticienInDb = _context.Praticiens.Include(a => a.Adresse).Single(p => p.Id == praticien.Id);

                Mapper.Map(praticienInDb, praticien);

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Praticiens");
        }
    }
}