using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;
using ProyectoMVC.Servicios.Contratos;

namespace ProyectoMVC.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly IAnimalService _ServicioAnimal;
        private readonly ITipoAnimalService _ServicioTipoAnimal;

        public AnimalesController(IAnimalService servicioAnimal, ITipoAnimalService servicioTipoAnimal)
        {
            _ServicioAnimal = servicioAnimal;
            _ServicioTipoAnimal = servicioTipoAnimal;
        }

        public async IActionResult Index()
        {
            ViewBag.Test = "Test ViewBag";
            List<Animal> listAnimals = new List<Animal>()
            /*{
                new Animal() { IdAnimal =1, NombreAnimal = "Gato"},
                new Animal() { IdAnimal = 2, NombreAnimal = "Perro" },
                new Animal() { IdAnimal = 3, NombreAnimal = "Conejo" },
                new Animal() { IdAnimal = 4, NombreAnimal = "Hamster" },
            }*/;
            listAnimals = await _ServicioAnimal.ObtenerTodosLosAnimales();
            var tiposAnimales = await _ServicioTipoAnimal.ObtenerTodosLosTiposDeAnimal();
            Random rmd = new Random();
            int numeroAleatorio = rmd.Next(0, tiposAnimales.Count);

            ViewBag.AnimalAleatorio = "El animal es: " + listAnimals[numeroAleatorio].NombreAnimal;
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
