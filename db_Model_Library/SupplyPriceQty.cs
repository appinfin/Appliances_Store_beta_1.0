using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace db_Model_Library
{
    [Keyless]
    public class SupplyPriceQty
    {
        //public SupplyPriceQty()
        //{
        //    Products = new HashSet<Product>();
        //}

        [Required]
        public int SupplyId { get; set; } //код покупки
        [Required]
        public int ProductId { get; set; }
        public decimal PricePurchase { get; set; }
        public float Quantity { get; set; }

        public virtual Supply Supplys { get; set; }
        public virtual Product Products { get; set; }

        
        //[Key]
        //public virtual ICollection<Product> Products { get; set; }
    }
}
