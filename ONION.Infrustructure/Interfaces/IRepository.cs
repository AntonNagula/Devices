using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace ONION.Infrustructure.Interfaces
{
    public interface IRepository
    {
        IList<User> Get();
        bool Create_User(User user);
        bool Delete_User(int id);
        IList<Device> Get_Dev(int Id);
        void Create(Device dev);
        bool Delete(int Id);
        bool Delete(Device dev);
    }
}
