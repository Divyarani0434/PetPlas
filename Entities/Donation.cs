using PetPlas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlas.Entities
{
    abstract class Donation
    {
        public string DonarName { get; set; }
        
        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set
            {
                if (value < 10)
                {
                    throw new InsufficientFundsException("Donation amount must be at least $10.");
                }
                amount = value;
            }
        }
        public Donation(string donarname,decimal amount) {
            DonarName = donarname;
            Amount = amount;
        }
        public abstract void RecordDonation();
    }
}
