using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TechReceiptLineItem
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long? ContractorId { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public bool? ViaVendorPortal { get; set; }
        public bool? InvoiceSubmitted { get; set; }

        public virtual Job Job { get; set; }
    }
}
