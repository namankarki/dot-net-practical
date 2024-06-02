using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Practical.Models;
using Practical.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Practical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDependency _dependency;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IDependency dependency)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _dependency = dependency;
        }

        public IActionResult Index()

        {
            TempData["Smokes"] = "Clove";
            TempData.Keep("Smokes");
           var message= _dependency.setValue();
            ViewBag.Message = message;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.initiator = "Sova";
            ViewData["Agent"] = "Raze";
            return View();
        }

        //Different Return Types of Controller Action Methods

        //redirect result
        public IActionResult RedirectToAnotherAction()
        {
            TempData["message"] = "This is the message after redirection";
            return RedirectToAction("Error", "home");
        }

        //json result
        public IActionResult ReturnJsonData()
        {
            var data = new { Name= "Naman Bikram Karki", Age = 22};
            return Json(data);
        }
        //plain text

        public IActionResult PlainText()
        {
            return Content("THIS IS A PLAINTEXT", "text/plain");
        }

        //show partial
        public IActionResult Partial()
        {
            return PartialView("_Partialview");
        } 

        public IActionResult DownloadFile()
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "myfile.txt");
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "application/pdf", "myfile.txt");
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
