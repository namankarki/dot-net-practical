using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical.Models;

namespace Practical.Controllers
{
    public class UserDetails : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Naman");
            HttpContext.Session.SetString("Gender", "male");
            HttpContext.Session.SetString("Department", "CSIT");
            HttpContext.Session.SetInt32("Pay", 4500);

            return View();
        }

        public IActionResult Get()
        {
            Employee employee = new Employee()
            {
                Name = HttpContext.Session.GetString("Name"),   
                Gender= HttpContext.Session.GetString("Gender"),
                Department=HttpContext.Session.GetString("Department"),
                Pay= HttpContext.Session.GetInt32("Pay").Value
            };
            return View(employee);
        }
    }
}
