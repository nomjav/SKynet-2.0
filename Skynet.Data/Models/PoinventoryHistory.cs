using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PoinventoryHistory
    {
        public int Id { get; set; }
        public long? JobId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? PartId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
