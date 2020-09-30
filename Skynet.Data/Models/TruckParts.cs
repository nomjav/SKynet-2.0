using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TruckParts
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public long TruckId { get; set; }
        public int PartsQuantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public long LastUpdatedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User LastUpdatedByUser { get; set; }
        public virtual Part Part { get; set; }
        public virtual Truck Truck { get; set; }
    }
}
