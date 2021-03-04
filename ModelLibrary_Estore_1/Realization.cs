using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Realization
    {
        public Realization()
        {
            RealizationPriceQties = new HashSet<RealizationPriceQty>();
        }

        public int RealizationId { get; set; }
        public DateTime Date { get; set; }
        public int CounterpartysCounterpartyId { get; set; }
        public int PersonnelsPersonnelId { get; set; }
        public int StoragesStorageId { get; set; }

        public virtual Counterparty CounterpartysCounterparty { get; set; }
        public virtual Personnel PersonnelsPersonnel { get; set; }
        public virtual Storage StoragesStorage { get; set; }
        public virtual ICollection<RealizationPriceQty> RealizationPriceQties { get; set; }
    }
}
