using BLL.Entities;
using BLL.Services;
using System.Web.Mvc;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;

        public HomeController(IUserService service)
        {
            userService = service;
        }

        // GET: Home
        public ActionResult Index()
        {
            userService.CreateUser(new UserEntity()
            {
                Name = "Success!!!"
            });

            return View();
        }
    }
}