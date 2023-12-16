using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class AdoptionEvent
    {
       
            public int EventId { get; set; }
            
            public DateTime EventDate { get; set; }
          
            // You may add additional properties and methods as needed

            public override string ToString()
            {
                return $"EventId: {EventId}, EventDate: {EventDate}";
            }
        

    }
}
