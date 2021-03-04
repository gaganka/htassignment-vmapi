using System;
using System.Collections.Generic;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderPayments = new HashSet<OrderPayment>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderValue { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
    }
}
