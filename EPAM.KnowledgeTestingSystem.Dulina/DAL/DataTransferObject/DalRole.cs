using System.Collections.Generic;
using ORM;

namespace DAL.DataTransferObject
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }

        public RoleType Type { get; set; }

        //public virtual ICollection<DalUser> Users { get; set; }
    }
}
