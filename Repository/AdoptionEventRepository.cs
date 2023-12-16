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
    internal class AdoptionEventRepository:IAdoptionEventRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public AdoptionEventRepository()
        {

            connectionString = DbConn.GetConnectionString();
            cmd = new SqlCommand();
        }
        public List<AdoptionEvent> GetUpcomingEvents()
        {
            List<AdoptionEvent> upcomingEvents = new List<AdoptionEvent>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM AdoptionEvents WHERE EventDate > GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdoptionEvent eventItem = new AdoptionEvent
                            {
                                EventId = (int)reader["EventId"],

                                EventDate = (DateTime)reader["EventDtae"],
                                
                            };

                            upcomingEvents.Add(eventItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
            }

            return upcomingEvents;
        }

        public void RegisterParticipantForEvent(Adopter adopter, AdoptionEvent adoptionEvent)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO EventParticipants (EventId, ParticipantID) VALUES (@EventId, @ParticipantID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventId", adoptionEvent.EventId);
                    command.Parameters.AddWithValue("@ParticipantID", adopter.AdopterId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Participant registered successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to register participant.");
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
