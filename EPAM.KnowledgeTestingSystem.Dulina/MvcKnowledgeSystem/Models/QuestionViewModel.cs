using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class QuestionViewModel
    {
        public string Text { get; set; }

        public List<AnswersViewModel> Answers { get; set; }
    }
}