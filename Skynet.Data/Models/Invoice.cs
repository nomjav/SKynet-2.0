using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public long Id { get; set; }
        public long JobId { get; set; }
        public long? AddressId { get; set; }
        public int Terms { get; set; }
        public int Week { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public DateTime? DueDate { get; set; }
        public string InvoiceInstruction { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }
        public decimal? Tax { get; set; }
        public double? Discount { get; set; }
        public bool? IsTangible { get; set; }
        public long? ReviewedByUserId { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public decimal? CalculatedTotal { get; set; }
        public bool? IsApproved { get; set; }
        public decimal? PartsToBeReimbursed { get; set; }
        public string JobInvoiceNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual Job Job { get; set; }
        public virtual User LastUpdateByUser { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
