using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ManagerSheet
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime LastUpdate { get; set; }
        public long UploadedBy { get; set; }
        public string Type { get; set; }
    }
}
