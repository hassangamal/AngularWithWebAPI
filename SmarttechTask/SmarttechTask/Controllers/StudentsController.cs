
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Smart.DAL;
using System.Collections.Generic;
using System.IO;
namespace SmarttechTask.Controllers
{
    public class StudentsController : ApiController
    {
        private Smart.DAL.AppContext db = new Smart.DAL.AppContext();

        // GET: api/Students
        [HttpGet]
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        // GET: api/Students/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var fileName = Path.GetFileName(student.Image); //getting only file name(ex-ganesh.jpg)  
            //var ext = Path.GetExtension(student.Image);
            //string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
            //string myfile = ext; //appending the name with id  
            //var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image"));
            //student.Image = path+student.Image;
            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}