using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobPart
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long? PartId { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public decimal? LaborCost { get; set; }
        public decimal? Markup { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TripCost { get; set; }
        public decimal? OtherCost { get; set; }
        public Nullable<long> EstimateNumber { get; set; }
        public string EstimateLabel { get; set; }
        public virtual Job Job { get; set; }
        public virtual Part Part { get; set; }
    }
}
