using System;
using System.Collections.Generic;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class ProductInventory
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ProductDetailsId { get; set; }
        public int QtyInStock { get; set; }
        public int ReorderLevel { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
