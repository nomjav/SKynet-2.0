using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.Models
{
    public partial class vwJobs
    {
        public vwJobs()
        {
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.JobContractorMapping = new HashSet<JobContractorMapping>();
            this.JobPayments = new HashSet<JobPayment>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerType { get; set; }
        public Nullable<int> JobStatusId { get; set; }
        public string JobStatus { get; set; }
        public double JobStatusCode { get; set; }
        public string JobStatusBackgroundColor { get; set; }
        public string JobStatusFontColor { get; set; }
        public Nullable<int> DateIntervalType { get; set; }
        public Nullable<System.TimeSpan> ToTime { get; set; }
        public Nullable<System.DateTime> DispatchedTime { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string TimeZoneCode { get; set; }
        public string TimeZoneName { get; set; }
        public Nullable<long> StoreId { get; set; }
        public string StoreNumber { get; set; }
        public string PrimaryContractor { get; set; }
        public string ContractorFirstName { get; set; }
        public string ContractorLastName { get; set; }
        public string ContractorBusinessName { get; set; }
        public int JobTypeId { get; set; }
        public string Phone { get; set; }
        public string PONumber { get; set; }
        public string Address { get; set; }
        public bool Locked { get; set; }
        public Nullable<System.DateTime> ExpectedDate { get; set; }
        public Nullable<System.TimeSpan> ExpectedDateTime { get; set; }
        public string JobDescription { get; set; }
        public bool IsAuto { get; set; }
        public int StatusOrder { get; set; }
        public Nullable<bool> IsEmergency { get; set; }
        public Nullable<int> TimeInCurrentStatus { get; set; }
        public string EquipmentName { get; set; }
        public int IsIdle { get; set; }
        public string WorkOrder2 { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<JobContractorMapping> JobContractorMapping { get; set; }
        public virtual ICollection<JobPayment> JobPayments { get; set; }
    }
}
