using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Receipt
    {
        public long Id { get; set; }
        public long? PaymentMethodId { get; set; }
        public long ContractorId { get; set; }
        public long JobId { get; set; }
        public decimal? CashAmount { get; set; }
        public decimal? CheckAmount { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? AmexAmount { get; set; }
        public decimal? MasterCardAmount { get; set; }
        public decimal? DiscoverAmount { get; set; }
        public decimal? VisaAmount { get; set; }
        public decimal? CostOfGoodsSold { get; set; }
        public decimal? RetailCostOfMaterials { get; set; }
        public decimal? IncTax { get; set; }
        public decimal? TaxOverride { get; set; }
        public decimal? Inventory { get; set; }
        public decimal? Ilgparts { get; set; }
        public decimal? Discount { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal? ExtraCommission { get; set; }
        public decimal? ContractorCommissionRate { get; set; }
        public decimal? StraightCommission { get; set; }
        public bool TaxExempt { get; set; }
        public int? Week { get; set; }
        public int? Quarter { get; set; }
        public decimal? Total { get; set; }
        public int? Year { get; set; }
        public string Approval { get; set; }
        public string Notes { get; set; }
        public string SignaturePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateBy { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? CalculatedTotal { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? CreditCardAmount { get; set; }
        public bool AsCredit { get; set; }
        public decimal? Trip { get; set; }
        public decimal? Labor { get; set; }
        public decimal? Part { get; set; }
        public bool? IsPrepaid { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Job Job { get; set; }
        public virtual User LastUpdateByNavigation { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
