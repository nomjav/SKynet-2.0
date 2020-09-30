using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            Job = new HashSet<Job>();
            StorePartHistory = new HashSet<StorePartHistory>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string StoreNumber { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string Building { get; set; }
        public string CrossStreet { get; set; }
        public string City { get; set; }
        public long? CountyId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string HistoricalData { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public bool Deleted { get; set; }
        public string Notes { get; set; }
        public bool HasUrgentNotes { get; set; }
        public string UrgentNoteDetails { get; set; }

        public virtual Country Country { get; set; }
        public virtual County County { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<StorePartHistory> StorePartHistory { get; set; }
    }
}
