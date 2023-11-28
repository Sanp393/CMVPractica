using Microsoft.AspNetCore.Mvc;

namespace ProyectoMVC.ViewComponents
{
    public class InteractivoTiposAnimalesViewComponents : ViewComponent
    {

        Dictionary<string, string> tiposAnimal = new Dictionary<string, string>();

        public IViewComponentResult Invoke()
        {
            Dictionary<string, string> tiposAnimal = new Dictionary<string, string>()
            {
                {
                    "Peces", "Los Peces son"
                },
                {
                    "Perros", "Los Perros son"
                },
                {
                    "Gatos", "Los Gatos son"
                },
                {
                    "Pajaros", "Los Pajaros son"
                }
            };

            return View(tiposAnimal);
        }
    }
}
