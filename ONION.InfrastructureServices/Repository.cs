using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ONION.Infrustructure.Interfaces;
namespace ONION.InfrastructureServices
{
    public class Repository: IRepository
    {
        public List<User> users = new List<User>()
        {
            new User() { Id = 1, Name = "Денис", Surname = "Скриган"},
            new User() { Id = 2, Name = "Александр", Surname = "Скриган"},
            new User() { Id = 3, Name = "Арсений", Surname = "Скриган" }            
        };

        public List<Device> Devices = new List<Device>()
        {
            new Device() { Id = 1, Name = "Микроволновка"},
            new Device() { Id = 2, Name = "телефон"},
            new Device() { Id = 3, Name = "ноут"},
            new Device() { Id = 1, Name = "ноут"}            
        };

        public IList<User> Get()
        {
            return users;
        }

        public bool Create_User(User user)
        {
            var res = users.FirstOrDefault(x=>x.Id==user.Id);
            if(res==null)
            {
                users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete_User(int id)
        {
            var res = users.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {                
                return false;
            }
            else
            {
                users.Remove(res);                
                for(int i=0;i<Devices.Count;i++)
                {
                    var dev=Devices.FirstOrDefault(x => x.Id == id);
                    Devices.Remove(dev);
                }
                return true;
            }
        }

        public IList<Device> Get_Dev(int Id)
        {
            return Devices.Where(x=>x.Id==Id).ToList();
        }
        public void Create(Device dev)
        {
            Devices.Add(dev);
        }
        public bool Delete(int Id)
        {
            var obj = Devices.FirstOrDefault(x=>x.Id==Id);
            bool res = Devices.Remove(obj);
            return res;
        }
        public bool Delete(Device dev)
        {
            bool res = Devices.Remove(dev);
            return res;
        }
    }
}
