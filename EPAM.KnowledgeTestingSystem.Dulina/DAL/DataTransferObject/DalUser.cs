using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DalRole> Roles { get; set; }
    }
}
