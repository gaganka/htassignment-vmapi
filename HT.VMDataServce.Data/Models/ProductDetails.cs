using System;
using System.Collections.Generic;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class ProductDetails
    {
        public ProductDetails()
        {
            ProductInventories = new HashSet<ProductInventory>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public string VendorName { get; set; }
        public string VendorContact { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
