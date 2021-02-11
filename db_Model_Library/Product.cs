using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Product
    {
        //public Product()
        //{
        //    RealizationPriceQtys = new HashSet<RealizationPriceQty>();
        //    SupplyPriceQtys = new HashSet<SupplyPriceQty>();
        //}
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(32)]
        public string ProductName { get; set; }
        public float? ProductSale { get; set; }

        public virtual Brand Brands { get; set; }
        public virtual ProductGroup ProductsGroups { get; set; }
        public virtual Unit Units { get; set; }

        //public virtual ICollection<RealizationPriceQty> RealizationPriceQtys { get; set; }
        //public virtual ICollection<SupplyPriceQty> SupplyPriceQtys { get; set; }
    }
}
