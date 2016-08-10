﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKnowledgeSystem.Models;

namespace MvcKnowledgeSystem.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}