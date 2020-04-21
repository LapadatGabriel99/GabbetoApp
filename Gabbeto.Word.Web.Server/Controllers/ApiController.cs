using Fasseto.Word.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using ProjectUniversal;
using System;
using System.Collections.Generic;
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
        [AllowAnonymous]
        [Route(ApiRoutes.Register)]
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
                var confirmationUrl = $"https://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";

                // Sent a verification link to the user's email address
                // To confirm that it's him
                Fasseto.Word.Core.IoC.Task.Run(async () =>
                {
                    await GabbettoEmailSender.SendUserVerificationEmailAsync(userIdentity.FirstName, userIdentity.Email, confirmationUrl);
                });                         

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
        [AllowAnonymous]
        [Route(ApiRoutes.Login)]
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

        /// <summary>
        /// Attempts to verify an email address that was used to register a user
        /// by checking the 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emailToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route(ApiRoutes.VerifyEmail)]
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

        /// <summary>
        /// Attempts to save the optional credentials to the server
        /// </summary>
        /// <param name="credentialsModel">The given credentials</param>
        /// <returns>Returns an api response once the task is finished</returns>
        [AllowAnonymous]
        [Route(ApiRoutes.OptionalCredentials)]
        public async Task<ApiResponse<OptionalCredentialsResultApiModel>> SaveOptionalCredentialsAsync([FromBody] OptionalCredentialsApiModel credentialsModel)
        {
            // TODO: localize all strings
            // The message when the save to the server fails
            var defaultErrorMessage = "The first name and last name can't be empty";

            // The error api response for a failed login
            var errorResponse = new ApiResponse<OptionalCredentialsResultApiModel>
            {
                ErrorMessage = defaultErrorMessage
            };

            // Check to see if either of the credentials is empty, null or whitespace...
            if (credentialsModel.FirstName.IsNullOrEmpty() || credentialsModel.FirstName.IsNullOrWhitespace() ||
                credentialsModel.LastName.IsNullOrEmpty() || credentialsModel.LastName.IsNullOrWhitespace())
            {
                // Return an error response
                return errorResponse;
            }

            // Check to see if the name passes some validation tests
            if (credentialsModel.FirstName.HasDigitOrSpecialCharacter() || credentialsModel.LastName.HasDigitOrSpecialCharacter())
            {
                errorResponse.ErrorMessage = "Your name can't consist of any digits/special characters";

                return errorResponse;
            }

            // Get the user by email
            var user = await _userManager.FindByEmailAsync(credentialsModel.Email);

            // Set the new credentials
            user.FirstName = credentialsModel.FirstName;
            user.LastName = credentialsModel.LastName;

            // Try updating the user inside the backing store
            var result = await _userManager.UpdateAsync(user);            

            // If we succeeded
            if(result.Succeeded)
            {
                // Return a successful api response
                return new ApiResponse<OptionalCredentialsResultApiModel>
                {
                    Response = new OptionalCredentialsResultApiModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    }
                };           
            }
            // Otherwise
            else
            {
                // Return a failed api response
                return new ApiResponse<OptionalCredentialsResultApiModel>
                {
                    ErrorMessage = result.Errors?.ToList()
                                    .Select(identityError => identityError.Description)
                                    .Aggregate((a, b) => $"{ a }{ Environment.NewLine }{ b }")
                };
            }
        }

        /// <summary>
        /// Returns the users profile details based on the authenticated user
        /// </summary>
        /// <returns></returns>
        [AuthorizeToken]
        [Route(ApiRoutes.GetUserProfile)]
        public async Task<ApiResponse<UserProfileDetailsApiModel>> GetUserProfileAsync()
        {          
            // Get the users claims
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // If we have no user
            if(user == null)
            {
                return new ApiResponse<UserProfileDetailsApiModel>
                {
                    // TODO: Localization
                    ErrorMessage = "User not found"
                };
            }

            // Return token to user
            return new ApiResponse<UserProfileDetailsApiModel>
            {
                Response = new UserProfileDetailsApiModel
                {                    
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName
                },
            };
        }

        /// <summary>
        /// Returns successful response if the update was successful
        /// </summary>
        /// <param name="model">The user profile details to update</param>
        /// <returns>Returns once the task is finished</returns>
        [AuthorizeToken]
        [Route(ApiRoutes.UpdateUserProfile)]
        public async Task<ApiResponse> UpdateUserProfileAsync([FromBody] UpdateUserProfileApiModel model)
        {            
            // Get the current user
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // Flag to determine if the email has changed
            var emailChanged = false;

            // If we have no user...
            if(user == null)
            {
                return new ApiResponse
                {
                    // TODO: Localize strings
                    ErrorMessage = "User not found"
                };
            }

            // If we have a first name...
            if (model.FirstName != null)
            {
                // Update the profile details
                user.FirstName = model.FirstName;
            }

            // If we have a last name...
            if (model.LastName != null)
            {
                // Update the profile details
                user.LastName = model.LastName;
            }

            // If we have an email...
            if (model.Email != null &&
                
                // And it is not the same
                !string.Equals(model.Email.Replace(" ",""), user.NormalizedEmail))
            {
                // Update the profile details
                user.Email = model.Email;

                // Set the email confirmation to false
                user.EmailConfirmed = false;

                // Flag that we changed the email
                emailChanged = true;
            }

            // If we have a username
            if (model.Username != null)
            {
                // Update the profile details
                user.UserName = model.Username;
            }

            // Attempt to commit change to data store
            var result = await _userManager.UpdateAsync(user);

            // If we succeeded
            if(result.Succeeded)
            {
                if(emailChanged)
                {
                    // Get the updated user
                    var userIdentity = await _userManager.GetUserAsync(HttpContext.User);

                    // Generate an email verification code
                    var emailVerificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    // TODO: Replace with API routes that will contain static routes to use
                    var confirmationUrl = $"https://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";

                    // Sent a verification link to the user's email address
                    // To confirm that it's him
                    Task.Run(async () =>
                    {
                        await GabbettoEmailSender.SendUserVerificationEmailAsync(userIdentity.FirstName, userIdentity.Email, confirmationUrl);
                    });
                }

                // Return a successful response
                return new ApiResponse();
            }
            // Otherwise
            else
            {
                // Return a failed response
                return new ApiResponse
                {
                    ErrorMessage = result.Errors?.ToList()
                                    .Select(identityError => identityError.Description)
                                    .Aggregate((a, b) => $"{ a }{ Environment.NewLine }{ b }")
                };
            }
        }

        /// <summary>
        /// Returns successful response if the update was successful
        /// </summary>
        /// <param name="model">The new user password to update</param>
        /// <returns>Returns once the task is finished</returns>
        [AuthorizeToken]
        [Route(ApiRoutes.UpdateUserPassword)]
        public async Task<ApiResponse> UpdateUserPasswordAsync([FromBody] UpdateUserPasswordApiModel model)
        {            
            // Get the current user
            var user = await _userManager.GetUserAsync(HttpContext.User);            

            // If we have no user...
            if (user == null)
            {
                return new ApiResponse
                {
                    // TODO: Localize strings
                    ErrorMessage = "User not found"
                };
            }

            // Try and change the current users password
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            // If we succeeded
            if (result.Succeeded)
            {
                // Return a successful api response
                return new ApiResponse();
            }
            // Otherwise
            else
            {
                // Return a failed api response...
                return new ApiResponse()
                {
                    // And the respective error message
                    ErrorMessage = result.Errors?.ToList()
                                        .Select(identityError => identityError.Description)
                                        .Aggregate((a, b) => $"{a }{ Environment.NewLine }{ b }")
                };
            }
        }
    }
}
