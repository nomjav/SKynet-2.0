using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PermissionRecordUserMapping
    {
        public int PermissionRecordId { get; set; }
        public long UserId { get; set; }

        public virtual PermissionRecord PermissionRecord { get; set; }
        public virtual User User { get; set; }
    }
}
