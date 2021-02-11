using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int IdUnit { get; set; }

        [Required]
        [StringLength(16)]
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
