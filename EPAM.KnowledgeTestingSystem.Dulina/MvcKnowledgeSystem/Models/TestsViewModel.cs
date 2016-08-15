using System.Collections.Generic;
using BLL.Entities;

namespace MvcKnowledgeSystem.Models
{
    public class TestsViewModel
    {
        public PageInformation PageInfo { get; set; }
        public IEnumerable<TestEntity> Tests { get; set; }
    }
}