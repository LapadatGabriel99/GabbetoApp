using Fasseto.Word.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using ProjectUniversal;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        /// <summary>
        /// Tries to register for a new account on the server
        /// </summary>
        /// <param name="registerCredentialsApiModel">The registration details</param>
        /// <returns>Returns the result of the register request</returns>
        [Route("api/register")]
        public async Task<ApiResponse<RegisterResultApiModel>> RegisterAsync([FromBody] RegisterCredentialsApiModel registerCredentials)
        {
            // TODO: localize all strings
            // The message when login fails
            var invalidErrorMessage = "Please provide all required details to register an account";

            // The error api response for a failed login
            var errorResponse = new ApiResponse<RegisterResultApiModel>
            {
                ErrorMessage = invalidErrorMessage
            };

            // Make sure we have a register credentials
            if (registerCredentials == null)
                // Return failed response
                return errorResponse;

            // Make sure we have a user name
            if (registerCredentials.Username.IsNullOrWhitespace())
                // Return failed response
                return errorResponse;

            // Create the desired user from the given details
            var user = new ApplicationUser
            {
                UserName = registerCredentials.Username,
                FirstName = registerCredentials.FirstName,
                LastName = registerCredentials.LastName,
                Email = registerCredentials.Email,
            };

            // Try and create user
            var result = await _userManager.CreateAsync(user, registerCredentials.Password);
            
            // If the registration was successful...
            if(result.Succeeded)
            {
                // Get the user details
                var userIdentity = await _userManager.FindByNameAsync(registerCredentials.Username);

                // Generate an email verification code
                var emailVerificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);                

                // TODO: Replace with API routes that will contain static routes to use
                var confirmationUrl = $"https://{Request.Host.Value}api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";

                // Sent a verification link to the user's email address
                // To confirm that it's him
                Fasseto.Word.Core.IoC.Task.Run(async () =>
                {
                    await GabbettoEmailSender.SendUserVerificationEmailAsync(userIdentity.Id, userIdentity.Email, confirmationUrl);
                });

                // TODO: Email the user the verification code                

                return new ApiResponse<RegisterResultApiModel>
                {
                    Response = new RegisterResultApiModel
                    {
                        Token = userIdentity.GenerateToken(),
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Username = userIdentity.UserName
                    }
                };
            }
            // Otherwise if it failed...
            else
            {
                // Return the failed response
                return new ApiResponse<RegisterResultApiModel>
                {
                    // Aggregate all errors into a single error string
                    ErrorMessage = result.Errors?.ToList()
                        .Select(identityError => identityError.Description)
                        .Aggregate((a, b) => $"{ a }{ Environment.NewLine }{ b }")
                };
            }
        }

        /// <summary>
        /// Logs in a user using token-base authentication
        /// </summary>
        /// <param name="loginCredentials">The login credentials</param>
        /// <returns>Returns an ApiResponse of LoginResultApiModel once the task is complete</returns>
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
            if (!isValidPassword)
            {
                return errorResponse;
            }

            // If we get here we are valid and the user passed the correct login details

            // Get username
            var username = user.UserName;

            // Get the email
            var email = user.Email;           

            // Return token to user
            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    Token = user.GenerateToken(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName
                },               
            };
        }

        [Route("api/verify/email/{userId}/{emailToken}")]
        [HttpGet]
        public async Task<ActionResult> VerifyEmailAsync(string userId, string emailToken)
        {
            // Get the user by id
            var user = await _userManager.FindByIdAsync(userId);

            // If the user is null
            if (user == null)
            {
                // TODO: Replace with a nicer UI
                return Content("Ups sorry went wrong");
            }

            emailToken = emailToken.Replace("%2f", "/").Replace("2F", "/");

            // Try to confirm the email
            var result = await _userManager.ConfirmEmailAsync(user, emailToken);

            // If we successfully confirmed the email
            if(result.Succeeded)
            {
                // TODO: Replace with a nicer UI
                return Content("Congrats you now can login to our chat app");
            }
            
            // If we got this far, it means we failed...

            // TODO: Replace with a nicer UI
            return Content("Sorry but your token isn't valid");
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
