using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobContractorMapping
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public long JobId { get; set; }
        public long? SubContractorId { get; set; }
        public double? Commission { get; set; }
        public decimal? Nteamount { get; set; }
        public bool IsPrimary { get; set; }
        public int? NoticeForm { get; set; }
        public string Title { get; set; }
        public string PrintName { get; set; }
        public string CustomerComments { get; set; }
        public string CauseOfDamage { get; set; }
        public string WorkPerformed { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string SignaturePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public string IPhoneReceiptNo { get; set; }
        public string CustomerInvoiceNo { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Eta { get; set; }
        public string JobContractorEta { get; set; }
        public decimal? PrepaidAmount { get; set; }
        public DateTime? PrepaidAmountPaidOn { get; set; }
        public long? PrepaidAmountCreatedByUserId { get; set; }
        public int? PaymentPreference { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public bool? InitialInvoice { get; set; }
        public decimal? InitialNteamount { get; set; }
        public string ContactPerson { get; set; }
        public decimal? BillingEstimate { get; set; }
        public double? JobMargin { get; set; }
        public string NteChangeReason { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Job Job { get; set; }
        public virtual Technicians SubContractor { get; set; }
        public long? vwJobsId { get; set; }
    }
}
