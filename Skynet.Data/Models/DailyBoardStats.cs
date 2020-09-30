using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class DailyBoardStats
    {
        public long Id { get; set; }
        public int StatusId { get; set; }
        public long Threshold { get; set; }
        public long? JobsInMorning { get; set; }
        public long? JobsInNoon { get; set; }
        public long? JobsInLateAfternoon { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public string JobType { get; set; }

        public virtual JobStatus Status { get; set; }
    }
}
