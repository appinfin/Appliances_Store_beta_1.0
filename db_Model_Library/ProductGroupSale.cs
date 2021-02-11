using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace db_Model_Library
{
    [Keyless]
    public class ProductGroupSale
    {
        //[Required]
        public virtual ProductGroup ProductsGroups { get; set; }
        public float Sale { get; set; }
    }
}
