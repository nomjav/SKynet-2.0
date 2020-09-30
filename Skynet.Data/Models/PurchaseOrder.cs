using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public long Id { get; set; }
        public long JobId { get; set; }
        public long? SalesReceiptId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int? OrderStatus { get; set; }
        public string InvoiceBy { get; set; }
        public DateTime DateOrdered { get; set; }
        public string OrderedBy { get; set; }
        public string ShippedBy { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingDetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserdId { get; set; }
        public long? BillingAddressId { get; set; }
        public long? ShippingAddressId { get; set; }
        public bool Aissparts { get; set; }
        public string Type { get; set; }

        public virtual Address BillingAddress { get; set; }
        public virtual Job Job { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
