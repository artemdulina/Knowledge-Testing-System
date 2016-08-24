using System;
using BLL.Entities;
using BLL.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService userService;
        private ITestService testService;

        public HomeController(ITestService service, IUserService user)
        {
            testService = service;
            userService = user;
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index(int page = 1)
        {
            /*userService.CreateUser(new UserEntity()
            {
                //Username = "SuperUser",
                Username = "dulinaartem",
                Email = "guest@gmail.com",
                FirstName = "Troelsen",
                LastName = "Petrovich",
                Password = "789123",
                Roles = new List<RoleEntity>() { new RoleEntity() { Type = RoleType.Guest } },
                Information = new ExtraUserInformationEntity() { TimeStart = DateTime.UtcNow }
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
            List<QuestionEntity> questions = new List<QuestionEntity>
            {
                new QuestionEntity()
                {
                    Text = "What is static?",
                    Answers = answers
                }
            };
            List<AnswerEntity> answerst = new List<AnswerEntity>();
            answerst.Add(new AnswerEntity()
            {
                Text = "Access modifier",
                IsCorrect = true
            });
            answerst.Add(new AnswerEntity()
            {
                Text = "What?",
                IsCorrect = false
            });
            questions.Add(new QuestionEntity()
            {
                Text = "What is public?",
                Answers = answerst
            });
            /*testService.CreateTest(new TestEntity()
            {
                Title = "Good Test",
                Topic = "Programming Next",
                TimeLimit = new TimeSpan(0, 2, 0),
                Questions = questions
            });*/

            int testsOnPage = 10;
            IEnumerable<TestEntity> tests = testService.GetAllTestEntities().ToList();
            IEnumerable<TestEntity> partTests = tests.Skip((page - 1) * testsOnPage).Take(testsOnPage);

            PageInformation pageInfo = new PageInformation
            {
                TotalObjects = tests.Count(),
                CurrentPage = page,
                ObjectsOnPage = testsOnPage
            };

            if (page > pageInfo.TotalPages || page <= 0)
            {
                return RedirectToAction("Index", "Home");
            }

            TestsViewModel testModel = new TestsViewModel { PageInfo = pageInfo, Tests = partTests };

            if (Request.IsAjaxRequest())
            {
                return Json(testModel, JsonRequestBehavior.AllowGet);
            }

            return View(testModel);
        }
    }
}