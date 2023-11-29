using ProyectoMVC.Models;

namespace ProyectoMVC.Servicios.Contratos
{
    public interface IAnimalService
    {
        Task<List<Animal>> ObtenerTodosLosAnimales();
        //Task<Animal> ObtenerAnimalPorId(int idAnimal);
        Task InsertarAnimal(Animal animal);
        //Task ActualizarAnimal(Animal animal);
        //Task EliminarAnimal(int idAnimal);
    }
}
