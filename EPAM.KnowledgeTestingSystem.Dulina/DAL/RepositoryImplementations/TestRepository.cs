using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using ORM;

namespace DAL.RepositoryImplementations
{
    public class TestRepository : IRepository<DalTest>
    {
        private readonly DbContext context;

        public TestRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalTest> GetAll()
        {
            return context.Set<Test>().AsEnumerable().Select(test =>
            MapperDomainConfiguration.MapperInstance.Map<Test, DalTest>(test)
            );
        }

        public DalTest GetById(int id)
        {
            Test found = context.Set<Test>().FirstOrDefault(user => user.Id == id);

            if (found == null)
                return null;

            return MapperDomainConfiguration.MapperInstance.Map<Test, DalTest>(found);
        }

        //need to resolve this question
        public DalTest GetByPredicate(Expression<Func<DalTest, bool>> objectToFind)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTest entity)
        {
            Test test = MapperDomainConfiguration.MapperInstance.Map<DalTest, Test>(entity);
            context.Set<Test>().Add(test);
        }

        public void DeleteById(int id)
        {
            Test test = new Test() { Id = id };

            context.Set<Test>().Attach(test);
            context.Set<Test>().Remove(test);
        }

        public void Update(DalTest entity)
        {
            Test test = MapperDomainConfiguration.MapperInstance.Map<DalTest, Test>(entity);
            context.Set<Test>().Attach(test);

            context.Entry(test).State = EntityState.Modified;
        }
    }
}
