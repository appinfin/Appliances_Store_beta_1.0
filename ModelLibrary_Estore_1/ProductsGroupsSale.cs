using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class ProductsGroupsSale
    {
        public int ProductsGroupsProductGroupId { get; set; }
        public double Sale { get; set; }

        public virtual ProductsGroup ProductsGroupsProductGroup { get; set; }
    }
}
