using PetPlas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetPlas.Repository
{
    internal interface IAdoptionEventRepository
    {
        List<AdoptionEvent> GetUpcomingEvents();
        void RegisterParticipantForEvent(Adopter adopter, AdoptionEvent adoptionEvent);
    }
}
