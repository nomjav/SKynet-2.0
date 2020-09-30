using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            PermissionRecordRoleMapping = new HashSet<PermissionRecordRoleMapping>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedByUserId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public long? LastUpdatedByUserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionRecordRoleMapping> PermissionRecordRoleMapping { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
