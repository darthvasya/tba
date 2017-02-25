using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tba.Model;
using tba.Services.Contracts;

namespace tba.API.Controllers
{
    public class ValuesController : ApiController
    {
        IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            _userService.FindUser("Petya", "Parol");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            User user = _userService.FindUser("Petya", "Parol");
            return "value " + user.Id;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}