using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TaxRate
    {
        public long Id { get; set; }
        public long? CountyId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public double? StateTax { get; set; }
        public double? CountyTax { get; set; }
        public double? CityTax { get; set; }
        public double? SpecialRate { get; set; }
        public string QuickBooksTaxAllocationAccount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? LastUpdateBy { get; set; }
        public double? EffectiveDate { get; set; }

        public virtual County CountyNavigation { get; set; }
        public virtual State State { get; set; }
    }
}
