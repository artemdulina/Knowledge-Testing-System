using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using NLog;
using ORM;

namespace DAL.RepositoryImplementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UserRepository(DbContext context)
        {
            this.context = context;
            MapperDomainConfiguration.Configure();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().ToList().Select(user =>
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
            //logger.Info(user.Id);
            context.Set<User>().AddOrUpdate(user);
            //User usert = new User() {Id=1041,Password = "111111"};
            //User userf = context.Set<User>().Single(u => u.Id == user.Id);
            //context.Entry(user).State = EntityState.Unchanged;
            //context.Set<User>().Attach(user);
            //userf.Password = "111111";
            //context.Entry(userf).State = EntityState.Modified;
            //logger.Info(context.Entry(user).State);
        }

        /*
         public void ChangePassword(int userId, string password)
{
  var user = new User() { Id = userId, Password = password };
  using (var db = new MyEfContextName())
  {
    db.Users.Attach(user);
    db.Entry(user).Property(x => x.Password).IsModified = true;
    db.SaveChanges();
  }
}*/

        public DalUser Get(string name)
        {
            User found = context.Set<User>().FirstOrDefault(user => user.Username == name);

            if (found == null)
                return null;

            return MapperDomainConfiguration.MapperInstance.Map<User, DalUser>(found);
        }      

        public void UpdateExtraInfo(DalExtraUserInformation information)
        {
            ExtraUserInformation info = MapperDomainConfiguration.MapperInstance.
                Map<DalExtraUserInformation, ExtraUserInformation>(information);
            
            context.Set<ExtraUserInformation>().AddOrUpdate(info);
        }
    }
}
