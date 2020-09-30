using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Truck
    {
        public Truck()
        {
            TruckParts = new HashSet<TruckParts>();
            TruckTechnicianHistory = new HashSet<TruckTechnicianHistory>();
        }

        public long Id { get; set; }
        public long ContractorId { get; set; }
        public long? TechnicianId { get; set; }
        public string TruckNumber { get; set; }
        public double? Mileage { get; set; }
        public string VinNumber { get; set; }
        public string LicensePlateNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Technicians Technician { get; set; }
        public virtual ICollection<TruckParts> TruckParts { get; set; }
        public virtual ICollection<TruckTechnicianHistory> TruckTechnicianHistory { get; set; }
    }
}
