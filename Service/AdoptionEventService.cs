using PetPlas.Entities;
using PetPlas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Service
{
    internal class AdoptionEventService
    {
        private readonly IAdoptionEventRepository adoptionEventRepository;

        public AdoptionEventService(IAdoptionEventRepository adoptionEventRepository)
        {
            this.adoptionEventRepository = adoptionEventRepository ?? throw new ArgumentNullException(nameof(adoptionEventRepository));
        }

        public void DisplayUpcomingEvents()
        {
           

            try
            {
                List<AdoptionEvent> upcomingEvents = adoptionEventRepository.GetUpcomingEvents();

                Console.WriteLine("Upcoming Adoption Events:");

                if (upcomingEvents.Count > 0)
                {
                    foreach (var eventItem in upcomingEvents)
                    {
                        Console.WriteLine($"Event Id: {eventItem.EventId}");
                       
                        Console.WriteLine($"Event Date: {eventItem.EventDate}");
                        
                        Console.WriteLine("----------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No upcoming events found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void RegisterParticipantForEventFromUser()
        {
            try
            {
                Console.Write("Enter your ID: ");
                int adopterid = int.Parse(Console.ReadLine());

                Console.Write("Enter the event ID you want to register for: ");
                if (int.TryParse(Console.ReadLine(), out int eventId))
                {
                    Adopter adopter = new Adopter { AdopterId = adopterid };
                    AdoptionEvent adoptionEvent = new AdoptionEvent { EventId = eventId };

                    adoptionEventRepository.RegisterParticipantForEvent(adopter, adoptionEvent);
                }
                else
                {
                    Console.WriteLine("Invalid event ID. Please enter a valid number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
