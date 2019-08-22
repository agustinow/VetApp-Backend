using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetApi.Models;
using VetApi.Services;

namespace VetApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public LoginController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost, Route("request")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Request");
            if (_authService.IsAuthenticated(request, out string token)) return Ok(token);
            else return StatusCode(401, token);
        }

        [AllowAnonymous]
        [HttpGet, Route("check")]
        public IActionResult CheckConnection() =>
            Ok();
    }
}
