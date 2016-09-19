using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services
{
    public interface ITestService
    {
        TestEntity GetTestEntity(int id);
        IEnumerable<TestEntity> GetAllMatchedTests(Expression<Func<TestEntity, bool>> predicate);
        IEnumerable<TestEntity> GetAllTestEntities();
        void CreateTest(TestEntity test);
        void DeleteTest(int id);
    }
}
