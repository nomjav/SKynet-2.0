using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ShippingRates
    {
        public long Id { get; set; }
        public string ShippingCompany { get; set; }
        public decimal ShippingRates1 { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? LastUpdateByUserId { get; set; }
    }
}
