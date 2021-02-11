using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    [Keyless]
    public class RealizationPriceQty
    {
        //public RealizationPriceQty()
        //{
        //    Products = new HashSet<Product>();
        //}
        
        [Required]
        public int RealizationId { get; set; } //код покупки
        [Required]
        public int ProductId { get; set; }
        public decimal PriceSelling { get; set; }
        public float Quantity { get; set; }

        public virtual Realization Realizations { get; set; }
        public virtual Product Products { get; set; }
        
        //[Key]
        //public virtual ICollection<Product> Products { get; set; }
    }
}
