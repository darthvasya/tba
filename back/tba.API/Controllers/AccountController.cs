using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using tba.API.Models;
using tba.Model;
using tba.Model.DTO;
using tba.Services.Contracts;

namespace tba.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterUserDTO user = new RegisterUserDTO { UserName = userModel.UserName, PasswordHash = userModel.Password };
            bool created = _userService.CreateUser(user);

            if (created)
                return Ok();
            else
                return Ok("NOOOOO");
        }
    }
}