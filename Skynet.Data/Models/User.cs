using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class User
    {
        public User()
        {
            AdjustmentCreatedByUser = new HashSet<Adjustment>();
            AdjustmentLastUpdatedByUser = new HashSet<Adjustment>();
            CallRecord = new HashSet<CallRecord>();
            ContractorNote = new HashSet<ContractorNote>();
            ContractorRatings = new HashSet<ContractorRatings>();
            EmailLog = new HashSet<EmailLog>();
            EquipmentCategoryCreatedByUser = new HashSet<EquipmentCategory>();
            EquipmentCategoryLastUpdatedByUser = new HashSet<EquipmentCategory>();
            InvoiceCreatedByUser = new HashSet<Invoice>();
            InvoiceDetailsCreatedByUser = new HashSet<InvoiceDetails>();
            InvoiceDetailsLastUpdatedByUserd = new HashSet<InvoiceDetails>();
            InvoiceLastUpdateByUser = new HashSet<Invoice>();
            Job = new HashSet<Job>();
            JobLog = new HashSet<JobLog>();
            JobNotesCreatedByNavigation = new HashSet<JobNotes>();
            JobNotesLasdUpdatedByNavigation = new HashSet<JobNotes>();
            MobileNotificationCreatedByUser = new HashSet<MobileNotification>();
            MobileNotificationLastUpdatedByUser = new HashSet<MobileNotification>();
            PartsUserFavourites = new HashSet<PartsUserFavourites>();
            PermissionRecordUserMapping = new HashSet<PermissionRecordUserMapping>();
            ReceiptCreatedByNavigation = new HashSet<Receipt>();
            ReceiptLastUpdateByNavigation = new HashSet<Receipt>();
            StorePartHistory = new HashSet<StorePartHistory>();
            TechnicianNotes = new HashSet<TechnicianNotes>();
            TruckPartsCreatedByUser = new HashSet<TruckParts>();
            TruckPartsLastUpdatedByUser = new HashSet<TruckParts>();
            TruckTechnicianHistory = new HashSet<TruckTechnicianHistory>();
            UserJobsRecord = new HashSet<UserJobsRecord>();
            UserLogin = new HashSet<UserLogin>();
        }

        public long Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string Cell { get; set; }
        public string Phone { get; set; }
        public bool? ChangeJobTypes { get; set; }
        public int? AllowedJobTypeId { get; set; }
        public bool? GreaterThanNteamountEntryAllowed { get; set; }
        public bool Active { get; set; }
        public int CurrentBoardType { get; set; }
        public bool Deleted { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public long? ContractorId { get; set; }
        public DateTime? HiringDate { get; set; }
        public string Ssn { get; set; }
        public string TimeZone { get; set; }
        public string FilterPanelHistory { get; set; }
        public long? TechnicianId { get; set; }
        public long? CustomerId { get; set; }
        public int? Department { get; set; }
        public DateTime? PasswordChangedOn { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Role Role { get; set; }
        public virtual State State { get; set; }
        public virtual Technicians Technician { get; set; }
        public virtual ICollection<Adjustment> AdjustmentCreatedByUser { get; set; }
        public virtual ICollection<Adjustment> AdjustmentLastUpdatedByUser { get; set; }
        public virtual ICollection<CallRecord> CallRecord { get; set; }
        public virtual ICollection<ContractorNote> ContractorNote { get; set; }
        public virtual ICollection<ContractorRatings> ContractorRatings { get; set; }
        public virtual ICollection<EmailLog> EmailLog { get; set; }
        public virtual ICollection<EquipmentCategory> EquipmentCategoryCreatedByUser { get; set; }
        public virtual ICollection<EquipmentCategory> EquipmentCategoryLastUpdatedByUser { get; set; }
        public virtual ICollection<Invoice> InvoiceCreatedByUser { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetailsCreatedByUser { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetailsLastUpdatedByUserd { get; set; }
        public virtual ICollection<Invoice> InvoiceLastUpdateByUser { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<JobLog> JobLog { get; set; }
        public virtual ICollection<JobNotes> JobNotesCreatedByNavigation { get; set; }
        public virtual ICollection<JobNotes> JobNotesLasdUpdatedByNavigation { get; set; }
        public virtual ICollection<MobileNotification> MobileNotificationCreatedByUser { get; set; }
        public virtual ICollection<MobileNotification> MobileNotificationLastUpdatedByUser { get; set; }
        public virtual ICollection<PartsUserFavourites> PartsUserFavourites { get; set; }
        public virtual ICollection<PermissionRecordUserMapping> PermissionRecordUserMapping { get; set; }
        public virtual ICollection<Receipt> ReceiptCreatedByNavigation { get; set; }
        public virtual ICollection<Receipt> ReceiptLastUpdateByNavigation { get; set; }
        public virtual ICollection<StorePartHistory> StorePartHistory { get; set; }
        public virtual ICollection<TechnicianNotes> TechnicianNotes { get; set; }
        public virtual ICollection<TruckParts> TruckPartsCreatedByUser { get; set; }
        public virtual ICollection<TruckParts> TruckPartsLastUpdatedByUser { get; set; }
        public virtual ICollection<TruckTechnicianHistory> TruckTechnicianHistory { get; set; }
        public virtual ICollection<UserJobsRecord> UserJobsRecord { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
    }
}
