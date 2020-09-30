using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ComplianceDetails
    {
        public long Id { get; set; }
        public DateTime? ReminderDate { get; set; }
        public long? ContractorId { get; set; }
        public bool W9 { get; set; }
        public bool Agreement { get; set; }
        public bool Insurance { get; set; }
        public bool License { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool Sent { get; set; }
    }
}
