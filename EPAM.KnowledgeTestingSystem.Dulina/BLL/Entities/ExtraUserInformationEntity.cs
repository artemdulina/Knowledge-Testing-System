using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ExtraUserInformationEntity
    {
        public int Id { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? FinishTime { get; set; }
    }
}
