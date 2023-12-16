using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Repository
{
    public interface IDonationRepository

    {
          void RecordCashDonation(string donorName, decimal donationAmount);
    }
}
