using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Common;
using System;
using NLog;
using MvcKnowledgeSystem.Models;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace MvcKnowledgeSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //logger.Info("Application_PostAuthenticateRequest");

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.UserId = serializeModel.UserId;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;
                newUser.roles = serializeModel.roles;

                Request.RequestContext.HttpContext.User = newUser;
            }

        }
    }
}
