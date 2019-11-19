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
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    public class StudentMastersController : ApiController
    {
        private StudentAPIEntities db = new StudentAPIEntities();

        // GET: api/StudentMasters
        public IQueryable<StudentMaster> GetStudentMasters()
        {
            return db.StudentMasters;
        }

        // GET: api/StudentMasters/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult GetStudentMaster(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return Ok(studentMaster);
        }

        // PUT: api/StudentMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentMaster(int id, StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(studentMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMasterExists(id))
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

        // POST: api/StudentMasters
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult PostStudentMaster(StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentMasters.Add(studentMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentMaster.ID }, studentMaster);
        }

        // DELETE: api/StudentMasters/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult DeleteStudentMaster(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            db.StudentMasters.Remove(studentMaster);
            db.SaveChanges();

            return Ok(studentMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentMasterExists(int id)
        {
            return db.StudentMasters.Count(e => e.ID == id) > 0;
        }
    }
}