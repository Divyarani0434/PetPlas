using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    internal class CashDonation:Donation
    {
        public DateTime DonationDate { get; set; }
        public CashDonation(string donarName,decimal amount,DateTime donationDate):base(donarName, amount)
        {
            DonationDate = donationDate;
        }
        public override void RecordDonation()
        {

        }
    }
}
