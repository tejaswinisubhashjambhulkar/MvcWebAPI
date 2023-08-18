using MVCWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebAPI.Controllers
{
    public class EmployeeApiController : ApiController
    {
        TestDBEntities _dbcontext = new TestDBEntities();
        
        
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {      
            List<Employee> emplist = _dbcontext.Employees.ToList();
            return Ok(emplist);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int empid)
        {
            var emp = _dbcontext.Employees.Where(x =>x.empid == empid).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee emp)
        {
            _dbcontext.Employees.Add(emp);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(Employee emp)
        {
            _dbcontext.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            _dbcontext.SaveChanges();
            //var eObj = _dbcontext.Employees.Where(x => x.empid == emp.empid).FirstOrDefault();
            //if (eObj != null)
            //{
            //    eObj.empid = emp.empid;
            //    eObj.name = emp.name;
            //    eObj.email = emp.email;
            //    eObj.contact = emp.contact;
            //    eObj.address = emp.address;
            //    eObj.isactive = emp.isactive;

            //    _dbcontext.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int empid)
        {
            var emp = _dbcontext.Employees.Where(x => x.empid == empid).FirstOrDefault();
            _dbcontext.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
