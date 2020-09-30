using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class CallRecord
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int CallTypeId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public long? JobId { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
