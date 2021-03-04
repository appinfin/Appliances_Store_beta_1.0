using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Supply
    {
        public Supply()
        {
            SupplyPriceQties = new HashSet<SupplyPriceQty>();
        }

        public int SupplyId { get; set; }
        public DateTime Date { get; set; }
        public int CounterpartysCounterpartyId { get; set; }
        public int StoragesStorageId { get; set; }

        public virtual Counterparty CounterpartysCounterparty { get; set; }
        public virtual Storage StoragesStorage { get; set; }
        public virtual ICollection<SupplyPriceQty> SupplyPriceQties { get; set; }
    }
}
