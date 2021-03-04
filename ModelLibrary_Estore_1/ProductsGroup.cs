using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class ProductsGroup
    {
        public ProductsGroup()
        {
            Products = new HashSet<Product>();
        }

        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
