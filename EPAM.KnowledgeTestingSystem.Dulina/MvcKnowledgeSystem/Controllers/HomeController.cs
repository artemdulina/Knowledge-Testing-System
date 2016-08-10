using BLL.Entities;
using BLL.Services;
using NLog;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : BaseController
    {
        IUserService userService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(IUserService service)
        {
            userService = service;
        }

        public ActionResult Some()
        {
            TempData["name"] = HttpContext.User.Identity.Name;
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
            logger.Info("HomeIndex works");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            userService.CreateUser(new UserEntity()
            {
                //Username = "SuperUser",
                Username = "nbaworld",
                Email = "artem.dulina@gmail.com",
                FirstName = "Albahari",
                LastName = "Petrovich",
                Password = "789123",
                Roles = new List<RoleEntity>() { new RoleEntity() { Type = RoleType.Administrator } }
            });
            IEnumerable<UserEntity> users = userService.GetAllUserEntities();
            timer.Stop();
            ViewData["timer"] = "ViewDatas";
            TempData["timer"] = "TempDatas";
            ViewBag.Message = "ViewBag";
            Session.Add("sessionobject", 88005553535);
            //
            return View(users);
            //return RedirectToAction("Some");
        }
    }
}