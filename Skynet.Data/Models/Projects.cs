using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Projects
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string BillingAddress { get; set; }
        public bool? IsDefault { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
