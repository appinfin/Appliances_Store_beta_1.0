using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class Personnel
    {
        public Personnel()
        {
            Realizations = new HashSet<Realization>();
        }

        public int PersonnelId { get; set; }
        public string PersonnelName { get; set; }

        public virtual ICollection<Realization> Realizations { get; set; }
    }
}
