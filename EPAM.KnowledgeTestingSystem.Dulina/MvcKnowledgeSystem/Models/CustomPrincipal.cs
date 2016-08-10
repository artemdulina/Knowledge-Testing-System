using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using BLL.Entities;

namespace MvcKnowledgeSystem.Models
{
    public class CustomPrincipal : IPrincipal
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEntity[] roles { get; set; }
        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            /*if (roles.Any(r => roles.Contains(role)))
            {
                return true;
            }*/
            return false;
        }
    }
}