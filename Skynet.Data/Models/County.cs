using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class County
    {
        public County()
        {
            Address = new HashSet<Address>();
            Job = new HashSet<Job>();
            Store = new HashSet<Store>();
            TaxRate = new HashSet<TaxRate>();
            ZipCodeData = new HashSet<ZipCodeData>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public long DisplayOrder { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<TaxRate> TaxRate { get; set; }
        public virtual ICollection<ZipCodeData> ZipCodeData { get; set; }
    }
}
