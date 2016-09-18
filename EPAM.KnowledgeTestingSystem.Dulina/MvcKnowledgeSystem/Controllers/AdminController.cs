using System;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;
using BLL.Entities;
using BLL.Services;
using DAL.DataTransferObject;
using MvcKnowledgeSystem.Configurations;
using NLog;

namespace MvcKnowledgeSystem.Controllers
{
    [CustomAuthorize(Roles = new[] { RoleType.Administrator })]
    public class AdminController : BaseController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ITestService testService;

        public AdminController(ITestService service)
        {
            testService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(TestViewModel testToCreate)
        {
            try
            {
                TestEntity readyTest = MapperMvcConfiguration.MapperInstance.Map<TestViewModel, TestEntity>(testToCreate);
                testService.CreateTest(readyTest);
                logger.Info("Id: " + readyTest.Id);
                logger.Info("Questions[0].Text: " + readyTest.Questions[0].Text);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { message = "Test successfully created" }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}