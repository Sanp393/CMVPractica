using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ProyectoMVC.Models;
using ProyectoMVC.Servicios.Configuracion;
using ProyectoMVC.Servicios.Contratos;

namespace ProyectoMVC.Servicios.Implementacion
{
    public class AnimalService : IAnimalService
    {
        private readonly ConfiguracionConexion _conexion;

        public AnimalService(IOptions<ConfiguracionConexion> conexion)
        {
            _conexion = conexion.Value;
        }
        public async Task InsertarAnimal(Animal animal)
        {
            using SqlConnection connection = new SqlConnection(_conexion.ConexionBBDD);
            {
                string query = "INSERT INTO Animal (NombreAnimal, Raza, RIdTipoAnimal, FechaNacimiento) " +
                    "VALUES (@NombreAnimal, @Raza, @RIdTipoAnimal, @FechaNacimiento)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreAnimal", animal.NombreAnimal);
                    command.Parameters.AddWithValue("@Raza", animal.Raza);
                    command.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);
                    command.Parameters.AddWithValue("@FechaNacimiento", (object)animal.FechaNacimiento ?? DBNull.Value);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Animal>> ObtenerTodosLosAnimales()
        {
            List<Animal> animales = new List<Animal>();

            using (SqlConnection connection = new SqlConnection(_conexion.ConexionBBDD))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Animal", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Animal animal = new Animal
                            {
                                IdAnimal = (int)reader["IdAnimal"],
                                NombreAnimal = reader["NombreAnimal"].ToString(),
                                Raza = reader["Raza"].ToString(),
                                RIdTipoAnimal = (int)reader["RIdTipoAnimal"],
                                FechaNacimiento = reader["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimiento"]) : null
                            };

                            animales.Add(animal);
                        }
                    }
                }
            }
            return animales;
        }
    }
}
