using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using ONION.InfrastructureServices.Configurations;
namespace ONION.InfrastructureServices.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Device> Devices { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder.ApplyConfiguration(new UserConfiguration()));
            //base.OnModelCreating(modelBuilder.ApplyConfiguration(new DeviceConfiguration()));

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User { Id=1,Name="Tom", Surname="Welling"},
                new User { Id=2, Name="Alice", Surname="Welling"},
                new User { Id=3, Name="Sam", Surname="Word"}
                });

            //modelBuilder.Entity<Device>().HasData(
            //   new Device[]
            //   {
            //    new Device { Id=1, Name="Ноут", UserId=1 },
            //    new Device { Id=2, Name="Телефон",UserId=2},
            //    new Device { Id=3, Name="Нож",UserId=3},
            //    new Device { Id=4, Name="Нож",UserId=1}
            //   });
            base.OnModelCreating(modelBuilder);
        }
    }
}
