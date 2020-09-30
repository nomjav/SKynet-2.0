using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobPayment
    {
        public JobPayment()
        {
            PaymentLog = new HashSet<PaymentLog>();
        }

        public long Id { get; set; }
        public long JobId { get; set; }
        public long? CardId { get; set; }
        public long? PaymentMethodId { get; set; }
        public string CheckNumber { get; set; }
        public string ReceiptNumber { get; set; }
        public string AuthorizationTransactionId { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public string CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingPhoneNumber { get; set; }
        public string BillingEmail { get; set; }
        public string BillingFaxNumber { get; set; }
        public string BillingCompany { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public int? BillingStateProvinceId { get; set; }
        public string BillingZipCode { get; set; }
        public int? BillingCountryId { get; set; }
        public string BillingUnit { get; set; }
        public string Recommendation { get; set; }
        public bool? TermsAndConditions { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }

        public virtual CreditCard Card { get; set; }
        public virtual Job Job { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<PaymentLog> PaymentLog { get; set; }
    }
}
