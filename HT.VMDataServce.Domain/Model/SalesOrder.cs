using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.Model
{
    public class SalesOrder
    {
        public List<OrderDetails> OrderDetails { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
