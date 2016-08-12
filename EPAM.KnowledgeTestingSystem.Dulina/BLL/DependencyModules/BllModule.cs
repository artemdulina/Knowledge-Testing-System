using Ninject.Modules;
using BLL.Services;
using BLL.ServicesImplementations;
using DAL.DependencyModules;
using Ninject;

namespace BLL.DependencyModules
{
    public class BllModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new DalModule());
            Bind<IUserService>().To<UserService>();
            Bind<ITestService>().To<TestService>();
        }
    }
}
