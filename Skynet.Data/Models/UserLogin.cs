using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class UserLogin
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }

        public virtual User User { get; set; }
    }
}
