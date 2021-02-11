﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(32)]
        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}