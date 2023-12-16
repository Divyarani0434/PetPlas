using PetPlas.Exceptions;
using PetPlas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class Pet:IAdoptable
    {
        
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidPetAgeException("Age must be a positive integer.");
                }
                age = value;
            }
        }
       // public int Age { get; set; }
            public string Breed { get; set; }

            public Pet(string name, int age, string breed)
            {
                Name = name;
                Age = age;
                Breed = breed;
            }

            public override string ToString()
            {
                return $"{Name} - {Age} years old - {Breed}";
            }
        public void Adopt()
        {
            Console.WriteLine($"Pet {Name} has been adopted!");
        }
        

    }
}
