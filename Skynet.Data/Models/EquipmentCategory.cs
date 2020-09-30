using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class EquipmentCategory
    {
        public EquipmentCategory()
        {
            Equipment = new HashSet<Equipment>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long LastUpdatedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User LastUpdatedByUser { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
