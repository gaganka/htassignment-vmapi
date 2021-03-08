using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.Model
{
    public class PaymentDetails
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountReturned { get; set; }
    }
}
