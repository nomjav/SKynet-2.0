using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.ViewModels
{
    public class AddressModel
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public int AddressType { get; set; }
        public bool IsBilling { get; set; }
        public int? StateId { get; set; }
        public long? CountyId { get; set; }
        public long? CountryId { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CrossStreet { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public string County { get; set; }
        public string Country { get; set; }
        public string Customer { get; set; }
        public string State { get; set; }

        public bool IsDefault { get; set; }
    }

    public class ProjectModel
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string projectName { get; set; }
        public string description { get; set; }
        public string billingAddress { get; set; }
        public bool IsDefault { get; set; }
    }
}
