using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public SelectList Roles { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Account Type")]
            public string Role { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var roles = _roleManager.Roles;
            Roles = new SelectList(roles, "Name", "Name");
        }

        // Temp hotfix for incorrect entry and losing SelectList entries.
        public void RegisterReload()
        {
            var roles = _roleManager.Roles;
            Roles = new SelectList(roles, "Name", "Name");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Home");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }



            // If we got this far, something failed, redisplay form
            return Page();
        }

        public async Task<IActionResult> OnGetFirstAsync(int number)
        {
            Random rng = new Random();

            InputModel Input = new InputModel()
            {
                Email = "fake@fake.com",
                Password = "Trash!2020",
                ConfirmPassword = "Trash!2020",
                Role = "Customer"
            };

            var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync(Input.Role))
                {
                    await _userManager.AddToRoleAsync(user, Input.Role);
                }
            }

            List<string> names = new List<string>
            {
                "Bob", "Sally", "Mark", "Brian", "Kyle", "Mary", "Minnie", "Mally", "Emily", "Amanda",
                 "Smith", "Burthen", "Samuel", "Tensil", "Herron", "Green", "Tall", "Bull", "Turnip", "Carrot", "Bark"
            };
            List<string> zipcodes = new List<string>
            {
                "63119", "63122", "63127"
            };
            List<string> weekdays = new List<string>()
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
            List<string> streetNames = new List<string>()
            {
                "Monica Dr.",
                "Floralea Pl",
                "Woodard Dr.",
                "Woodlawn Ave",
                "Enola Ct",
                "Rose Ave",
                "Eastbrook Ln.",
                "Selma Ave",
                "W Cedar Ave",
                "E Lockwood Ave",
                "Oak Terrace",
                "Oakland Ave"
            };


            Customer customer = new Customer
            {
                FirstName = names[rng.Next(21)],
                FamilyName = names[rng.Next(21)],
                PhoneNumber = "555-555-5555",
                EmailAddress = user.Email,
                WeeklyPickupDay = weekdays[rng.Next(7)],
                City = "St. Louis",
                ZipCode = zipcodes[rng.Next(3)],
                StreetAddress = rng.Next(110, 300).ToString() + " " + streetNames[rng.Next(12)]
            };

            customer.IdentityUserId = user.Id;
            customer.EmailAddress = user.Email;

            _context.Add(customer);
            _context.SaveChanges();

            return LocalRedirect(Url.Content("~/Home"));
        }
    }
}
