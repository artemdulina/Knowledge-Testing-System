using BLL.Services;
using BLL.ServicesImplementations;
using DAL.RepositoryImplementations;
using ORM;
using System.Web.Mvc;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new TestingSystemContext())
            {
                IUserService service = new UserService(new UnitOfWork(db), new UserRepository(db));
                service.CreateUser(new BLL.Entities.UserEntity()
                {
                    Name = "Albahari"
                });
            }
            return View();

        }
    }
}