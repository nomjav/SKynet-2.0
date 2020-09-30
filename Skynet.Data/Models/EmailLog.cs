using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class EmailLog
    {
        public long LogId { get; set; }
        public long? CustomerId { get; set; }
        public long? ContractorId { get; set; }
        public long? JobId { get; set; }
        public string LogMessage { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailedTo { get; set; }
        public long MailedFrom { get; set; }
        public DateTime MailedOn { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Type { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Job Job { get; set; }
        public virtual User MailedFromNavigation { get; set; }
    }
}
