using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONION.Domain.Interfaces;
using ONION.Infrustructure.Interfaces;
using Models;
namespace ONION.Domain.Services
{
    public class UserService:IUserService
    {
        public readonly IRepository _userRepository;

        public UserService(IRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> GetUsers()
        {
            return _userRepository.Get();
        }

        public void CreateUser(User user)
        {
            _userRepository.Create_User(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.Delete_User(id);
        }




        public IList<Device> Get_Devices(int Id)
        {
            return _userRepository.Get_Dev(Id);
        }

        public void Create(Device dev)
        {
            
            _userRepository.Create(dev);
        }               

        public bool Delete(int Id)
        {            
            bool res = _userRepository.Delete(Id);
            return res;
        }        
    }
}
