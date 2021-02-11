using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Counterparty
    {
        public Counterparty()
        {
            Realizations = new HashSet<Realization>();
            Supplies = new HashSet<Supply>();
        }
        [Key]
        public int CounterpartyId { get; set; } //код контрагента
        [Required]
        [StringLength(64)]
        public string CounterpartyName { get; set; } //название контрагента
        public long? InnOgrnKpp { get; set; }

        public virtual ICollection<Realization> Realizations { get; set; } //продажи
        public virtual ICollection<Supply> Supplies { get; set; } //покупки
    }
}
