using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class State
    {
        public State()
        {
            Address = new HashSet<Address>();
            County = new HashSet<County>();
            CreditCard = new HashSet<CreditCard>();
            CustomerStateMapping = new HashSet<CustomerStateMapping>();
            Job = new HashSet<Job>();
            Store = new HashSet<Store>();
            TaxRate = new HashSet<TaxRate>();
            User = new HashSet<User>();
            ZipCodeData = new HashSet<ZipCodeData>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int? CountryId { get; set; }
        public bool TaxPartsOnly { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public int? DisplayOrder { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneCode { get; set; }

        public virtual Country Country { get; set; }
        //public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<County> County { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<CustomerStateMapping> CustomerStateMapping { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<TaxRate> TaxRate { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<ZipCodeData> ZipCodeData { get; set; }
    }
}
