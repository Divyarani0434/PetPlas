using PetPlas.Entities;
using PetPlas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Service
{
    internal class PetService
    {
        private readonly IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public List<Pet> DisplayPetListings()
        {
            try
            {
                
                return petRepository.GetAvailablePets();
            }
            catch (Exception ex)
            {
               
                throw new NullReferenceException();
            }
        }
    }
}
