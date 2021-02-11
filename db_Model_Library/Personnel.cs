using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Personnel
    {
        public Personnel()
        {
            Realizations = new HashSet<Realization>();
        }
        [Key]
        public int PersonnelId { get; set; }
        [Required]
        [StringLength(64)]
        public string PersonnelName { get; set; }

        public virtual ICollection<Realization> Realizations { get; set; }
    }
}
