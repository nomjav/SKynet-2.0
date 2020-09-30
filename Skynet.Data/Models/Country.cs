using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
            County = new HashSet<County>();
            Job = new HashSet<Job>();
            State = new HashSet<State>();
            Store = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<County> County { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<State> State { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
