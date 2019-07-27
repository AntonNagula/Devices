using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONION.InfrastructureServices;
using ONION.Infrustructure.Interfaces;
using Microsoft.Practices.Unity;
namespace ONION.DependencyInjection.Moduls
{
    public class RepositoryModul:IModul
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IRepository,Repository>(new ContainerControlledLifetimeManager());
        }
    }
}
