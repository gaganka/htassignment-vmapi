using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.Model
{
    public class OrderDetails
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }
        [JsonProperty("lineItemTotal")]
        public decimal LineItemTotal { get; set; }
    }
}
