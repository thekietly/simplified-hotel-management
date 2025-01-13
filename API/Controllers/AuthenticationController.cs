using Azure;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin loginModel) 
        {
            // Find user by name
            var user = await userManager.FindByNameAsync(loginModel.Username);
            // If user is valid and password is correct
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password)) 
            {
                // Retrieve user role
                var userRoles = await userManager.GetRolesAsync(user);
                // Generate authentication tokens
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                //
                foreach (var userRole in userRoles) 
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaim);
                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model) 
        {
            var validatedUser = await userManager.FindByNameAsync(model.Username);
            if (validatedUser != null) 
            {
                return base.StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User already exists!" });
            }
            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded) 
            {
                return base.StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new AuthResponse {Status = "Success",  Message = "User created successfully!"});
        }
        /// <summary>
        /// Generate a token that contains a list of claims
        /// </summary>
        private JwtSecurityToken GetToken(List<Claim> authClaims) 
        {
            // Encode secret
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            // Generate token
            var token = new JwtSecurityToken(
                    // backend port
                    issuer: configuration["JWT:ValidIssuer"],
                    // front-end port
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    // user claims
                    claims: authClaims,
                    // Use Sha256 to encode the secret in this app and sign it off
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

    }
}
