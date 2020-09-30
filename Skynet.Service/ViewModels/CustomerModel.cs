using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.ViewModels
{
    public class CustomerGridModel
    {
        public long Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public string City { get; set; }
        public int CustomerTypeId { get; set; }
        public int TotalJobs { get; set; }
        public bool HasStores { get; set; }
        public long AddressId { get; set; }
        public string Phone { get; set; }

    }

    public class CustomerModel
    {
        public long Id { get; set; }
        public string Salutation { get; set; }
        public decimal? nteAmount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int CustomerType { get; set; }
        public string Website { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public bool CreditWorthy { get; set; }
        public bool? StartEndTime { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public long? CountyId { get; set; }
        public bool TaxExempt { get; set; }
        public string TaxExemptNumber { get; set; }
        public string Notes { get; set; }
        public string CustomerDescription { get; set; }
        public string SpecialInstructions { get; set; }
        public string CustomerRepresentative { get; set; }
        public int PreferredMethodOfCummunication { get; set; }
        public bool? InvoiceChecked { get; set; }
        public bool? WOChecked { get; set; }
        public bool? SOChecked { get; set; }


        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> County { get; set; }
        public CustomerModel()
        {
            States = new List<SelectListItem>();
            County = new List<SelectListItem>();
            Addresses = new List<AddressModel>();
            BillingAddress = new AddressModel();
            Projects = new List<ProjectModel>();
        }

        public string Email { get; set; }
        public string City { get; set; }
        public bool isWarranty { get; set; }
        public string JobDescription { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string CrossStreet { get; set; }
        public string Fax { get; set; }
        public int AddressType { get; set; }

        public long AddressId { get; set; }

        public AddressModel BillingAddress { get; set; }

        public List<AddressModel> Addresses { get; set; }

        public List<ProjectModel> Projects { get; set; }

        public bool BillingAddressExist { get; set; }

        public string IVRPin { get; set; }

        public string IVRNumber { get; set; }

        public string HistoricalData { get; set; }
        public string WrapupNotes { get; set; }
        public bool HasUrgentNote { get; set; }
        public string UrgentNoteDetails { get; set; }
        public string customerNotificationName { get; set; }
        public string customerNotificationLastName { get; set; }
        public string customerNotificationTitle { get; set; }
        public string customerNotificationEmail { get; set; }
        public string OtherFirstName { get; set; }
        public string OtherLastName { get; set; }
        public string OtherTitle { get; set; }
        public string otherEmails { get; set; }
        public bool? SendUpdateOnJobCreated { get; set; }
        public bool? SendUpdateOnJobCompleted { get; set; }
        public bool? SendUpdateOnJobDispatched { get; set; }
        public bool? SendUpdateOnJobDelay { get; set; }

        public bool? SendUpdateInCustomerPortal { get; set; }
        public bool? SendUpdateInCustomerEmail { get; set; }
        public bool SendCustomerUpdatesDetails { get; set; }
        public bool? SendUpdateOnAssigned { get; set; }
        public bool? SendUpdateOnReturn { get; set; }
        public bool? SendUpdateOnPartsOnOrder { get; set; }
        public decimal? MarkupOnParts { get; set; }
        public decimal? DiscountOnParts { get; set; }
        public string LoginPassword { get; set; }
        public bool AutoUpdates { get; set; }
        public bool ManualUpdates { get; set; }
        public decimal? TripCharges { get; set; }
        public decimal? HourlyLabour { get; set; }
        public string AMFirstName { get; set; }
        public string AMLastName { get; set; }
        public string AMEmail { get; set; }
        public bool? Hasuseraccess { get; set; }
    }

    public enum AddressType
    {
        Apartments = 1,
        PrivateHouse = 2,
        Office = 3,
        BillingAddress = 4,
        Business = 5,
        POBox = 6
    }

    public enum CustomerType
    {
        CommercialBilling = 1,
        Residential = 2,
        Auto = 3,
        CommercialNonBilling = 4,
    }

    public class TargetCustomerModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int TotalJobs { get; set; }
    }

    public class GetCustomerListViewModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }

    }
}
