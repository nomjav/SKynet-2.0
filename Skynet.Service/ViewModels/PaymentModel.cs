using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.ViewModels
{
    public class PaymentModel
    {
        public double Amount { get; set; }
        public string DatePaid { get; set; }
        public string PaymentMethod { get; set; }
        public string Approval { get; set; }
        public string Notes { get; set; }
        public string UserName { get; set; }
        public string ReceiptNumber { get; set; }
    }



    public class CustomerCreditCardModel
    {
        public long CardId { get; set; }
        public string NameOnCard { get; set; }
        public string AddressOnCard { get; set; }
        public string CardCity { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public string CardZip { get; set; }


        public string CustomerCreditCardNumber { get; set; }
        public string cvv { get; set; }
        public string CreditCardExpireMonth { get; set; }
        public string CreditCardExpireYear { get; set; }
        public string CardType { get; set; }
        public long PaymentMethodId { get; set; }
        public bool CardNotRun { get; set; }

    }
}
