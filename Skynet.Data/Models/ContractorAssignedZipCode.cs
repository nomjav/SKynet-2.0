using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ContractorAssignedZipCode
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public string ZipCode { get; set; }
        public long? ZipCodeId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public int? Priority { get; set; }
        public double? Radius { get; set; }

        public virtual Contractor Contractor { get; set; }
    }
}
