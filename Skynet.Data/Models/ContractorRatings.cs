using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ContractorRatings
    {
        public long Id { get; set; }
        public long ContractorId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public int Ratings { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual User User { get; set; }
    }
}
