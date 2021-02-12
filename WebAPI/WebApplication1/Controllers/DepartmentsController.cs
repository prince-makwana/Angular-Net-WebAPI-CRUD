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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentsController : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: api/Departments
        public IQueryable<Department> GetDepartments()
        {
            return db.Departments;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }

            using (var ctx = new EmployeeDBEntities())
            {
                var existingDepartment = ctx.Departments.Where(d => d.DepartmentId == department.DepartmentId)
                                            .FirstOrDefault<Department>();
                if(existingDepartment != null)
                {
                    existingDepartment.DepartmentName = department.DepartmentName;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok("Updated Successfully!!!");
        }

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            db.SaveChanges();

            return Ok("Addedd Successfully!!");
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new EmployeeDBEntities())
            {
                var department = ctx.Departments
                    .Where(d => d.DepartmentId == id)
                    .FirstOrDefault();

                ctx.Entry(department).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok("Deleted Successfully!!!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.DepartmentId == id) > 0;
        }
    }
}