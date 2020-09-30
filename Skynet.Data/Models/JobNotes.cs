using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobNotes
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public string Notes { get; set; }
        public bool RelatedToInvoice { get; set; }
        public bool RelatedToContractor { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? LasteUpdatedOn { get; set; }
        public long? LasdUpdatedBy { get; set; }
        public bool? CreatedFromiPhone { get; set; }
        public bool? TechIvr { get; set; }
        public bool? RelatedToIphone { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Job Job { get; set; }
        public virtual User LasdUpdatedByNavigation { get; set; }
    }
}
