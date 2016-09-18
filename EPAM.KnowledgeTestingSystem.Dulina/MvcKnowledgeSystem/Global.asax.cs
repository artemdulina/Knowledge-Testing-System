using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Common;
using System;
using NLog;
using MvcKnowledgeSystem.Models;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using BLL.Entities;
using System.Web.Optimization;

namespace MvcKnowledgeSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //logger.Info("Application_PostAuthenticateRequest");

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            CustomPrincipal newUser;
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                newUser = new CustomPrincipal(authTicket.Name);
                newUser.UserId = serializeModel.UserId;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;
                newUser.roles = serializeModel.roles;

                Request.RequestContext.HttpContext.User = newUser;
            }
            else
            {
                newUser = new CustomPrincipal("Guest");
                newUser.roles = new RoleEntity[] { new RoleEntity() { Type = RoleType.Guest } };

                Request.RequestContext.HttpContext.User = newUser;
                //logger.Info("elseelseelseelseelseelseelse"+newUser.Identity.IsAuthenticated);
            }

        }
    }
}
