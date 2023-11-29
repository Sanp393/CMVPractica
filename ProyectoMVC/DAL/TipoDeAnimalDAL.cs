using Microsoft.Data.SqlClient;
using ProyectoMVC.Models;

namespace ProyectoMVC.DAL
{
    public class TipoDeAnimalDAL
    {
        private string _DataBaseString;

        public TipoDeAnimalDAL(string connexionString)
        {
            _DataBaseString = connexionString;
        }

        public List<TipoAnimal> TipoAnimalDataBase()
        {
            List<TipoAnimal> tiposAnimales = new List<TipoAnimal>();

            using (SqlConnection connection = new SqlConnection(_DataBaseString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TipoAnimal", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
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

        public void InsertarTipoAnimal(TipoAnimal tipo)
        {
            using SqlConnection connection = new SqlConnection(_DataBaseString);
            {
                string query = "INSERT INTO TipoAnimal (@TipoDescripcion)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TipoDescripcion", tipo.TipoDescripcion);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
