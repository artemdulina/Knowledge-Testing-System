using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using ORM;
using AutoMapper;

namespace DAL.RepositoryImplementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
            MapperDomainConfiguration.Configure();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().AsEnumerable().Select(user =>
            MapperDomainConfiguration.MapperInstance.Map<User, DalUser>(user)
            );
        }

        public DalUser GetById(int id)
        {
            var found = context.Set<User>().FirstOrDefault(user => user.Id == id);

            if (found == null)
                return null;

            return MapperDomainConfiguration.MapperInstance.Map<User, DalUser>(found);
        }

        //need to resolve this question
        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> objectToFind)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            var user = MapperDomainConfiguration.MapperInstance.Map<DalUser, User>(entity);
            context.Set<User>().Add(user);
        }

        public void DeleteById(int id)
        {
            var user = new User() { Id = id };

            context.Set<User>().Attach(user);
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            User user = MapperDomainConfiguration.MapperInstance.Map<DalUser, User>(entity);

            context.Set<User>().Attach(user);
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
