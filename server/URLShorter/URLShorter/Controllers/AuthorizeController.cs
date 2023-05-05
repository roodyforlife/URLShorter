using Authorize.Interfaces;
using Authorize.Models;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLShorter.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorize;
        public AuthorizeController(IAuthorizeService authorize)
        {
            _authorize = authorize;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Login model)
        {
            return new JsonResult(await _authorize.LoginAsync(model));
        }

        [HttpPost("regist")]
        public async Task<ActionResult> Register([FromBody] Register model)
        {
            return new JsonResult(await _authorize.RegistAsync(model));
        }

        [Authorize]
        [HttpGet("check")]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
