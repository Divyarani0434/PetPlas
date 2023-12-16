using PetPlas.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Repository
{
    internal class DonationRepository :IDonationRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public DonationRepository()
        {

            connectionString = DbConn.GetConnectionString();
            cmd = new SqlCommand();
        }

        public  void RecordCashDonation(string donorName, decimal donationAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO donations (DonorName, Amount) VALUES (@DonorName, @Amount)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DonorName", donorName);
                    command.Parameters.AddWithValue("@Amount", donationAmount);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Donation recorded successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to record donation.");
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        
    }
}
