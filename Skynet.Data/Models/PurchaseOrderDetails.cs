using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PurchaseOrderDetails
    {
        public long Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double ShippingCharges { get; set; }
        public string Description { get; set; }
        public double? SalesTax { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserdId { get; set; }
        public bool? InventoryPart { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
