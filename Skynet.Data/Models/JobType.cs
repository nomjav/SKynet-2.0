using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }
}
