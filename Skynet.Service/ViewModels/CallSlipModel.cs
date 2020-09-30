using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc.Rendering;
using Skynet.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Skynet.Service.ViewModels
{
    public class CallSlipModel
    {
        public double? JobStatusCode { get; set; }
        public CallSlipModel()
        {
            Contractors = new List<JobContractorMappingModel>();
        }

        public long Id { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerType { get; set; }
        public long CustomerId { get; set; }
        public int JobTypeId { get; set; }
        public string JobType { get; set; }
        public long PaymentMethodId { get; set; }
        public int? AddressTypeId { get; set; }
        public long? StoreId { get; set; }
        public long? AdTypeId { get; set; }
        public string AdType { get; set; }
        public long? EquipmentId { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int? JobStatusId { get; set; }
        public string JobStatus { get; set; }
        public int? StateId { get; set; }
        public long? CountyId { get; set; }
        public string County { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNotes { get; set; }
        public long CustomerAddressId { get; set; }
        public string AdTypeOtherOption { get; set; }
        public string AdTypeWebSource { get; set; }
        public string ZipCode { get; set; }
        public bool IsAuto { get; set; }
        public string PONumber { get; set; }
        public string ReceiptNumber { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string EquipmentName { get; set; }
        public string ApartmentSuite { get; set; }
        public long BookedByUserId { get; set; }
        public string BuzzerCode { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string CalledInBy { get; set; }
        public string ContactPerson { get; set; }
        public string DateIntervalType { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public bool pending { get; set; }
        public string alarmTime { get; set; }
        public string OnDate { get; set; }
        public string ChangedBy { get; set; }
        public string ExpectedDateTime { get; set; }
        [DataType(DataType.Date)]
        public string ExpectedDate { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string Notes { get; set; }
        public string CreatedOn { get; set; }
        public string StoreAddress { get; set; }
        public string StoreNumber { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }
        public string StoreCounty { get; set; }
        public string StoreCountry { get; set; }
        public string StoreLocationName { get; set; }
        public string StoreNotes { get; set; }
        public double payable { get; set; }
        public double Markup { get; set; }
        public string TimeDispatched { get; set; }
        public string ContractorName { get; set; }
        public string ContractorPhone { get; set; }
        public int ContractorId { get; set; }
        public bool Search { get; set; }
        public bool TaxExempt { get; set; }
        public bool IsCOW { get; set; }
        public string WorkOrder2 { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool Locked { get; set; }
        public string ExpectedFromTime { get; set; }
        public string ExpectedToTime { get; set; }
        public string BookedFromTime { get; set; }
        public string BookedToTime { get; set; }
        public string DispatchBoardType { get; set; }
        public string CurrentStatus { get; set; }
        public string AdName { get; set; }
        public string NTEAmount { get; set; }
        public string CustomerNTEAmount { get; set; }
        public string BookedByUserName { get; set; }
        public string PrimaryContractor { get; set; }
        public string IVRNumber { get; set; }
        public string IVRPin { get; set; }
        public bool EstimateEmailed { get; set; }
        public bool EstimatePrinted { get; set; }
        public string JobDescription { get; set; }
        public string SpecialInstructions { get; set; }

        public bool IsEmergency { get; set; }
        public string Ask { get; set; }
        public bool InvoiceExist { get; set; }
        public List<JobContractorMappingModel> Contractors { get; set; }

        public bool ReceiptNotExist { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }

        public string HistoricalData { get; set; }
        public string TechFirstName { get; set; }
        public string TechLastName { get; set; }
        public string TechCompanyName { get; set; }
        public string POTrackingNumber { get; set; }
        public bool isServiceChannelJob { get; set; }
        public string ServiceChannelStatus { get; set; }
        public bool cbInState { get; set; }
        public bool cbOutOfState { get; set; }
        public bool cbCitiBank { get; set; }
        public bool cbAissJobs { get; set; }
        public bool cbProjects { get; set; }
        public string RemainingMinutes { get; set; }
        public int RemainingMinutesInt { get; set; }
        public string TimeZoneCode { get; set; }
        public string TimeZoneName { get; set; }
        public string CustomerWrapupNotes { get; set; }
        public string TimeInCurrentStatus { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal ReceiptTotal { get; set; }
        public bool PreferredMethodOfCummunication { get; set; }
        public string NotificationName { get; set; }
        public string NotificationLastName { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationEmail { get; set; }
        public bool UpdateOnCreated { get; set; }
        public bool UpdateOnCompleted { get; set; }
        public bool UpdateOnDispatched { get; set; }
        public bool UpdateOnDelay { get; set; }

        public bool UpdateOnAssigned { get; set; }
        public bool UpdateOnReturn { get; set; }
        public bool UpdateOnPartsOnOrder { get; set; }
        public string otherLastNames { get; set; }
        public string OtherFirstNames { get; set; }
        public string otherTitles { get; set; }
        public string otherEmails { get; set; }
        public bool SendUpdateInCustomerPortal { get; set; }
        public bool SendUpdateInCustomerEmail { get; set; }

        public bool CustomerWebAddress { get; set; }
        public bool IsIdle { get; set; }
        public bool IsMobileNotification { get; set; }
        public bool IsWarrantyBanner { get; set; }
        public string ContractorBusinessName { get; set; }
        public bool? IsTangible { get; set; }
        public bool? ExcludeWallMartJobs { get; set; }
        public string IsFirstLine { get; set; }
        public string ContractorCompany { get; set; }
        public string CurrentUserName { get; set; }
        public string PreviousUpdate { get; set; }
        public string ETA { get; set; }
        public bool HasApprovalPermission { get; set; }
        public bool IsApproved { get; set; }
        public bool UpdatedOnAccepted { get; set; }
        public bool UpdatedOnAssigned { get; set; }
        public bool UpdatedOnDispatch { get; set; }
        public bool UpdatedOnReturn { get; set; }
        public bool UpdatedOnPartsOnOrder { get; set; }
        public bool UpdatedOnFollowUp { get; set; }
        public bool UpdatedOnPictures { get; set; }
        public bool UpdatedOnComplete { get; set; }
        public bool HasAISSAssigned { get; set; }
        public bool CanEditEmergencyCheckbox { get; set; }
        public string SearchType { get; set; }
        public bool CanAccessInvoices { get; set; }
        public string AutoUpdateCustomer { get; set; }
        public decimal? CustomerTripCharges { get; set; }
        public decimal? CustomerHourlyLabour { get; set; }
        public bool HasUrgentNote { get; set; }
        public string UrgentNoteDetails { get; set; }
        public string StoreUrgentNoteDetails { get; set; }
        public string bubbleHeight { get; set; }
        public bool Dispatch { get; set; }
        public bool DispatchManager { get; set; }
        public bool Accounting { get; set; }
        public bool CSR { get; set; }
        public string estimateCreated { get; set; }
        public string InvoiceCreated { get; set; }
        public string PaymentCreated { get; set; }
        public string CommunicationCreated { get; set; }
        public string PurchaseOrderCreated { get; set; }
    }

    public class MainCallSlipGridModel
    {
        public string CustomerName { get; set; }
        public long Id { get; set; }
        public bool IsIdle { get; set; }
        public string JobStatus { get; set; }
        public double? JobStatusCode { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public string ETA { get; set; }
        public string FromTime { get; set; }
        public string ExpectedDateTime { get; set; }
        public string ToTime { get; set; }
        [DataType(DataType.Date)]
        public string ExpectedDate { get; set; }
        public string estimateCreated { get; set; }
        public string InvoiceCreated { get; set; }
        public string CreatedOn { get; set; }
        public bool IsEmergency { get; set; }
        public string City { get; set; }
        public string StateAbbreviation { get; set; }
        public string StoreLocationName { get; set; }
        public string JobDescription { get; set; }
        public string EquipmentName { get; set; }
        public string PrimaryContractor { get; set; }
        public string ContractorBusinessName { get; set; }
        public string TimeZoneCode { get; set; }
        public string TimeZoneName { get; set; }
        public string RemainingMinutes { get; set; }
        public int RemainingMinutesInt { get; set; }
        public string TimeInCurrentStatus { get; set; }
    }

    public class GridModel{
        public List<MainCallSlipGridModel> listCallslips { get; set; }
        public int Total { get; set; }
    }

    public class DispatchBoardModel
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public long ContractorId { get; set; }
        //public GridModel<MainCallSlipGridModel> CallSlips { get; set; }
        //public GridModel<ContractorModel> Contractors { get; set; }
        //public GridModel<TechniciansModel> Technicians { get; set; }
    }

    public enum AdTypess
    {
        PaymentMethod = 1,
        AdType = 2,
    }

    public enum DateIntervalTypes
    {
        At = 1,
        By = 2,
        Between = 3
    }

    public class CubModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string JobType { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
    }

    public class DelayingJobsModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string TimeScheduled { get; set; }
        public string Contractors { get; set; }
    }

    public class JobsExportModel
    {
        public long JobID { get; set; }
        public string WorkOrderNumber { get; set; }
        public string WorkOrderNumber2 { get; set; }
        public string CustomerName { get; set; }
        public string StoreNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
        public string Contractor { get; set; }
        public string CompanyName { get; set; }
        public string BookedBy { get; set; }
        public string CalledInBy { get; set; }
        public decimal? NTE { get; set; }
        public string AdNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal ReceiptTotal { get; set; }
        public string InvoiceWeekQuarterYear { get; set; }
        public string RceiptWeekQuarterYear { get; set; }
        public string IsAutoJob { get; set; }
        public string CustomerType { get; set; }
        public string WebSource { get; set; }
        public string OtherAdTypeOption { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmailAddress { get; set; }
        public string DispatchedOn { get; set; }

        public string ServiceDate { get; set; }
        public string Time { get; set; }
        public string TCS { get; set; }
        public string Equipment { get; set; }


        public string JobType { get; set; }
        public string CustomerPhone { get; set; }
        public string PurchaseOrder { get; set; }

        public string Country { get; set; }
        public string TaxExempt { get; set; }
        public string Fax { get; set; }





    }


    public class EquipmentExportModel
    {
        public string Equipment { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string DateOfJob { get; set; }
        public string StoreNumber { get; set; }
        public string InvoiceTotal { get; set; }

    }

    public class JobActivityLogExportModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string JobId { get; set; }
        public string LogMessage { get; set; }
        public string TimeStamp { get; set; }
        public string Details { get; set; }
        public string PrevStatus { get; set; }
        public string NewStatus { get; set; }

    }

    public class dropdownLists
    {
        public dropdownLists()
        {
            States = new List<State>();
            Countries = new List<Country>();
            Counties = new List<County>();
            Equipments = new List<Equipment>();
            PaymentMethods = new List<PaymentMethod>();
            AdTypes = new List<AdType>();
            JobTypes = new List<JobType>();
            JobStatuses = new List<JobStatus>();
            Contractors = new List<SelectListItem>();
            DicrepencyList = new List<SelectListItem>();
        }
        public List<State> States { get; set; }
        public List<Country> Countries { get; set; }
        public List<County> Counties { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public List<AdType> AdTypes { get; set; }
        public List<JobType> JobTypes { get; set; }
        public List<JobStatus> JobStatuses { get; set; }
        public List<SelectListItem> Contractors { get; set; }
        public List<SelectListItem> DicrepencyList { get; set; }
    }

    public class Boards
    {
        public bool InState { get; set; }
        public bool OutOfState { get; set; }
        public bool Citibank { get; set; }
        public bool Aiss { get; set; }
        public bool Project { get; set; }
        public string CallSlipId { get; set; }
        public string prevCallSlipId { get; set; }

    }

    public class MultiEstimates
    {
        public string CallSlipId { get; set; }
        public long EstimateNumber { get; set; }
        public string PartName { get; set; }
        public string CustomerName { get; set; }
        public string JobPartId { get; set; }
    }

    public class TableDataModel
    {
        public string CallSlipId { get; set; }
        public string storeNo { get; set; }
        public string address { get; set; }
        public string CustomerId { get; set; }
    }

    public class EmailLogModel
    {
        public long Id { get; set; }
        public string customer { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string to { get; set; }
        public System.DateTime date { get; set; }
        public string from { get; set; }
        public string Sender { get; set; }
        public string MailedOn { get; set; }
        public string LogMessage { get; set; }
        public string CCEmailAddresses { get; set; }


    }

    public class JobNotesModel
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public string LinkJobId { get; set; }
        public string Notes { get; set; }
        public bool RelatedToInvoice { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Jobdescription { get; set; }
        public bool TechSummary { get; set; }
        public DateTime? BookedOn { get; set; }

        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    public class DocumentModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string CreatedOn { get; set; }
        public string CustomerName { get; set; }
        public string JobZipCode { get; set; }
        public string City { get; set; }
        public string PONumber { get; set; }
        public int? CustomerDocumentType { get; set; }
        public int? ContractorDocumentType { get; set; }
        public String ExpiryDate { get; set; }
        public bool DocumentVerified { get; set; }
        public string LicenseNumber { get; set; }
        public string VerifiedBy { get; set; }
        public string LastUpdateOn { get; set; }
        public string InsuranceType { get; set; }
        public string MeetingMinimumRequiremenmt { get; set; }
    }

    public class NotesDocumentsModel
    {
        public List<JobNotesModel> notesList { get; set; }
        public List<DocumentModel> docsList { get; set; }
    }
    public enum DocumentType
    {
        Invoice = 1,
        Estimate = 2,
        PurchaseOrder = 3,
        Other = 4
    }

    public class SMSLogModel
    {
        public long Id { get; set; }
        public long? JobId { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string DateCreated { get; set; }
        public DateTime DateCreatedDate { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedByContractor { get; set; }
        public string SentStatus { get; set; }
        public bool Sent { get; set; }
        public bool UserAlerted { get; set; }
        public string BusinessName { get; set; }
        public int total { get; set; }

    }

    public class ProgressBarModel
    {
        public bool RequireUpdates { get; set; }
        public bool SendUpdateInCustomerPortal { get; set; }
        public bool SendUpdateInCustomerEmail { get; set; }
        public bool UpdateOnCreated { get; set; }
        public bool UpdateOnCompleted { get; set; }
        public bool UpdateOnDispatched { get; set; }
        public bool UpdateOnDelayed { get; set; }
        public bool UpdateOnAssigned { get; set; }
        public bool UpdatedOnAcceptedInPortal { get; set; }
        public bool UpdatedOnAssignedInPortal { get; set; }
        public bool UpdatedOnDispatchInPortal { get; set; }
        public bool UpdatedOnDelayedInPortal { get; set; }
        public bool UpdatedOnCompleteInPortal { get; set; }
        public bool UpdatedOnAcceptedInEmail { get; set; }
        public bool UpdatedOnAssignedInEmail { get; set; }
        public bool UpdatedOnDispatchInEmail { get; set; }
        public bool UpdatedOnDelayedInEmail { get; set; }
        public bool UpdatedOnCompleteInEmail { get; set; }

    }

    public class JobStatusHistoryModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long JobId { get; set; }
        public string LogMessage { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public Nullable<double> PrevStatus { get; set; }
        public Nullable<double> NewStatus { get; set; }
        public string UserName { get; set; }
        public string PreviousStatusName { get; set; }
        public string NewStatusName { get; set; }
        public string NewStatusColorHex { get; set; }
        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }

    public class TablesList
    {
        public List<EmailLogModel> emailList { get; set; }
        public List<SMSLogModel> smsList { get; set; }
        public List<CallSlipModel> locationList { get; set; }
        public List<CallSlipModel> ContractorActiveList { get; set; }
        public List<CallSlipModel> TechnicianActiveList { get; set; }

    }
}