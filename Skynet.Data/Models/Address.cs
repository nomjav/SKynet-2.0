using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Address
    {
        public Address()
        {
            ContractorAddress = new HashSet<Contractor>();
            ContractorShippingAddress = new HashSet<Contractor>();
            Invoice = new HashSet<Invoice>();
            Job = new HashSet<Job>();
            PurchaseOrderBillingAddress = new HashSet<PurchaseOrder>();
            PurchaseOrderShippingAddress = new HashSet<PurchaseOrder>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public int AddressType { get; set; }
        public int CountryId { get; set; }
        public bool IsBilling { get; set; }
        public bool? IsDefault { get; set; }
        public int? StateId { get; set; }
        public long? CountyId { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CrossStreet { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public long LastUpdatedByUserId { get; set; }
        public string CompanyName { get; set; }

        public virtual Country Country { get; set; }
        public virtual County County { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Contractor> ContractorAddress { get; set; }
        public virtual ICollection<Contractor> ContractorShippingAddress { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderBillingAddress { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderShippingAddress { get; set; }
    }
}
