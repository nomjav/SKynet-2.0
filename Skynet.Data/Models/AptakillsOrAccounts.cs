using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class AptakillsOrAccounts
    {
        public long Id { get; set; }
        public long? JobId { get; set; }
        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }
    }
}
