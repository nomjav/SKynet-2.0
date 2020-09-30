using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class UserJobsRecord
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long JobId { get; set; }
        public DateTime ViewedOn { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
