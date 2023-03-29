using ListPeople.Web.Models;
using LIstPeople.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People; Integrated Security=true;";
        public IActionResult Index()
        {
            var pm = new PeopleManager(connectionString);
            var vm = new ViewModel();
            vm.People = pm.GetAll();

            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            var pm = new PeopleManager(connectionString);
            pm.AddManyPeople(people);
            var correctGrammar = people.Count == 1 ? "person has" : "people have";
            TempData["message"] = $"{people.Count} {correctGrammar} been added!";
            return Redirect("/home/index");
        }

    }
}