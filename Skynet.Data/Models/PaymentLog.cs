using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class PaymentLog
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public string StatusInfo { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long JobPaymentId { get; set; }
        public string FullError { get; set; }
        public string Request { get; set; }

        public virtual JobPayment JobPayment { get; set; }
    }
}
