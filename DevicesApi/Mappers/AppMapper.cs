using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesApi.Models;
using Models;
namespace DevicesApi.Mappers
{
    public static class AppMapper
    {
        public static AppUser ToUser(this User @this)
        {
            return new AppUser
            {
                Id = @this.Id,
                Name = @this.Name,
                Surname = @this.Surname
            };
        }

        public static AppDevice ToDevice(this Device @this)
        {
            return new AppDevice
            {
                Id = @this.Id,
                Name = @this.Name
            };
        }

        public static User ToDomainUser(this AppUser @this)
        {
            return new User
            {
                Id = @this.Id,
                Name = @this.Name,
                Surname = @this.Surname
            };
        }

        public static User FromViewToDomainUser(this ViewUser @this)
        {
            return new User
            {                
                Name = @this.Name,
                Surname = @this.Surname
            };
        }
    }
}