using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TruckTechnicianHistory
    {
        public long Id { get; set; }
        public long TruckId { get; set; }
        public long TechnicianId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Technicians Technician { get; set; }
        public virtual Truck Truck { get; set; }
    }
}
