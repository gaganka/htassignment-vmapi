using System;
using System.Collections.Generic;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class OrderPayment
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? AmountReturned { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
