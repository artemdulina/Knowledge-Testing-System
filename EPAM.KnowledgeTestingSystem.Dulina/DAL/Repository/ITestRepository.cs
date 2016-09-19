using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.DataTransferObject;

namespace DAL.Repository
{
    public interface ITestRepository : IRepository<DalTest>
    {
        IEnumerable<DalTest> GetAllMatchedTests(Expression<Func<DalTest, bool>> predicate);
    }
}
