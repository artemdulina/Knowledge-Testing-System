using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class Class1
    {
        /*public ActionResult Index(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.roles = roles;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    user.Email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    false, //pass here true, if you want to implement remember me functionality
                    userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            }

            return View(model);
        }

    }*/
    }
}