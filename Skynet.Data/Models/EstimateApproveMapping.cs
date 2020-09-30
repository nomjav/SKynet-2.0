using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.Models
{
    public partial class EstimateApproveMapping
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long EstimateNumber { get; set; }
        public bool Approved { get; set; }
    }
}
