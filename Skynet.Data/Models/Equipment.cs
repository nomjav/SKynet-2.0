using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Job = new HashSet<Job>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }
        public long? DisplayOrder { get; set; }
        public long? CategoryId { get; set; }
        public bool Deleted { get; set; }
        public int? JobType { get; set; }

        public virtual EquipmentCategory Category { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}
