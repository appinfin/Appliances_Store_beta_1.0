using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace db_Model_Library
{
    public class ProductGroup
    {
        public ProductGroup()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int ProductGroupId { get; set; }
        [Required]
        [StringLength(32)]
        public string ProductGroupName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
