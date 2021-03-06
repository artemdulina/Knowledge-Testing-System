﻿using BLL.Entities;
using BLL.Services;
using MvcKnowledgeSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKnowledgeSystem.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                UserEntity user = userService.GetUserEntity(model.Username);
                if (user != null)
                {
                    var roles = user.Roles.ToArray();
                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();

                    if (user.Password == model.Password)
                    {
                        serializeModel.UserId = user.Id;
                        serializeModel.FirstName = user.FirstName;
                        serializeModel.LastName = user.LastName;
                        serializeModel.roles = roles;

                        string userData = JsonConvert.SerializeObject(serializeModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        user.Username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(15),
                        false, //pass here true, if you want to implement remember me functionality
                        userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);

                        //if (!string.IsNullOrEmpty(returnUrl))
                        //{
                        //    return Redirect(returnUrl);
                        //}

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Incorrect username and/or password");
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}