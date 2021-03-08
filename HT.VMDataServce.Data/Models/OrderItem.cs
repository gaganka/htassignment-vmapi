using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal LineItemTotal { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
