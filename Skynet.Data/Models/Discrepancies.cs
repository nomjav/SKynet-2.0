using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Discrepancies
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
