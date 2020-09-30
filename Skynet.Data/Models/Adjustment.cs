using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Adjustment
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public int Week { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public bool Done { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public int? JobId { get; set; }
        public string ReceiptNumber { get; set; }
        public bool IsReceiptAdjustment { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User LastUpdatedByUser { get; set; }
    }
}
