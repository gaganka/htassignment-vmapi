using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.Model
{
    public class SalesOrder
    {
        [JsonProperty("orderDetails")]
        public List<OrderDetails> OrderDetails { get; set; }
        
        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}
