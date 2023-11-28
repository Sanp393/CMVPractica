using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AnimalesController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Test = "Test ViewBag";
            List<Animal> listAnimals = new List<Animal>()
            {
                new Animal() { IdAnimal =1, Nombre = "Gato"},
                new Animal() { IdAnimal = 2, Nombre = "Perro" },
                new Animal() { IdAnimal = 3, Nombre = "Conejo" },
                new Animal() { IdAnimal = 4, Nombre = "Hamster" },
            };
            Random rmd = new Random();
            int numeroAleatorio = rmd.Next(0, 4);
            ViewBag.AnimalAleatorio = "El animal aleatorio es: " + listAnimals[numeroAleatorio].Nombre;
            return View(listAnimals);

            
        }

        public IActionResult CrearAnimal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearAnimal(Animal nuevoAnimal)
        {
            return View(nuevoAnimal);
            
        }

        
        
    }
}
