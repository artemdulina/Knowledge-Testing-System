using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services
{
    public interface ITestService
    {
        TestEntity GetTestEntity(int id);
        IEnumerable<TestEntity> GetAllTestEntities();
        void CreateTest(TestEntity user);
        void DeleteTest(int id);
    }
}
