// See https://aka.ms/new-console-template for more information
using PetPlas.Repository;
using PetPlas.Service;
IPetRepository petRepository = new PetRepository();
PetService petService = new PetService(petRepository);
IDonationRepository donationRepository = new DonationRepository();
DonationService donationService = new DonationService(donationRepository);
IAdoptionEventRepository adoptionEventRepository = new AdoptionEventRepository();
AdoptionEventService adoptionEventService = new AdoptionEventService(adoptionEventRepository);

    while (true)
{
    Console.WriteLine("Pet Adoption Platform Menu:");
    Console.WriteLine("1. Display Pet Listings");
    Console.WriteLine("2. Record Cash Donation");
    Console.WriteLine("3. Display Upcoming Events");
    Console.WriteLine("4. Register Upcoming Events");
    Console.WriteLine("5. Exit");

    Console.Write("Enter your choice (1-4): ");
    string choice = Console.ReadLine();
  

    switch (choice)
    {
        case "1":
            petService.DisplayPetListings();
            break;
        case "2":
            donationService.AddCashDonation();
            break;
        case "3":
            adoptionEventService.DisplayUpcomingEvents();
            break;
        case "4":
            adoptionEventService.RegisterParticipantForEventFromUser();
            break;
        case "5":
            Console.WriteLine("Exiting the program. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            break;
    }

  
}
    
