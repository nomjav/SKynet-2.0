using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class QuickCallSlip
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
