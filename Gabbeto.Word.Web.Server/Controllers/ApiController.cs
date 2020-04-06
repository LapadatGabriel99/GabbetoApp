using Fasseto.Word.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectUniversal;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Manages the Web Api calls
    /// </summary>
    public class ApiController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The database context of this application
        /// </summary>
        protected ApplicationDbContext _context;

        /// <summary>
        /// The user manager
        /// </summary>
        protected UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// The sign in manager
        /// </summary>
        protected SignInManager<ApplicationUser> _signInManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The database context of this application</param>
        /// <param name="userManager">The user manager</param>
        /// <param name="signInManager">The sign in manager</param>
        public ApiController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LogInAsync([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            // TODO: localize all strings
            // The message when login fails
            var invalidErrorMessage = "Invalid username or password";

            // The error api response for a failed login
            var errorResponse = new ApiResponse<LoginResultApiModel>
            {
                ErrorMessage = invalidErrorMessage
            };

            // Make sure we have a username
            if (loginCredentials?.UsernameOrEmail == null || loginCredentials.UsernameOrEmail.IsNullOrWhitespace())
            {
                // Return error message
                return errorResponse;
            }

            // Validate if the user credentials are correct

            // Is this an email
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");

            // Get the user details
            var user = isEmail ?

                // Find by email
                await _userManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) :

                // Find by name
                await _userManager.FindByNameAsync(loginCredentials.UsernameOrEmail); 

            // If we failed to find the user
            if (user == null)
            {
                return errorResponse;
            }

            // If we got here we have a user...
            // Now we have to validate password

            // Get if password is valid
            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginCredentials.Password);

            // If password was wrong
            if(!isValidPassword)
            {
                return errorResponse;
            }

            // If we get here we are valid and the user passed the correct login details

            // Get username
            var username = user.UserName;

            // Get the email
            var email = user.Email;

            // Set our tokens claims
            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),                

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),

                // Set the Email as a claim of this token
                new Claim(JwtRegisteredClaimNames.Email, email),                
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IocContainer.Configuration["Jwt:SecretKey"])),
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt token
            var token = new JwtSecurityToken(
                issuer: IocContainer.Configuration["Jwt:Issuer"],
                audience: IocContainer.Configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials
                );

            // Return token to user
            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName
                },               
            };
        }

        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;

            return Ok(new { privateData =  $"some secret content for { user.Identity.Name }" });
        }
    }
}
