using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserLogin.API.DTOs;
using UserLogin.Business.Abstracts;
using UserLogin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public AuthController(IUserService userService, IJwtTokenManager jwtTokenManager, UserManager<User> userManager)
        {
            _userService = userService;
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpDto dto)
        {
            var existingUser = _userManager.Users.FirstOrDefault(u=>u.UserName==dto.Username);
            if (existingUser != null)
            {
                return BadRequest(new { Status = "Error", Message = "Email already exists." });
            }

            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                ProfilePicture = dto.ProfilePicutre!=null ? dto.ProfilePicutre : ""

            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return Ok(new { Status = "Success", Message = "User created successfully!" });
            }
            return Ok(new { Status = "Error", Message = "User creation failed!", Errors = result.Errors });
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto dto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(dto.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
                {

                    var userRoles = await _userManager.GetRolesAsync(user);
                    string token = _jwtTokenManager.GenerateToken(user.UserName);

                    return Ok(new { Token = token });


                }
                return Unauthorized();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        
    }
}


