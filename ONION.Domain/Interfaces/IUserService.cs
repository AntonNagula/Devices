using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace ONION.Domain.Interfaces
{
    public interface IUserService
    {
        IList<User> GetUsers();
        bool CreateUser(User user);
        bool DeleteUser(int id);
        IList<Device> Get_Devices(int Id);
        void Create(Device dev);
        bool Delete(Device dev);
        bool Delete(int Id);
    }
}
