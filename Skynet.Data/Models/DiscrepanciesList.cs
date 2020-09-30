using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class DiscrepanciesList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
