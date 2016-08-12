using System.Collections.Generic;
using DAL.DataTransferObject;

namespace BLL.Entities
{
    public class RoleEntity : IEntity
    {
        public int Id { get; set; }

        public RoleType Type { get; set; }
    }
}
