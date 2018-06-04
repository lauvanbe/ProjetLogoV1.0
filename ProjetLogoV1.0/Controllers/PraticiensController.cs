using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetLogoV1._0.Models;

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
            var praticien = _context.Praticiens.Include(a => a.Adresse).Include(s => s.Specialisation).ToList();

            if (User.IsInRole(NomRole.CanManagePatients))
            {
                return View("Index", praticien);
            }
            return View("ReadOnlyPraticien", praticien);
        }
    }
}