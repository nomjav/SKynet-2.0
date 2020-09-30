using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Device
    {
        public Device()
        {
            MobileNotification = new HashSet<MobileNotification>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public long? ContractorId { get; set; }
        public long? TechnicianId { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public bool? IsTestFlight { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Technicians Technician { get; set; }
        public virtual ICollection<MobileNotification> MobileNotification { get; set; }
    }
}
