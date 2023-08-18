using MVCWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<Employee> emplist = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi");
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var elist = result.Content.ReadAsAsync<List<Employee>>();
                elist.Wait();
                emplist = elist.Result;
            }
            return View(emplist);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.PostAsJsonAsync("EmployeeApi", emp);
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int empid)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?empid=" + empid.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var em = result.Content.ReadAsAsync<Employee>();
                em.Wait();
                emp = em.Result;
            }
            return View(emp);
        }

        public ActionResult Edit(int empid)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?empid=" + empid.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var em = result.Content.ReadAsAsync<Employee>();
                em.Wait();
                emp = em.Result;
            }
            return View(emp);
        }
     
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.PutAsJsonAsync("EmployeeApi", emp);
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(int empid)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?empid=" + empid.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var em = result.Content.ReadAsAsync<Employee>();
                em.Wait();
                emp = em.Result;
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int empid)
        {
            client.BaseAddress = new Uri("https://localhost:44336/api/EmployeeApi");
            var response = client.DeleteAsync("EmployeeApi/"+ empid.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}