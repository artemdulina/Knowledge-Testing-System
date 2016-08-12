using Ninject.Modules;
using System.Data.Entity;
using ORM;
using DAL.Repository;
using DAL.RepositoryImplementations;
using Ninject.Web.Common;

namespace DAL.DependencyModules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<TestingSystemContext>().InRequestScope();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
