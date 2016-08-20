using BLL.Entities;
using BLL.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;
using Newtonsoft.Json;

namespace MvcKnowledgeSystem.Controllers
{
    public class TestController : Controller
    {
        private ITestService testService;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public TestController(ITestService service)
        {
            testService = service;
        }

        public ActionResult Index()
        {
            //IEnumerable<TestEntity> tests = testService.GetAllTestEntities();

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

            TestEntity test = testService.GetTestEntity(id.GetValueOrDefault());
            HttpContext.Response.Cookies.Add(new HttpCookie("id", "HC.Response.Add"));
            HttpContext.Response.Cookies.Add(new HttpCookie("id1", "HC.Response.Add"));
            string startTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);

            HttpContext.Response.Cookies.Add(new HttpCookie("teststart", startTime));
            ViewData["id"] = id;
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

            TestEntity test = testService.GetTestEntity(testId.Value);

            for (int i = 0; i < test.Questions.Count; i++)
            {
                bool correct = true;

                for (int j = 0; j < answers[i].Answers.Length; j++)
                {
                    if (test.Questions[i].Answers[j].IsCorrect ^ answers[i].Answers[j])
                    {
                        correct = false;
                        break;
                    }

                }

                if (correct)
                {
                    countRight++;
                }
            }


            TestStatistics statistics = new TestStatistics
            {
                CorrectAnswers = countRight,
                TotalQuestions = test.Questions.Count
            };

            return View(statistics);
        }

        [HttpPost]
        public ActionResult PostSome(IList<AnswerViewModel> answers, int? testId)
        {
            return View(testId.GetValueOrDefault());
        }
    }
}