using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PermissionRecordRoleMapping
    {
        public int PermissionRecordId { get; set; }
        public int RoleId { get; set; }

        public virtual PermissionRecord PermissionRecord { get; set; }
        public virtual Role Role { get; set; }
    }
}
