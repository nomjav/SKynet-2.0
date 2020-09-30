using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PartsUserFavourites
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? UserId { get; set; }
        public int Type { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}
