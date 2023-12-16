using PetPlas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Repository
{
    internal interface IPetRepository
    {
        List<Pet> GetAvailablePets();
    }
}
