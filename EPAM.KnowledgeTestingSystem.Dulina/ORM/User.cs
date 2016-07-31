using System.Collections.Generic;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
