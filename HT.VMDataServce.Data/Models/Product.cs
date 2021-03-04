using System;
using System.Collections.Generic;

#nullable disable

namespace HT.VMDataServce.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            ProductDetails = new HashSet<ProductDetails>();
            ProductInventories = new HashSet<ProductInventory>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
