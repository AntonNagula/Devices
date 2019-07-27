using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONION.Domain.Interfaces;
using ONION.Domain.Services;
using Microsoft.Practices.Unity;
namespace ONION.DependencyInjection.Moduls
{
    public class UserContext:IModul
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
        }
    }
}
