using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobAlarms
    {
        public long JobAlarmId { get; set; }
        public long? JobId { get; set; }
        public DateTime? AlarmTime { get; set; }
        public bool? Pending { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
    }
}
