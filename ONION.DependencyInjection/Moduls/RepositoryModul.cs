using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONION.InfrastructureServices;
using ONION.Infrustructure.Interfaces;
using Microsoft.Practices.Unity;
using ONION.InfrastructureServices.Contexts;
using Microsoft.EntityFrameworkCore;
namespace ONION.DependencyInjection.Moduls
{
    public class RepositoryModul:IModul
    {
        public void Register(IUnityContainer container)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_Task;Trusted_Connection=True;");
            
            container.RegisterType<MyContext>(new ContainerControlledLifetimeManager(), new InjectionConstructor(optionsBuilder.Options));

            container.RegisterType<IRepository,UserRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
