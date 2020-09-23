using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HospitalWard.Models;

namespace HospitalWard.Controllers
{
    public class DoctorsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DoctorsAPI
        public IQueryable<Doctor> GetDoctorList()
        {
            return db.DoctorList;
        }

        // GET: api/DoctorsAPI/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult GetDoctor(int id)
        {
            Doctor doctor = db.DoctorList.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/DoctorsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.ID)
            {
                return BadRequest();
            }

            db.Entry(doctor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DoctorsAPI
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoctorList.Add(doctor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctor.ID }, doctor);
        }

        // DELETE: api/DoctorsAPI/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult DeleteDoctor(int id)
        {
            Doctor doctor = db.DoctorList.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            db.DoctorList.Remove(doctor);
            db.SaveChanges();

            return Ok(doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorExists(int id)
        {
            return db.DoctorList.Count(e => e.ID == id) > 0;
        }
    }
}