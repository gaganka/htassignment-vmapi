using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.Model
{
    public class PaymentDetails
    {
        [JsonProperty("paymentId")]
        public int PaymentId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("amountPaid")]
        public decimal AmountPaid { get; set; }

        [JsonProperty("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonProperty("amountReturned")]
        public decimal AmountReturned { get; set; }
    }
}
