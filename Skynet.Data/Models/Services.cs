using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Services
    {
        public long ServiceId { get; set; }
        public int ServiceNo { get; set; }
        public string ServiceName { get; set; }
        public decimal ServiceCharges { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public bool? Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }
    }
}
