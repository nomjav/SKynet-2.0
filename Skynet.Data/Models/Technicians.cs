using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Technicians
    {
        public Technicians()
        {
            Device = new HashSet<Device>();
            JobContractorMapping = new HashSet<JobContractorMapping>();
            MobileNotification = new HashSet<MobileNotification>();
            TechnicianNotes = new HashSet<TechnicianNotes>();
            Truck = new HashSet<Truck>();
            TruckTechnicianHistory = new HashSet<TruckTechnicianHistory>();
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public long ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string MainPhone { get; set; }
        public string MainEmailAddress { get; set; }
        public string LoginPassword { get; set; }
        public bool Deleted { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public string TechnicianPicture { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public string TechnicianFax { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<JobContractorMapping> JobContractorMapping { get; set; }
        public virtual ICollection<MobileNotification> MobileNotification { get; set; }
        public virtual ICollection<TechnicianNotes> TechnicianNotes { get; set; }
        public virtual ICollection<Truck> Truck { get; set; }
        public virtual ICollection<TruckTechnicianHistory> TruckTechnicianHistory { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
