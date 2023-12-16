using PetPlas.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class PetShelter
    {
        
        private List<Pet> availablePets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            availablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            availablePets.Remove(pet);
        }

        public List<Pet> ListAvailablePets()
        {
            List<Pet> list = new List<Pet>();
            foreach (var pet in availablePets)
            {
             
               Console.WriteLine($"Pet: {pet.Name}, Age: {pet.Age}, Breed: {pet.Breed}");
                list.Add(pet);
            }
          
            return list; 
        }
        
    }
}
