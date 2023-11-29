using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ProyectoMVC.Models;
using ProyectoMVC.Servicios.Configuracion;
using ProyectoMVC.Servicios.Contratos;

namespace ProyectoMVC.Servicios.Implementacion
{
    public class TipoAnimalService : ITipoAnimalService
    {
        private readonly ConfiguracionConexion _conexion;

        public TipoAnimalService(IOptions<ConfiguracionConexion> conexion)
        {
            _conexion = conexion.Value;
        }

        public async Task InsertarTipoAnimal(string tipo)
        {
            using SqlConnection connection = new SqlConnection(_conexion.ConexionBBDD);
            {
                string query = "INSERT INTO TipoAnimal (@TipoDescripcion)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TipoDescripcion", tipo.TipoDescripcion);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<TipoAnimal>> ObtenerTodosLosTiposDeAnimal()
        {
            List<TipoAnimal> tiposAnimales = new List<TipoAnimal>();

            using (SqlConnection connection = new SqlConnection(_conexion.ConexionBBDD))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TipoAnimal", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            TipoAnimal tipo = new TipoAnimal
                            {
                                IdTipoAnimal = (int)reader["IdTipoAnimal"],
                                TipoDescripcion = (string)reader["TipoDescripcion"]
                            };
                            tiposAnimales.Add(tipo);
                        }
                    }
                }
            }
            return tiposAnimales;
        }
    }
}
