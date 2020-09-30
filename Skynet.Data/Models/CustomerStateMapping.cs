using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class CustomerStateMapping
    {
        public long CustomerId { get; set; }
        public int StateId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
    }
}
