using System;
using System.Collections.Generic;
using System.Text;

namespace HT.VMDataServce.Domain.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }
    }
}
