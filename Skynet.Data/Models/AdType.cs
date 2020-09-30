using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class AdType
    {
        public AdType()
        {
            JobAdType = new HashSet<Job>();
            JobPaymentMethod = new HashSet<Job>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedByUserId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Job> JobAdType { get; set; }
        public virtual ICollection<Job> JobPaymentMethod { get; set; }
    }
}
