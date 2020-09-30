using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Smslog
    {
        public long Id { get; set; }
        public long? JobId { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public bool Sent { get; set; }
        public bool UserAlerted { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? CreatedByUserId { get; set; }
        public bool? IsNotify { get; set; }

        public virtual Job Job { get; set; }
    }
}
