using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class PersonnelsInfo
    {
        public int PersonnelsPersonnelId { get; set; }
        public long? Passport { get; set; }

        public virtual Personnel PersonnelsPersonnel { get; set; }
    }
}
