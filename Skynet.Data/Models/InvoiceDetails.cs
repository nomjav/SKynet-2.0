using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class InvoiceDetails
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal ShippingCharges { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserdId { get; set; }
        public int? ServiceId { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual User LastUpdatedByUserd { get; set; }
    }
}
