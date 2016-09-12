using System.Web.Mvc;
using MvcKnowledgeSystem.Models;
using BLL.Entities;

namespace MvcKnowledgeSystem.Controllers
{
    [CustomAuthorize(Roles = new[] { RoleType.Administrator })]
    public class AdminController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult CreateTest()
        {
            return View();
        }
    }
}