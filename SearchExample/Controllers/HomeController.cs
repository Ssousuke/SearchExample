using Microsoft.AspNetCore.Mvc;
using SearchExample.Models;
using System.Collections;

namespace SearchExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<UserModel> model = GetUsers();
            return View(model.ToList());
        }
        public PartialViewResult SearchUsers(string searchString)
        {
            var model = GetUsers();
            if (searchString != null)
            {
                var result = model.Where(a => a.Name.ToLower().Contains(searchString) || a.Age.ToString().Contains(searchString));
                return PartialView("_GridView", result);
            }

            return PartialView("_GridView", model);
        }
        public List<UserModel> GetUsers()
        {
            var users = new List<UserModel>
            {
                new UserModel { Id= 1, Name="Um Nome Grande", Age = 23},
                new UserModel { Id= 2, Name="Um Nome Maior Ainda", Age = 20},
                new UserModel { Id= 3, Name="Um Nome Maior Que O Anterior", Age = 19},
            };
            return users.ToList();
        }
    }
}
