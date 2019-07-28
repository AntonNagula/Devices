using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONION.Infrustructure.Interfaces;
using Models;
using ONION.InfrastructureServices.Contexts;
namespace ONION.InfrastructureServices
{
    public class UserRepository :IRepository
    {
        private readonly MyContext _context;

        public List<Device> Devices = new List<Device>()
        {
            new Device() { Id = 1, Name = "Микроволновка"},
            new Device() { Id = 2, Name = "телефон"},
            new Device() { Id = 3, Name = "ноут"},
            new Device() { Id = 1, Name = "ноут"}
        };

        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public IList<User> Get()
        {
            return _context.Users.ToList();
        }

        public void Create_User(User user)
        {
            _context.Users.Add(new User() { Name = user.Name, Surname = user.Surname });
            _context.SaveChanges();
        }

        public bool Delete_User(int id)
        {
            var res = _context.Users.FirstOrDefault(x => x.Id == id);
            
            if (res == null)
            {
                return false;
            }
            else
            {
                _context.Users.Remove(res);
                _context.SaveChanges();
                for (int i=0;i<Devices.Count;i++)
                {
                    var device=Devices.FirstOrDefault(x=>x.Id==id);
                    Devices.Remove(device);
                }                               
                return true;
            }
        }

        //public IList<Device> Get_Dev(int Id)
        //{
        //    return _context.Devices.Where(x => x.UserId == Id).ToList();
        //}
        //public void Create(Device dev)
        //{
        //    _context.Devices.Add(dev);
        //}
        //public bool Delete(int Id)
        //{
        //    Device obj = _context.Devices.FirstOrDefault(x => x.UserId == Id);
        //    var res = _context.Devices.Remove(obj);
        //    bool ret = res == null ? false : true;
        //    return ret;
        //}
        //public bool Delete(Device dev)
        //{
        //    var res = _context.Devices.Remove(dev);
        //    bool ret = res == null ? false : true;
        //    return ret;
        //}


        public IList<Device> Get_Dev(int Id)
        {
            return Devices.Where(x => x.Id == Id).ToList();
        }
        public void Create(Device dev)
        {
            Devices.Add(dev);
        }
        public bool Delete(int Id)
        {
            var obj = Devices.FirstOrDefault(x => x.Id == Id);
            bool res = Devices.Remove(obj);
            return res;
        }
    }
}
