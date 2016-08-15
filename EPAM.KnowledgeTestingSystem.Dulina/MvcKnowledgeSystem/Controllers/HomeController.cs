﻿using System;
using BLL.Entities;
using BLL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;

namespace MvcKnowledgeSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService userService;
        private ITestService testService;

        public HomeController(ITestService service)
        {
            testService = service;
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index(int page = 1)
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
            answers.Clear();
            answers.Add(new AnswerEntity()
            {
                Text = "Access modifier",
                IsCorrect = true
            });
            answers.Add(new AnswerEntity()
            {
                Text = "What?",
                IsCorrect = false
            });
            questions.Add(new QuestionEntity()
            {
                Text = "What is public?",
                Answers = answers
            });
            /*testService.CreateTest(new TestEntity()
            {
                Title = "c# New Test Next",
                Topic = "Programming Next",
                TimeLimit = new TimeSpan(0, 2, 0),
                Questions = questions
            });*/
            //IEnumerable<UserEntity> users = userService.GetAllUserEntities();
            int testsOnPage = 10;
            IEnumerable<TestEntity> tests = testService.GetAllTestEntities().ToList();
            IEnumerable<TestEntity> partTests = tests.Skip((page - 1) * testsOnPage).Take(testsOnPage);

            PageInformation pageInfo = new PageInformation
            {
                TotalObjects = tests.Count(),
                CurrentPage = page,
                ObjectsOnPage = testsOnPage
            };

            TestsViewModel testModel = new TestsViewModel { PageInfo = pageInfo, Tests = partTests };
            return View(testModel);
        }
    }
}