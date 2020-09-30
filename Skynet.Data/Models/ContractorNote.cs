using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ContractorNote
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ContractorId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual User User { get; set; }
    }
}
