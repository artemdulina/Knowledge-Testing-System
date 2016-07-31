using System.Collections.Generic;

namespace ORM
{
    public class Role
    {
        public int Id { get; set; }

        public RoleType Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
