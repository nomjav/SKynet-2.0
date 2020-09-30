using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobStatus
    {
        public JobStatus()
        {
            DailyBoardStats = new HashSet<DailyBoardStats>();
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Code { get; set; }
        public bool? Published { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public string BackgroundColorRgb { get; set; }
        public string BackgroundColorHex { get; set; }
        public string BackgroundColorName { get; set; }
        public string FontColorRgb { get; set; }
        public string FontColorHex { get; set; }

        public virtual ICollection<DailyBoardStats> DailyBoardStats { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}
