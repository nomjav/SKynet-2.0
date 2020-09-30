using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            JobPayment = new HashSet<JobPayment>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal? CreditLimit { get; set; }
        public string CreditCardType { get; set; }
        public string Password { get; set; }
        public string Crvnumber { get; set; }
        public string NameOnCard { get; set; }
        public string AddressOnCard { get; set; }
        public string CardZip { get; set; }
        public string CardNotes { get; set; }
        public string CreditCardExpireMonth { get; set; }
        public string CreditCardExpireYear { get; set; }
        public int? StateId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public string CardNumber { get; set; }
        public string CardCity { get; set; }
        public bool? CardNotRun { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<JobPayment> JobPayment { get; set; }
    }
}
