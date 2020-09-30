using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            JobPayment = new HashSet<JobPayment>();
            Receipt = new HashSet<Receipt>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }

        public virtual ICollection<JobPayment> JobPayment { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
