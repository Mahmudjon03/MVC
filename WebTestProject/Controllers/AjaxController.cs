using Microsoft.AspNetCore.Mvc;
using WebTestProject.Models;
using WebTestProject.Services;
using Newtonsoft.Json;


namespace WebTestProject.Controllers
{
    public class AjaxController
    {
        private readonly UserService _service;
        public AjaxController()
        {
            _service = new UserService();
        }
        public IActionResult EmployesAdd(Employee model)
        {
            var res = _service.AddEmployee(model);
            var json = JsonConvert.SerializeObject(res);
            return Json();
        }

    }
}
