using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteEntityLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CDASLiteUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IEmailSender emailSender;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IEmailSender emailSender)
        {
           this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            CheckRoles();
        }

        private void CheckRoles()
        {
            var allRoles = Enum.GetNames(typeof(RoleNames));
            foreach (var item in allRoles)
            {
                if (!roleManager.RoleExistsAsync(item).Result)
                {
                    var result = roleManager.CreateAsync(new AppRole()
                    {
                        Name = item,
                        Description = item
                    }).Result;
                }
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var checkUsername = await userManager.FindByNameAsync(model.UserName);
                if (checkUsername != null)
                {
                    ModelState.AddModelError(nameof(model.UserName), "Username already exists!");
                    return View(model);
                }
                var checkEmail = await userManager.FindByEmailAsync(model.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError(nameof(model.Email), "Email already exists!");
                    return View(model);
                }
                AppUser newUser = new AppUser()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Gender = model.Gender
                };

                var result = await userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(newUser, RoleNames.Patient.ToString());
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callBackcUrl = Url.Action("ConfirmEmail", "Account", new { UserId = newUser.Id, code = code },protocol : Request.Scheme);

                    var emailMessage = new EmailMessage()
                    {
                        Contacts = new string[] { newUser.Email },
                        Subject = "CDASLite - Email Activation",
                        Body = $"Hello {newUser.Name} {newUser.Surname} <br/>Click <ahref='{HtmlEncoder.Default.Encode(callBackcUrl)}'>here</a> to activate your account"
                    };
                    await emailSender.SendAsnc(emailMessage);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "An unexpected error has occured!");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            try
            {
                if (userId == null ||code == null)
                {
                    return NotFound("Page not found!");
                }
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound("User no found!");
                }

                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

                //EmailConfirmed = 1 or True
                var result =await userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                    //Is userRole passive?
                    if (userManager.IsInRoleAsync(user, RoleNames.Passive.ToString()).Result)
                    {
                        await userManager.RemoveFromRoleAsync(user, RoleNames.Passive.ToString());
                        await userManager.AddToRoleAsync(user, RoleNames.Patient.ToString());
                    }
                    TempData["EmailConfirmedMessage"] = "Your account has been activated.";
                    return RedirectToAction("Login", "Account");
                }

                ViewBag.EmailConfirmedMessage = "Your account activation failed!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.EmailConfirmedMessage = "An unexpected error has occured! Try again!";
                return View();
            }
        }
    }
}
