using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BLL.Entities;
using System.Web.Routing;
using NLog;

namespace MvcKnowledgeSystem.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected virtual CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }

        public new RoleType[] Roles { get; set; }
        public new UserEntity[] Users { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            logger.Info("CustomAuthorizeAttribute.OnAuthorization");
            if (!CurrentUser.IsInRole(Roles))
            {
                logger.Info("!CurrentUser.IsInRole(Roles)");
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }
    }
}