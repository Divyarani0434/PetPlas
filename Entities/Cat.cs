using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class Cat:Pet
    {
        public string CatColor {  get; set; }
        public Cat(string name, int age, string breed, string catColor)
        : base(name, age, breed)
        {
            CatColor = catColor;
        }

    }
}
