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
            CustomerList.Add(new Customer { Name= "Anish", Id = 1, Email = "anish@gmail.com" }) ;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(CustomerList);
        }

        public IActionResult Edit(int? id)
        {
            var model = CustomerList.Find(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Customer customerobj)
        {
            CustomerList.Add(customerobj);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customerobj)
        {
            customerobj.Id = CustomerList.Count + 1;
            CustomerList.Add(customerobj);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}