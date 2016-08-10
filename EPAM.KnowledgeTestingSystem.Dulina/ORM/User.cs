﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
