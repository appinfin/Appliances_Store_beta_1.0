using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Storage
    {
        public Storage()
        {
            Supplies = new HashSet<Supply>();
            Realizations = new HashSet<Realization>();
        }
        [Key]
        public int StorageId { get; set; }
        [Required]
        [StringLength(32)]
        public string StorageName { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
        public virtual ICollection<Realization> Realizations { get; set; }
    }
}
