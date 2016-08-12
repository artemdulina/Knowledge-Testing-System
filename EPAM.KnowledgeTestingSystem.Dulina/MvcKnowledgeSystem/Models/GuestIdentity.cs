using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class GuestIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return "Guest";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "Guest";
            }
        }
    }
}