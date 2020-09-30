using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ServicesCategory
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int OfficeId { get; set; }
    }
}
