using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class WebAddressManager
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string Title { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
