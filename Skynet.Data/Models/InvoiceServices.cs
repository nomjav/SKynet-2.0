using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class InvoiceServices
    {
        public long Id { get; set; }
        public long? JobId { get; set; }
        public long? ServiceId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? AddedFromTruck { get; set; }
    }
}
