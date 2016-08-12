using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using BLL.Entities;
using NLog;

namespace MvcKnowledgeSystem.Models
{
    public class CustomPrincipal : IPrincipal
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEntity[] roles { get; set; }
        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string userName)
        {
            if (userName == "Guest")
            {
                Identity = new GuestIdentity();
            }
            else
            {
                Identity = new GenericIdentity(userName);
            }
        }

        public bool IsInRole(string roles)
        {
            return false;
        }

        public bool IsInRole(RoleType[] roles)
        {
            if (roles.Any(r => this.roles.Select(s => s.Type).Contains(r)))
            {
                return true;
            }

            return false;
        }
    }
}