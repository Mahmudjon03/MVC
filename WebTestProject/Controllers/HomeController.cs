using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using WebTestProject.Models;
using WebTestProject.Services;

namespace WebTestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _service;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _service = new UserService();
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {

            var session = _contextAccessor.HttpContext.Session;

            session.SetString("Test", "Hello word!");

            var employees = _service.GetEmployee();
            foreach (var item in employees)
            {
                item.ses = session.GetString("Test");
            }
            if (employees == null)
            {
                return Error();
            }
            return View(employees);
        }
        //[HttpGet("Edit")]
        //public IActionResult Edit(int Id)
        //{

        //}
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var employees = _service.GetById(Id);

            return View(employees);
        }

        

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("Create")]
        public IActionResult Create(Employee employee )
        {
            if (employee.test) employee.fName ="checkbox working!"; 
            var result = _service.AddEmployee(employee);

            return RedirectToAction(nameof(Index), result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Delete(int id)
        {
            _service.Delete(id);

            RedirectToAction(nameof(Index));
        }
    }
}