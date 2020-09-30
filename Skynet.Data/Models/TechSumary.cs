using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TechSumary
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long? ContractorId { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Charges { get; set; }
        public string Total { get; set; }
        public string ReceiptNumber { get; set; }
        public string Types { get; set; }
        public string Notes { get; set; }
        public string Tax { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedBy { get; set; }
        public long TechSummaryNumber { get; set; }

        public virtual Job Job { get; set; }
    }
}
