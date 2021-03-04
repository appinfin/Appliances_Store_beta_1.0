using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int IdUnit { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
