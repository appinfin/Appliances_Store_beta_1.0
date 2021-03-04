using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Storage
    {
        public Storage()
        {
            Realizations = new HashSet<Realization>();
            Supplies = new HashSet<Supply>();
        }

        public int StorageId { get; set; }
        public string StorageName { get; set; }

        public virtual ICollection<Realization> Realizations { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
