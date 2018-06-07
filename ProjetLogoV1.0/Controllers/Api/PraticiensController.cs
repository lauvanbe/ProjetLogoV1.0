using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ProjetLogoV1._0.Dtos;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.Controllers.Api
{
    public class PraticiensController : ApiController
    {
        private ApplicationDbContext _context;

        public PraticiensController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/praticiens

        public IEnumerable<PraticienDto> GetPraticiens()
        {
            return _context.Praticiens.ToList().Select(Mapper.Map<Praticien, PraticienDto>);
        }

        // GET /api/praticiens/1

        public IHttpActionResult GetPraticien(int id)
        {
            var praticien = _context.Praticiens.SingleOrDefault(p => p.Id == id);

            if (praticien == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Praticien, PraticienDto>(praticien));
        }

        // POST /api/praticiens

        [HttpPost]
        public IHttpActionResult CreatePraticien(PraticienDto praticienDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var praticien = Mapper.Map<PraticienDto, Praticien>(praticienDto);
            _context.Praticiens.Add(praticien);
            _context.SaveChanges();

            praticienDto.Id = praticien.Id;

            return Created(new Uri(Request.RequestUri + "/" + praticien.Id), praticienDto);
        }

        // PUT /api/praticiens/1

        [HttpPut]
        public void UpdatePraticien(int id, PraticienDto praticinDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var praticienInDb = _context.Praticiens.SingleOrDefault(p => p.Id == id);

            if (praticienInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(praticinDto, praticienInDb);

            _context.SaveChanges();
        }

        // DELETE /api/patients/1

        [HttpDelete]
        public void DeletePraticien(int id)
        {
            var praticienInDb = _context.Praticiens.SingleOrDefault(p => p.Id == id);

            if (praticienInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Praticiens.Remove(praticienInDb);
            _context.SaveChanges();
        }
    }
}
