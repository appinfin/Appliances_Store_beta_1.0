using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace db_Model_Library
{
    [Keyless]
    public class PersonnelInfo
    {
        //[Required]
        public virtual Personnel Personnels { get; set; }
        public long? Passport { get; set; }
    }
}
