using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class HeadSheet
    {
        public long Id { get; set; }
        public long ContracorId { get; set; }
        public long? JobsTotal { get; set; }
        public decimal? CashIn { get; set; }
        public decimal? CashOut { get; set; }
        public decimal? ExcessCash { get; set; }
        public decimal? TotalCash { get; set; }
        public decimal? ChecksAmount { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? Amexamount { get; set; }
        public decimal? McvisaAmount { get; set; }
        public decimal? DiscoverAmount { get; set; }
        public decimal? BillingAmount { get; set; }
        public decimal? AverageAmount { get; set; }
        public decimal? PartsUsed { get; set; }
        public decimal? Total { get; set; }
        public int Week { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public decimal? CreditAmount { get; set; }

        public virtual Contractor Contracor { get; set; }
    }
}
