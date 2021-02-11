using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace db_Model_Library
{
    public class Realization
    {
        //public Realization()
        //{
        //    RealizationPriceQtys = new HashSet<RealizationPriceQty>();
        //}
        [Key]
        public int RealizationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual Counterparty Counterpartys { get; set; }
        [Required]
        public virtual Personnel Personnels { get; set; }
        [Required]
        public virtual Storage Storages { get; set; }

        //public virtual ICollection<RealizationPriceQty> RealizationPriceQtys { get; set; }
    }
}
