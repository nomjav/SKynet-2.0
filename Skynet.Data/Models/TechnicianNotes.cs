using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TechnicianNotes
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TechnicianId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Technicians Technician { get; set; }
        public virtual User User { get; set; }
    }
}
