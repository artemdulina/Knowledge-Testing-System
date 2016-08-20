using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class AnswerViewModel
    {
        //[Required]
        //[DataType(DataType.Text)]
        //public string Num { get; set; }

        //[Required]
        //[DataType(DataType.Text)]
        //public string Str { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public int Pas { get; set; }

        [Required]
        public bool [] Answers { get; set; }

    }
}