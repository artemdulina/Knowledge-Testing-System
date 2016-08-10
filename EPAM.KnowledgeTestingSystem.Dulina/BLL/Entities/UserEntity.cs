using DAL.DataTransferObject;
using System.Collections.Generic;

namespace BLL.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }
    }
}
