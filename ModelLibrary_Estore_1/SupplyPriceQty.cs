using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class SupplyPriceQty
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public decimal PricePurchase { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
