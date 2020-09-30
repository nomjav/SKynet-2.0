using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ErrorLog
    {
        public long Id { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public long? UserId { get; set; }
        public string PageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
