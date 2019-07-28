﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using ONION.Domain.Interfaces;
using DevicesApi.Mappers;
using DevicesApi.Models;
namespace DevicesApi.Controllers
{
    [RoutePrefix("users")]
    public class ValuesController : ApiController
    {
        public readonly IUserService users;
        public ValuesController(IUserService service)
        {
            users = service;
        }

        // GET api/values
        [HttpGet,Route("")]
        public IEnumerable<AppUser> Get_Users()
        {
            return users.GetUsers().Select(x=>x.ToUser());
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create_User([FromBody]ViewUser user)
        {
            users.CreateUser(user.FromViewToDomainUser());
            return Ok();
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete_User(int id)
        {
            var res=users.DeleteUser(id);
            if(res)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/values/5
        [HttpGet,Route("{id:int}/del_one_device")]
        public IList<AppDevice> Get_devices(int id)
        {
            return users.Get_Devices(id).Select(x=>x.ToDevice()).ToList();
        }

        // POST api/values
        [HttpPost, Route("{id:int}/devices")]
        public void Post(int id, [FromBody]string str)
        {
            Device dev = new Device() { Id = id, Name = str };
            users.Create(dev);
        }

        

        // DELETE api/values/5
        [HttpDelete, Route("{id}/devices")]
        public IHttpActionResult Delete(int id)
        {
            bool res=users.Delete(id);
            if (res)
            {
                return Ok();
            }
            else
                return NotFound();
        }

        //[HttpDelete, Route("{id}/devices/equipment")]
        //public IHttpActionResult Delete(int id,[FromBody]string str)
        //{
        //    Device dev = new Device() { Id = id, Name = str };
        //    bool res=users.Delete(dev);
        //    if (res)
        //    {
        //        return Ok();
        //    }
        //    else
        //        return NotFound();
        //}
    }
}
