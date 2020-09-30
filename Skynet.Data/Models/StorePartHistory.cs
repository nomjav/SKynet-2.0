using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class StorePartHistory
    {
        public long Id { get; set; }
        public long? PartId { get; set; }
        public long CustomerId { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public int? Type { get; set; }
        public decimal Total { get; set; }
        public long JobId { get; set; }
        public long StoreId { get; set; }
        public string StoreNumber { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Job Job { get; set; }
        public virtual Store Store { get; set; }
    }
}
