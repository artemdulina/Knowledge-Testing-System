﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Entities;
using BLL.Services;
using DAL.Repository;
using DAL.DataTransferObject;
using BLL.Configurations;

namespace BLL.ServicesImplementations
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork uow;
        private readonly ITestRepository testRepository;

        public TestService(IUnitOfWork uow, ITestRepository repository)
        {
            this.uow = uow;
            testRepository = repository;
        }

        public void CreateTest(TestEntity test)
        {
            DalTest testToCreate = MapperBusinessConfiguration.MapperInstance.Map<TestEntity, DalTest>(test);
            testRepository.Create(testToCreate);
            uow.Commit();
        }

        public void DeleteTest(int id)
        {
            testRepository.DeleteById(id);
            uow.Commit(); ;
        }

        public IEnumerable<TestEntity> GetAllMatchedTests(Expression<Func<TestEntity, bool>> predicate)
        {
            Expression<Func<DalTest, bool>> testPredicate = MapperBusinessConfiguration.MapperInstance.
            Map<Expression<Func<TestEntity, bool>>, Expression<Func<DalTest, bool>>>(predicate);

            IEnumerable<TestEntity> resultQuery = MapperBusinessConfiguration.MapperInstance.
                Map<IEnumerable<DalTest>, IEnumerable<TestEntity>>(testRepository.GetAllMatchedTests(testPredicate));

            return resultQuery;
        }

        public IEnumerable<TestEntity> GetAllTestEntities()
        {
            return MapperBusinessConfiguration.MapperInstance.
                Map<IEnumerable<DalTest>, IEnumerable<TestEntity>>(testRepository.GetAll()); ;
        }

        public TestEntity GetTestEntity(int id)
        {
            return MapperBusinessConfiguration.MapperInstance.Map<DalTest, TestEntity>(testRepository.GetById(id));
        }
    }
}
