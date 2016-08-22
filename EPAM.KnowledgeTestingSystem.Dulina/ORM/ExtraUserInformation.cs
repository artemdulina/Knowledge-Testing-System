using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ExtraUserInformation
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? FinishTime { get; set; }

        public virtual User User { get; set; }
    }
}
