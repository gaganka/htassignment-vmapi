using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class OrderPayment
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal AmountPaid { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? AmountReturned { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
