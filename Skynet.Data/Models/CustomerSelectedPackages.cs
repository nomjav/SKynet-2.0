using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class CustomerSelectedPackages
    {
        public int SelectedPackageId { get; set; }
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        public int SalesPerson { get; set; }
        public DateTime DateOfSale { get; set; }
        public int IsDeleted { get; set; }
        public string VisitsDate { get; set; }
        public string PaymentsDate { get; set; }
        public decimal? Savings { get; set; }
        public decimal? NextAmount { get; set; }
        public string Message { get; set; }
        public decimal? SpiffPay { get; set; }
        public decimal Amount { get; set; }
        public string TypeOfService { get; set; }
        public int PackageFeeNumbes { get; set; }
        public string PackageFeeRepeat { get; set; }
        public int PackageFeeRepeatEvery { get; set; }
        public bool Cancelled { get; set; }
        public long? AddressId { get; set; }
        public int? InvoiceId { get; set; }
        public int Status { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
