using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AnimalesController : Controller
    {
        public IActionResult Index()
        {
            List<Animal> listAnimals = new List<Animal>()
            {
                new Animal() { IdAnimal =1, Nombre = "Gato"},
                new Animal() { IdAnimal = 2, Nombre = "Perro" },
                new Animal() { IdAnimal = 3, Nombre = "Conejo" },
                new Animal() { IdAnimal = 4, Nombre = "Hamster" },
            };
            return View(listAnimals);
        }

    }
}
