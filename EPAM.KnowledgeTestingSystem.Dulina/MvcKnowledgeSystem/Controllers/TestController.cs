using BLL.Entities;
using BLL.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;
using Newtonsoft.Json;
using ORM;

namespace MvcKnowledgeSystem.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService testService;
        private readonly IUserService userService;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public TestController(ITestService testService, IUserService userService)
        {
            this.testService = testService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            //IEnumerable<TestEntity> tests = testService.GetAllTestEntities();
            UserEntity user = userService.GetUserEntity(User.Identity.Name);
            //logger.Info(user.Information.TimeStart);
            //user.Information = new ExtraUserInformationEntity() { TimeStart = DateTime.UtcNow };
            //logger.Info(user.Information.FinishTime + "abababababababababbabaababbaabab");
            //user.FirstName = "changedabra";
            //user.FirstName = "1";
            //user.Information.TimeStart = DateTime.UtcNow;
            //user.Information.FinishTime = DateTime.UtcNow;
            DbContext db = new TestingSystemContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Tests]");
            /*ExtraUserInformation rt = new ExtraUserInformation() { Id = 1037, FinishTime = DateTime.UtcNow };
            db.Set<ExtraUserInformation>().Attach(rt);
            db.Entry(rt).State = EntityState.Modified;*/
            db.SaveChanges();
            //ExtraUserInformationEntity extra = user.Information;
            //extra.TimeStart = DateTime.UtcNow;
            //userService.Update(extra);
            return View();
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            TestEntity test = testService.GetTestEntity(id.GetValueOrDefault());
            return View(test);
        }

        [CustomAuthorize]
        public ActionResult Start(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            UserEntity user = userService.GetUserEntity(User.Identity.Name);
            //logger.Info(user.Information.TimeStart);
            //user.Information = new ExtraUserInformationEntity() { TimeStart = DateTime.UtcNow };
            //user.FirstName = "changed";
            //user.FirstName = "1";
            //user.Information.TimeStart = DateTime.UtcNow;
            //user.Information.FinishTime = DateTime.UtcNow;
            /*DbContext db = new TestingSystemContext();
            ExtraUserInformation rt = new ExtraUserInformation() { Id = 1037, FinishTime = DateTime.UtcNow };
            db.Set<ExtraUserInformation>().Attach(rt);
            db.Entry(rt).State = EntityState.Modified;
            db.SaveChanges();*/
            
            //userService.Update(user);

            TestEntity test = testService.GetTestEntity(id.GetValueOrDefault());
            ViewData["id"] = id;

            ExtraUserInformationEntity extra = user.Information;
            extra.TimeStart = DateTime.UtcNow;
            userService.Update(extra);

            return View(test);
        }

        [HttpPost]
        public ActionResult CheckTestAnswers(IList<AnswerViewModel> answers, int? testId)
        {
            int countRight = 0;

            if (testId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            UserEntity user = userService.GetUserEntity(User.Identity.Name);

            TestStatistics statistics = new TestStatistics
            {
                ElapsedTime = (DateTime.UtcNow - user.Information.TimeStart).GetValueOrDefault()
            };

            TestEntity test = testService.GetTestEntity(testId.Value);

            for (int i = 0; i < test.Questions.Count; i++)
            {
                bool correct = true;

                for (int j = 0; j < answers[i].Answers.Length; j++)
                {
                    if (!(test.Questions[i].Answers[j].IsCorrect ^ answers[i].Answers[j])) continue;
                    correct = false;
                    break;
                }

                if (correct)
                {
                    countRight++;
                }
            }

            statistics.CorrectAnswers = countRight;
            statistics.TotalQuestions = test.Questions.Count;
            
            return View(statistics);
        }
        
        public string PostSome()
        {
            return "Artem Dulina";
        }
    }
}