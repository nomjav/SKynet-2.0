using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Setting
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public DateTime DateModifiedUtc { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
