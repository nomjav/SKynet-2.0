using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.Models
{
    public class SP_GetJobCount
    {
        public string Name { get; set; }
        public Nullable<int> JobCount { get; set; }
        public int Id { get; set; }
        public string BackgroundColorHex { get; set; }
        public string FontColorHex { get; set; }
        public double Code { get; set; }
    }
}
