using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class MobileNotification
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public long? JobId { get; set; }
        public long? ContractorId { get; set; }
        public long? TechnicianId { get; set; }
        public bool FromDevice { get; set; }
        public long? DeviceId { get; set; }
        public bool Alert { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual Device Device { get; set; }
        public virtual Job Job { get; set; }
        public virtual User LastUpdatedByUser { get; set; }
        public virtual Technicians Technician { get; set; }
    }
}
