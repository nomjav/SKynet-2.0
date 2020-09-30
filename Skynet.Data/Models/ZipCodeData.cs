using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ZipCodeData
    {
        public long Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public long? CountyId { get; set; }
        public int? CountryId { get; set; }

        public virtual County County { get; set; }
        public virtual State State { get; set; }
    }
}
