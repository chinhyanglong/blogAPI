using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huyblog.Models;
using huyblog.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace huyblog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetUserData")]
        public IActionResult GetUserData()
        {
            return Ok("This is a response from user method");
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        [Route("GetAdminData")]
        
        public IActionResult GetAdminData()
        {
            return Ok("This is a response from Admin method");
        }
    }
}