using ES.Domain.Entity;
using ES.Repository.Operation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ES.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountAuthController : Controller
    {
        private readonly IUser _userRepository;
        private readonly IConfiguration _iConfuguration;
        public AccountAuthController(IUser user,IConfiguration configuration )
        {
            _userRepository = user;
            _iConfuguration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(UserSignUp userSignUp)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userSignUp.FirstName,
                    Email = userSignUp.Email
                };
                var result = await _userRepository.CreateUserAsync(user, userSignUp.Password);
                if (result.Succeeded)
                {
                    await _userRepository.AddUserToRoleAsync(user, "User");
                    return Ok("registration SuccessFull");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest("Invalid Registration Details");
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserByEmailAsync(userLogin.Email);
                if(user != null)
                {
                    var PasswordValid = await _userRepository.CheckPasswordAsync(user, userLogin.Password);
                    if (PasswordValid)
                    {
                        if (await _userRepository.UserIsInRoleAsync(user, "Admin"))
                        {
                            var token = GenerateJwtToken(user);
                            return Ok(new { token });
                        }
                        else
                        {
                            return Content("SuccessFull Login");
                        }
                    }
                }
            }

            return StatusCode(401,"Unauthorized")''
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfuguration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_iConfuguration["Jwt:TokenExpirationDays"]));

            var token = new JwtSecurityToken(
                _iConfuguration["Jwt:Issuer"],
                _iConfuguration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
