using ProyectoMVC.Models;

namespace ProyectoMVC.Servicios.Contratos
{
    public interface ITipoAnimalService
    {
        Task<List<TipoAnimal>> ObtenerTodosLosTiposDeAnimal();
        Task InsertarTipoAnimal(string tipo);
    }
}
