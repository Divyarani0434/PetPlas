using PetPlas.Exceptions;
using PetPlas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Service
{
    internal class DonationService
    {
        private IDonationRepository donationRepository = new DonationRepository();
        public DonationService(IDonationRepository donationRepository)
        {
            this.donationRepository = donationRepository ?? throw new ArgumentNullException(nameof(donationRepository));
        }





        public void AddCashDonation()
        {
            try
            {
                Console.Write("Enter donor name: ");
                string donorName = Console.ReadLine();
                
                Console.Write("Enter donation amount: ");
                decimal donationAmount = Convert.ToDecimal(Console.ReadLine());
               

                // You can add business logic here if needed
                ValidateDonationAmount(donationAmount); // Example: Validate donation amount

                donationRepository.RecordCashDonation(donorName, donationAmount);
              //  Console.WriteLine("Donation recorded successfully!");
            }
            catch (Exception ex)
            {
                // Custom exception for donation-related errors
                Console.WriteLine($"Donation Error: {ex.Message}");
            }
             
        }
        private void ValidateDonationAmount(decimal donationAmount)
        {
            const decimal minimumAllowedAmount = 10;

            if (donationAmount < minimumAllowedAmount)
            {
                throw new InsufficientFundsException($"Donation amount must be at least ${minimumAllowedAmount}");
            }
        }
    }
}
