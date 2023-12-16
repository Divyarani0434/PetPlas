using PetPlas.Entities;
using PetPlas.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Repository
{
    internal class PetRepository:IPetRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public PetRepository()
        {

            connectionString = DbConn.GetConnectionString();
            cmd = new SqlCommand();
        }
        public List<Pet> GetAvailablePets()
        {
            List<Pet> availablePets = new List<Pet>();
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-2A9B8EB;Database=PetPals;Trusted_Connection=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM pets", connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Pet: {reader["Name"]}, Age: {reader["Age"]}, Breed: {reader["Breed"]}");
                            Pet pet1 = new Pet(reader["Name"].ToString(), Convert.ToInt32(reader["Age"]), reader["Breed"].ToString());
                            
                               availablePets.Add(pet1);
                                                       
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return availablePets;
        }
    }
}
