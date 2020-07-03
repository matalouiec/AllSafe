using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSafe.Application.Interfaces;
using AllSafe.DataAccess.Entities;
using AllSafe.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllSafe.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost("/authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _user.Authenticate(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] RegistrationRequest model)
        {
            var response = _user.Register(model);
            if (response == null)
                return BadRequest(new { message = "Something went wrong while saving your account." });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _user.GetUser(id);
            if (response.Result == null)
                return BadRequest(new { message = "We can't seem to find that record" });

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var users = _user.GetAll();
            return Ok(users);
        }
    }
}
