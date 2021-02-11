using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Supply
    {
        //public Supply()
        //{
        //    SupplyPriceQtys = new HashSet<SupplyPriceQty>();
        //}
        [Key]
        public int SupplyId { get; set; } //код покупки
        public DateTime Date { get; set; } // дата

        //[Required]
        public virtual Counterparty Counterpartys { get; set; } //внешний ключ контрагент
        //[Required]
        public virtual Storage Storages { get; set; } //внешний ключ склад

        //public virtual ICollection<SupplyPriceQty> SupplyPriceQtys { get; set; }
    }
}
