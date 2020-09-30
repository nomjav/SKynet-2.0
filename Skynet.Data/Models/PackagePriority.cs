using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PackagePriority
    {
        public int PriorityId { get; set; }
        public string No { get; set; }
        public string Yes { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string PriorityName { get; set; }
        public int PackageId { get; set; }

        public virtual CompanyPackages Package { get; set; }
    }
}
