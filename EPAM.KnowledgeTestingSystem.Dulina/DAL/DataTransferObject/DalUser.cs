using System.Collections.Generic;

namespace DAL.DataTransferObject
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<DalRole> Roles { get; set; }

        public DalExtraUserInformation Information { get; set; }
    }
}
