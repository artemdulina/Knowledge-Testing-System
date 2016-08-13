using BLL.Entities;
using BLL.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService userService;
        private ITestService testService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(ITestService service)
        {
            testService = service;
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
            //return RedirectToAction("Index", "Test");
            /*userService.CreateUser(new UserEntity()
            {
                //Username = "SuperUser",
                Username = "guest",
                Email = "guest@gmail.com",
                FirstName = "Troelsen",
                LastName = "Petrovich",
                Password = "guest",
                Roles = new List<RoleEntity>() { new RoleEntity() { Type = RoleType.Guest } }
            });*/
            List<AnswerEntity> answers = new List<AnswerEntity>();
            answers.Add(new AnswerEntity()
            {
                Text = "C# word",
                IsCorrect = true
            });
            answers.Add(new AnswerEntity()
            {
                Text = "Don't know",
                IsCorrect = false
            });
            List<QuestionEntity> questions = new List<QuestionEntity>();
            questions.Add(new QuestionEntity()
            {
                Text = "What is static?",
                Answers = answers
            });
            /*testService.CreateTest(new TestEntity()
            {
                Title = "c# Test",
                Topic = "SuperTest",
                TimeLimit = new TimeSpan(0, 10, 0),
                Questions = questions
            });*/
            //IEnumerable<UserEntity> users = userService.GetAllUserEntities();
            IEnumerable<TestEntity> tests = testService.GetAllTestEntities();
            ViewData["timer"] = "ViewDatas";
            TempData["timer"] = "TempDatas";
            ViewBag.Message = "ViewBag";
            Session.Add("sessionobject", 88005553535);
            //
            return View(tests);
            //return RedirectToAction("Some");
        }
    }
}