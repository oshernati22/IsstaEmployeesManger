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
using System.Web.Mvc;
using MoveoTaskOsherNati.Models;

namespace MoveoTaskOsherNati.Controllers
{
   
    public class EmployeesApiController : ApiController // api for our client 
    {
        private MyDB db = new MyDB();

        // GET: api/EmployeesApi
        public HttpResponseMessage GetEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Employee);
        }

        // GET: api/EmployeesApi/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        private double GetBusinessDays(DateTime startD, DateTime endD) // function that calc how many days the employee was work this month until now
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Friday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;


            return calcBusinessDays;
        }

        [System.Web.Http.HttpPost]
        [ResponseType(typeof(double))]
        public IHttpActionResult CalculateSalary(Employee employee) //function that calc salry until now
        {
            var endD = DateTime.Today;
            var startD = new DateTime(endD.Year, endD.Month, 1);
            var workingDays = GetBusinessDays(startD, endD);
            double salary = 0;
            switch (employee.type)
            {
                case Level.Manager:
                    salary = employee.baseSalary + 1000 + 50 * workingDays;
                    break;
                case Level.Junior:
                    salary = employee.baseSalary;
                    break;
                case Level.Senior:
                    salary = employee.baseSalary + 30 * workingDays;
                    break;
            }

            return Ok(salary);


        }

        // PUT: api/EmployeesApi/5
        [ResponseType(typeof(void))]
        public string PutEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return "NOT VALID";
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.ID))
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }

            return "Edit Succesfully";
        }

        // POST: api/EmployeesApi
        [System.Web.Http.HttpPost]
        public string PostEmployee([FromBody]Employee employee)
        {
            Console.WriteLine("im here");
            if (!ModelState.IsValid)
            {
                return "not valid";
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return "Added Succesfully !!";
        }

        // DELETE: api/EmployeesApi/5
           [System.Web.Http.HttpPost]
        public string DeleteEmployee([FromBody]Employee employee)
        {
           
            if (employee == null)
            {
                return "Not Found";
            }

            db.Employee.Attach(employee);
            db.Employee.Remove(employee);
            db.SaveChanges();

            return "Deleted Succesfully";
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.ID == id) > 0;
        }
    }
}