using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class RealizationPriceQty
    {
        public int RealizationId { get; set; }
        public int ProductId { get; set; }
        public decimal PriceSelling { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Realization Realization { get; set; }
    }
}
