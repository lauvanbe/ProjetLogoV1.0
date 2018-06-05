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
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/patients
        public IEnumerable<PatientDto> GetPatients()
        {
            return _context.Patients.ToList().Select(Mapper.Map<Patient, PatientDto>);
        }

        // GET /api/patients/1

        public IHttpActionResult GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Patient, PatientDto>(patient));
        }

        // POST /api/patients

        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.Id = patient.Id;

            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientDto);
        }

        // PUT /api/patients/1

        [HttpPut]
        public void UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(patientDto, patientInDb);

            _context.SaveChanges();
        }

        // DELETE /api/patients/1

        [HttpDelete]
        public void DeletePatient(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();
        }
    }
}
