using CRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<Customer> CustomerList;

        public HomeController(ILogger<HomeController> logger)
        {
            CustomerList = new List<Customer>();
            //{
            //    new Customer() { Id = 1, Email = "xyz@gmail.com", Name = "XYZ1 Name" },
            //    new Customer() { Id = 2, Email = "xyz2@gmail.com", Name = "XYZ2 Name" },
            //    new Customer() { Id = 3, Email = "xyz3@gmail.com", Name = "XYZ3 Name" }
            //};
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(CustomerList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}