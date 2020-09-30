using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class BlockedSlots
    {
        public int BlockedId { get; set; }
        public string BlockedSlot { get; set; }
        public string BlockedReason { get; set; }
        public string BlockedHeight { get; set; }
        public DateTime? Date { get; set; }
        public string DataValue { get; set; }
    }
}
