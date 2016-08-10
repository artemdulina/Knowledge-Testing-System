using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;

namespace MvcKnowledgeSystem.Controllers
{

    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
    }
}