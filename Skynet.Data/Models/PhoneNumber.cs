using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PhoneNumber
    {
        public long Id { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public long UserId { get; set; }
    }
}
