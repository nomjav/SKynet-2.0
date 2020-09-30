using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ContractorCreditHistory
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public string Credits { get; set; }
        public string Terms { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
