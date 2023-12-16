using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class Adopter
    {
        public int AdopterId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // You may add additional properties and methods as needed

        public override string ToString()
        {
            return $"AdopterId: {AdopterId}, Name: {Name}, Email: {Email}, Phone: {Phone}, Address: {Address}";
        }
    }
}
