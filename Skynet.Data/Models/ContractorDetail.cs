using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ContractorDetail
    {
        public long Id { get; set; }
        public long ContactorId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime? InsuranceExpirationDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string GeneralLiabilityCarrierName { get; set; }
        public DateTime? GeneralLiabilityExpiryDate { get; set; }
        public string ExcessLiabilityCarrierName { get; set; }
        public DateTime? ExcessLiabilityExpiryDate { get; set; }
        public string AutomobileInsuranceCarrierName { get; set; }
        public DateTime? AutomobileInsuranceExpiryDate { get; set; }
        public string WorkmanCompInsuranceCarrierName { get; set; }
        public DateTime? WorkmanCompInsuranceExpiryDate { get; set; }
        public string GeneralLiabilityPolicyNumber { get; set; }
        public string GeneralLiabilityLimits { get; set; }
        public string ExcessLiabilityPolicyNumber { get; set; }
        public string ExcessLiabilityLimits { get; set; }
        public string AutomobileInsurancePolicyNumber { get; set; }
        public string AutomobileInsuranceLimits { get; set; }
        public string WorkmanCompInsurancePolicyNumber { get; set; }
        public string WorkmanCompInsuranceLimits { get; set; }
        public string OtherLiabilityCarrierName { get; set; }
        public DateTime? OtherLiabilityExpiryDate { get; set; }
        public string OtherLiabilityPolicyNumber { get; set; }
        public string OtherLiabilityLimits { get; set; }
        public decimal? ServiceCallCharges { get; set; }
        public decimal? HourlyLaborRate { get; set; }
        public decimal? RekeyCharges { get; set; }
        public decimal? DuplicatesCharges { get; set; }
        public decimal? AfterHoursCharges { get; set; }
        public decimal? AfterHoursLaborRate { get; set; }
        public decimal? SafesServiceCallCharges { get; set; }
        public decimal? SafesHourlyLaborRate { get; set; }
        public decimal? SafesComboChangeCharges { get; set; }
        public decimal? SafesOpeningCharges { get; set; }
        public decimal? SafesAfterHoursCharges { get; set; }
        public decimal? SafesAfterHoursLaborRate { get; set; }
        public decimal? DoorServiceCallCharges { get; set; }
        public decimal? DoorHourlyLaborRate { get; set; }
        public decimal? DoorAfterHoursCharges { get; set; }
        public decimal? DoorAfterHoursLaborRate { get; set; }
        public decimal? RemoveInstallHerculiteDoorCharges { get; set; }
        public decimal? TripCharges { get; set; }
        public decimal? LaborCharges { get; set; }

        public virtual Contractor Contactor { get; set; }
    }
}
