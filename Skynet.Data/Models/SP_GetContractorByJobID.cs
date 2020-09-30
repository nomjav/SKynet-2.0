using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.Models
{
    public class SP_GetContractorByJobID
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public Nullable<int> Techsummary { get; set; }
        public string BusinessName { get; set; }
        public string ContractorName { get; set; }
        public string MainCompanyPhone { get; set; }
        public double Commission { get; set; }
        public decimal NTEAMOUNT { get; set; }
        public decimal InitialNteAmount { get; set; }
        public bool isPrimary { get; set; }
        public Nullable<decimal> ContractorRating { get; set; }
        public Nullable<int> TotalContractorRating { get; set; }
        public Nullable<int> HasTechnicians { get; set; }
        public Nullable<bool> isFifityFifty { get; set; }
        public string RecentNote { get; set; }
        public Nullable<int> ReceiptExists { get; set; }
    }
}
