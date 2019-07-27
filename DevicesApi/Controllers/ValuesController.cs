using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using ONION.Domain.Interfaces;
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
        public IEnumerable<User> Get_Users()
        {
            return users.GetUsers();
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create_User([FromBody]User user)
        {
            var res= users.CreateUser(user);
            if (res)
            {
                return Ok();
            }
            else
                return BadRequest();
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
        [HttpGet,Route("{id:int}/devices")]
        public IList<Device> Get_devices(int id)
        {
            return users.Get_Devices(id);
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

        [HttpDelete, Route("{id}/devices/equipment")]
        public IHttpActionResult Delete(int id,[FromBody]string str)
        {
            Device dev = new Device() { Id = id, Name = str };
            bool res=users.Delete(dev);
            if (res)
            {
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
