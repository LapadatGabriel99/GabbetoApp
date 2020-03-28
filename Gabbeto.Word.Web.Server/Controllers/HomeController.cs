using Gabbetto.Word.Web.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{   
    public class HomeController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped application context
        /// </summary>
        protected ApplicationDbContext _context;

        /// <summary>
        /// The manager for handling user creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> _signInManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor, with a ApplicationDbContext parameter injected in by the service provider
        /// This is the class way of doing DI
        /// </summary>
        /// <param name="context"> The injected context </param>
        public HomeController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        } 

        #endregion

        public IActionResult Index()
        {                       
            //Make sure we have the database
            _context.Database.EnsureCreated();

            if (!_context.Settings.Any())
            {
                _context.Settings.Add(new SettingsDataModel
                {
                    Name = "BackgroundColor",
                    Value = "Red"
                });

                var numberOfSettingsLocally = _context.Settings.Local.Count();

                var numberOfSettingsDatabase = _context.Settings.Count();

                var firstSettingsLocal = _context.Settings.Local.FirstOrDefault();
                var firstSettingsDatabase = _context.Settings.FirstOrDefault();

                _context.SaveChanges();

                numberOfSettingsLocally = _context.Settings.Local.Count();

                numberOfSettingsDatabase = _context.Settings.Count();

                firstSettingsLocal = _context.Settings.Local.FirstOrDefault();
                firstSettingsDatabase = _context.Settings.FirstOrDefault();
            }            

            return View();
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "KGUltraz",
                Email = "lapadatrobert123@yahoo.com"
            }, "password");

            if(result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User creation failed", "text/html");
        }

        /// <summary>
        /// Private area
        /// </summary>
        /// <returns></returns>
        [Authorize] // this by default will send us to Account/Login route,if not logged in
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome { HttpContext.User.Identity.Name }", "text/html");
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        public async Task<IActionResult> LogutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("Done logout");
        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="returnUrl">The url to return to if successfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            // Sign out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // Sign user in with valid credentials
            var result = await _signInManager.PasswordSignInAsync("KGUltraz", "password", true, true);

            if (result.Succeeded)
            {
                // If we have no return URL...
                if (string.IsNullOrEmpty(returnUrl))
                    // Go to home
                    return RedirectToAction(nameof(Index));
                else
                    // Go to the return URL
                    return Redirect(returnUrl);
            }
            
            return Content("Failed to login", "text/html");
        }

        [Route("test")]
        public SettingsDataModel Test([FromBody]SettingsDataModel model)
        {
            return new SettingsDataModel { Id = "some id", Name = "Gabi", Value = "100" };
        }
    }
}
