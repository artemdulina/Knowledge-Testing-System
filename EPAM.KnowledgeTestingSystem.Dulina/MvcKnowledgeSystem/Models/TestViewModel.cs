using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class TestViewModel
    {
        public string Title { get; set; }

        public string Topic { get; set; }

        public List<QuestionViewModel> Questions { get; set; }

        public int TimeLimit { get; set; }
    }
}