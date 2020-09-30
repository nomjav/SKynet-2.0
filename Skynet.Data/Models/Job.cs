using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Job
    {
        public Job()
        {
            CallRecord = new HashSet<CallRecord>();
            Document = new HashSet<Document>();
            EmailLog = new HashSet<EmailLog>();
            Invoice = new HashSet<Invoice>();
            JobContractorMapping = new HashSet<JobContractorMapping>();
            JobLog = new HashSet<JobLog>();
            JobNotes = new HashSet<JobNotes>();
            JobPart = new HashSet<JobPart>();
            JobPayment = new HashSet<JobPayment>();
            MobileNotification = new HashSet<MobileNotification>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Receipt = new HashSet<Receipt>();
            Smslog = new HashSet<Smslog>();
            StorePartHistory = new HashSet<StorePartHistory>();
            TechReceiptLineItem = new HashSet<TechReceiptLineItem>();
            TechSumary = new HashSet<TechSumary>();
            UserJobsRecord = new HashSet<UserJobsRecord>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int JobTypeId { get; set; }
        public string LinkJobId { get; set; }
        public long? BillingAddressId { get; set; }
        public long PaymentMethodId { get; set; }
        public long? StoreId { get; set; }
        public long? AdTypeId { get; set; }
        public long? EquipmentId { get; set; }
        public int? JobStatusId { get; set; }
        public int? StateId { get; set; }
        public int CountryId { get; set; }
        public long? CountyId { get; set; }
        public int? AddressTypeId { get; set; }
        public string ZipCode { get; set; }
        public bool IsAuto { get; set; }
        public string Ponumber { get; set; }
        public string WorkOrder2 { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ApartmentSuite { get; set; }
        public long BookedByUserId { get; set; }
        public string BuzzerCode { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string CalledInBy { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
        public decimal? Nteamount { get; set; }
        public int? DateIntervalType { get; set; }
        public DateTime? OnDate { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public DateTime? DispatchedTime { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool? IsEmergency { get; set; }
        public string Ask { get; set; }
        public string Notes { get; set; }
        public bool EstimatePrinted { get; set; }
        public bool EstimateEmailed { get; set; }
        public bool? IsCow { get; set; }
        public bool TaxExempt { get; set; }
        public bool IsBillingSameAsServiceAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public bool Locked { get; set; }
        public string AdTypeOtherOption { get; set; }
        public string AdTypeWebSource { get; set; }
        public bool AlertedOniPhone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public int? FormOfPayment { get; set; }
        public string TimeZone { get; set; }
        public bool? PreferredCommunicationMethodEmail { get; set; }
        public string NotificationFirstName { get; set; }
        public string NotificationLastName { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationEmail { get; set; }
        public bool? UpdateOnCreated { get; set; }
        public bool? UpdateOnCompleted { get; set; }
        public bool? UpdateOnDisptched { get; set; }
        public bool? UpdateOnAssigned { get; set; }
        public bool? UpdateOnReturn { get; set; }
        public bool? UpdateOnPartsOnOrder { get; set; }
        public bool? UpdateOnDelayed { get; set; }
        public bool? UpdateInCustomerPortal { get; set; }
        public bool? UpdateInCustomerEmail { get; set; }
        public string OtherFirstName { get; set; }
        public string OtherLastName { get; set; }
        public string OtherTitle { get; set; }
        public string OtherEmail { get; set; }
        public string SpecialInstructions { get; set; }
        public bool? UpdatedOnAcceptedInPortal { get; set; }
        public bool? UpdatedOnAssignedInPortal { get; set; }
        public bool? UpdatedOnDispatchInPortal { get; set; }
        public bool? UpdatedOnReturnInPortal { get; set; }
        public bool? UpdatedOnPartsOnOrderInPortal { get; set; }
        public bool? UpdatedOnFollowUpInPortal { get; set; }
        public bool? UpdatedOnPicturesInPortal { get; set; }
        public bool? UpdatedOnCompleteInPortal { get; set; }
        public bool? UpdatedOnDelayedInPortal { get; set; }
        public DateTime? InvoiceRecieved { get; set; }
        public bool? UpdatedOnAcceptedInEmail { get; set; }
        public bool? UpdatedOnAssignedInEmail { get; set; }
        public bool? UpdatedOnDispatchInEmail { get; set; }
        public bool? UpdatedOnReturnInEmail { get; set; }
        public bool? UpdatedOnPartsOnOrderInEmail { get; set; }
        public bool? UpdatedOnFollowUpInEmail { get; set; }
        public bool? UpdatedOnPicturesInEmail { get; set; }
        public bool? UpdatedOnCompleteInEmail { get; set; }
        public bool? UpdatedOnDelayedInEmail { get; set; }
        public bool IsWarrantyJob { get; set; }
        public long? ProjectId { get; set; }
        public string BubbleHeight { get; set; }

        public virtual AdType AdType { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual User BookedByUser { get; set; }
        public virtual Country Country { get; set; }
        public virtual County County { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual AdType PaymentMethod { get; set; }
        public virtual State State { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<CallRecord> CallRecord { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<EmailLog> EmailLog { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<JobContractorMapping> JobContractorMapping { get; set; }
        public virtual ICollection<JobLog> JobLog { get; set; }
        public virtual ICollection<JobNotes> JobNotes { get; set; }
        public virtual ICollection<JobPart> JobPart { get; set; }
        public virtual ICollection<JobPayment> JobPayment { get; set; }
        public virtual ICollection<MobileNotification> MobileNotification { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Smslog> Smslog { get; set; }
        public virtual ICollection<StorePartHistory> StorePartHistory { get; set; }
        public virtual ICollection<TechReceiptLineItem> TechReceiptLineItem { get; set; }
        public virtual ICollection<TechSumary> TechSumary { get; set; }
        public virtual ICollection<UserJobsRecord> UserJobsRecord { get; set; }
    }
}
