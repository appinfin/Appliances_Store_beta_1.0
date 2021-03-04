using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Counterparty
    {
        public Counterparty()
        {
            Realizations = new HashSet<Realization>();
            Supplies = new HashSet<Supply>();
        }

        public int CounterpartyId { get; set; }
        public string CounterpartyName { get; set; }
        public long? InnOgrnKpp { get; set; }

        public virtual ICollection<Realization> Realizations { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
