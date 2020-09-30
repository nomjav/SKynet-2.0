using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class JobLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long JobId { get; set; }
        public string LogMessage { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public double? PrevStatus { get; set; }
        public double? NewStatus { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
