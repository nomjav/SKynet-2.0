using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            Adjustment = new HashSet<Adjustment>();
            ContractorAssignedZipCode = new HashSet<ContractorAssignedZipCode>();
            ContractorDetail = new HashSet<ContractorDetail>();
            ContractorNote = new HashSet<ContractorNote>();
            ContractorRatings = new HashSet<ContractorRatings>();
            Device = new HashSet<Device>();
            Document = new HashSet<Document>();
            HeadSheet = new HashSet<HeadSheet>();
            JobContractorMapping = new HashSet<JobContractorMapping>();
            MobileNotification = new HashSet<MobileNotification>();
            Receipt = new HashSet<Receipt>();
            Technicians = new HashSet<Technicians>();
            Truck = new HashSet<Truck>();
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Ssn { get; set; }
        public string Tinfin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MainEmailAddress { get; set; }
        public string BusinessName { get; set; }
        public long? AddressId { get; set; }
        public string CommissionRate { get; set; }
        public bool? Active { get; set; }
        public decimal? DefaultNteamount { get; set; }
        public bool? Commissioned { get; set; }
        public bool? IsFifityFifty { get; set; }
        public int PreferedCommunicationMethod { get; set; }
        public DateTime? HiringDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public int? CompanyType { get; set; }
        public string TaxId { get; set; }
        public bool? MinorityOwned { get; set; }
        public bool? UnionShop { get; set; }
        public string MainCompanyPhone { get; set; }
        public string AfterHoursAlternatePhone { get; set; }
        public string GeneralContactPerson { get; set; }
        public string MainCompanyFax { get; set; }
        public string MainAccountingPhone { get; set; }
        public string MainAccountingFax { get; set; }
        public string AccountingContact { get; set; }
        public string MainAccountingEmailAddress { get; set; }
        public string StandardServiceArea { get; set; }
        public string ExtendedServiceAreaAndIncreasedFees { get; set; }
        public long? ShippingAddressId { get; set; }
        public int? Priority { get; set; }
        public int Radius { get; set; }
        public string AssignedZipCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public bool? ShowOnContractorBoard { get; set; }
        public int? ContractorBoardPriority { get; set; }
        public bool? AccessParts { get; set; }
        public int? PaymentPreference { get; set; }
        public string LoginPassword { get; set; }
        public string ProfitabilityRating { get; set; }
        public string ProfitabilityRatingBasedOnJobs { get; set; }
        public string BlackBallList { get; set; }
        public string Source { get; set; }
        public string ContractorPicture { get; set; }
        public bool? UserAccess { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<Adjustment> Adjustment { get; set; }
        public virtual ICollection<ContractorAssignedZipCode> ContractorAssignedZipCode { get; set; }
        public virtual ICollection<ContractorDetail> ContractorDetail { get; set; }
        public virtual ICollection<ContractorNote> ContractorNote { get; set; }
        public virtual ICollection<ContractorRatings> ContractorRatings { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<HeadSheet> HeadSheet { get; set; }
        public virtual ICollection<JobContractorMapping> JobContractorMapping { get; set; }
        public virtual ICollection<MobileNotification> MobileNotification { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Technicians> Technicians { get; set; }
        public virtual ICollection<Truck> Truck { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
