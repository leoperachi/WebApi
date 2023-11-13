using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly TodoContext _context;

        public LoginController(IConfiguration config, TodoContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User _user)
        {
            var u = await _context.Users.SingleOrDefaultAsync(u => 
                u.Username == _user.Username && u.Password == _user.Password);

            if (u == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new
                {
                    User = u,
                    Token = TokenService.GenerateToken(u)
                });
            }
        }
    }
}
