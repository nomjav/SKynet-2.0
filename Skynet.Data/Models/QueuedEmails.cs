using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class QueuedEmails
    {
        public int QueueId { get; set; }
        public long? CustomerId { get; set; }
        public long? ContractorId { get; set; }
        public long? JobId { get; set; }
        public string ToMailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string FileAttachement { get; set; }
        public string EmailType { get; set; }
        public bool? IsTechDispatched { get; set; }
        public string ComType { get; set; }
        public string JobContractorEta { get; set; }
        public string Nteamount { get; set; }
        public string PaymentPreference { get; set; }
        public string ContactPerson { get; set; }
        public string EmailStatus { get; set; }
        public int? SentTries { get; set; }
        public DateTime? SentOn { get; set; }
        public string SentBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? LastUpdateOn { get; set; }
        public int? LastUpdatedByUserId { get; set; }
    }
}
