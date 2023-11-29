using Microsoft.Data.SqlClient;
using ProyectoMVC.Models;


namespace ProyectoMVC.DAL
{
    public class AnimalDAL
    {
        private string _DataBaseString;

        public AnimalDAL(string ConnexionString)
        {
            _DataBaseString = ConnexionString;
        }

        public List<Animal> animalsDataBase()
        {
            List<Animal> animales = new List<Animal>();

            using (SqlConnection connection = new SqlConnection(_DataBaseString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Animal", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
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

        public void InsertarAnimal(Animal animal)
        {
            using SqlConnection connection = new SqlConnection(_DataBaseString);
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
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
