using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
            //using (var rep = new TestAuth())
            //{
            //    var user = rep.FindUser(1);
            //    rep.Dispose();
            //    return new string[] { user.PasswordHash, "value2" };
            //}
            return new string[] { "fdsa", "value2" };
        }

        [Authorize]
        // GET api/<controller>/5
        public string Get(int id)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
            var role = principal.Claims.Where(c => c.Type == "role").Single().Value;

            return "userName: " + userName + " | Role: " + role ; // + user.Id;
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