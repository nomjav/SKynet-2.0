using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skynet.Service.ViewModels
{
    public class JobContractorMappingModel
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public long SubContractorId { get; set; }
        public long JobId { get; set; }
        public double? Commission { get; set; }
        public string ContractorName { get; set; }
        public string BusinessName { get; set; }
        public List<TechniciansModel> TechniciansList { get; set; }
        public string Phone { get; set; }
        public bool IsPrimary { get; set; }
        public decimal? NTEAmount { get; set; }
        public bool ReceiptExist { get; set; }
        public long ReceiptId { get; set; }
        public string State { get; set; }
        public string RecentNotes { get; set; }
        public bool IsFiftyFifty { get; set; }
        public double ContractorRatings { get; set; }
        public long TotalContractorRatings { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool hasSubContractors { get; set; }
        public decimal? OriginalNTEAmount { get; set; }
        public bool hasTechSumary { get; set; }

    }
}