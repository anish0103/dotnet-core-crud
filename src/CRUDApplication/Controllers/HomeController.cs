using CRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace CRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        MongoClient client = new MongoClient("mongodb+srv://Anish_1031:IVudoVcIIOtNgXnw@cluster0.j1elb.mongodb.net/?retryWrites=true&w=majority");

        private readonly ILogger<HomeController> _logger;

        private List<Customer> CustomerList = new List<Customer>();

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            var customerList = client.GetDatabase("DotNetCoreCRUD").GetCollection<Customer>("customerList");
            CustomerList = customerList.Find(new BsonDocument()).ToList();
            return View(CustomerList);
        }

        public IActionResult Edit(string? id)
        {
            var customerList = client.GetDatabase("DotNetCoreCRUD").GetCollection<Customer>("customerList");
            CustomerList = customerList.Find(new BsonDocument()).ToList();
            var model = CustomerList.Find(x => x._id.ToString() == id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customerobj, string? id)
        {
            if (ModelState.IsValid)
            {
                var customerList = client.GetDatabase("DotNetCoreCRUD").GetCollection<Customer>("customerList");
                customerobj._id = ObjectId.Parse(id);
                await customerList.ReplaceOneAsync(c => c._id == ObjectId.Parse(id), customerobj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customerobj)
        {
            if (ModelState.IsValid)
            {
                var customerList = client.GetDatabase("DotNetCoreCRUD").GetCollection<Customer>("customerList");
                customerList.InsertOne(customerobj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var customerList = client.GetDatabase("DotNetCoreCRUD").GetCollection<Customer>("customerList");
            await customerList.DeleteOneAsync(c => c._id == ObjectId.Parse(id));
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}