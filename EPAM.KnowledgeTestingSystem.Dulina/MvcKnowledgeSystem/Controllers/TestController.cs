using BLL.Entities;
using BLL.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;

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
            return View(test);
        }
    }
}