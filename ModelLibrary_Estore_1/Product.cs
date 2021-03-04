using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Product
    {
        public Product()
        {
            RealizationPriceQties = new HashSet<RealizationPriceQty>();
            SupplyPriceQties = new HashSet<SupplyPriceQty>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? ProductSale { get; set; }
        public int? BrandsBrandId { get; set; }
        public int? ProductsGroupsProductGroupId { get; set; }
        public int? UnitsIdUnit { get; set; }

        public virtual Brand BrandsBrand { get; set; }
        public virtual ProductsGroup ProductsGroupsProductGroup { get; set; }
        public virtual Unit UnitsIdUnitNavigation { get; set; }
        public virtual ICollection<RealizationPriceQty> RealizationPriceQties { get; set; }
        public virtual ICollection<SupplyPriceQty> SupplyPriceQties { get; set; }
    }
}
