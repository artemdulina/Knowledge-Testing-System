using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKnowledgeSystem.Models
{
    public class PageInformation
    {
        public int ObjectsOnPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalObjects { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalObjects / ObjectsOnPage);
            }
        }
    }
}