using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using Ninject.Infrastructure.Language;
using NLog;
using ORM;

namespace DAL.RepositoryImplementations
{
    public class TestRepository : ITestRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly DbContext context;

        public TestRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalTest> GetAll()
        {
            return context.Set<Test>().ToList().Select(test =>
            MapperDomainConfiguration.MapperInstance.Map<Test, DalTest>(test)
            );
        }

        public IEnumerable<DalTest> GetAllMatchedTests(Expression<Func<DalTest, bool>> predicate)
        {
            List<DalTest> result = new List<DalTest>();
            try
            {
                Expression<Func<Test, bool>> testPredicate = MapperDomainConfiguration.MapperInstance.
                    Map<Expression<Func<DalTest, bool>>, Expression<Func<Test, bool>>>(predicate);

                /*IQueryable<DalTest> resultQuery = MapperDomainConfiguration.MapperInstance.
                Map<IQueryable<Test>,IQueryable<DalTest>>(context.Set<Test>().Where(testPredicate));*/

                result = MapperDomainConfiguration.MapperInstance.
                    Map<List<Test>, List<DalTest>>(context.Set<Test>().Where(testPredicate).ToList());
                //return context.Set<Test>().Where(testPredicate).ProjectTo<DalTest>();
                return result;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

            return result;
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

        public DalTest Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
