using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteEntityLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using CDASLiteUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CDASLiteUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IEmailSender emailSender, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
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
                var checkUsername = await userManager.FindByNameAsync(model.TRID);
                if (checkUsername != null)
                {
                    ModelState.AddModelError(nameof(model.TRID), "TR ID already registered !");
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
                    UserName = model.TRID,
                    Gender = model.Gender
                };

                var result = await userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(newUser, RoleNames.Passive.ToString());
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callBackcUrl = Url.Action("ConfirmEmail", "Account", new { UserId = newUser.Id, code = code },protocol : Request.Scheme);

                    var emailMessage = new EmailMessage()
                    {
                        Contacts = new string[] { newUser.Email },
                        Subject = "CDASLite - Email Activation",
                        Body = $"Hello {newUser.Name} {newUser.Surname} <br/>Click <a href='{HtmlEncoder.Default.Encode(callBackcUrl)}'>here</a> to activate your account"
                    };
                    await emailSender.SendAsync(emailMessage);

                    Patient newPatient = new Patient()  //Add patient to patient's table
                    {
                        TRID = model.TRID,
                        UserId = newUser.Id
                    };
                    if (unitOfWork.PatientReposittory.Add(newPatient) == false)
                    {
                        //Send mail to administrator if an error occurs.
                        var emailMessageToAdmin = new EmailMessage()
                        {
                            Contacts = new string[] { configuration.GetSection("ManagerEmails:Email").Value },
                            Cc = new string[] { configuration.GetSection("ManagerEmails:EmailToCC").Value },
                            Subject = "CDASLite - Error! Patient Table",
                            Body = $"Error occured while adding passive user to the patient table with following information: TRID: {model.TRID}, UserId: {newUser.Id}"
                        };
                        await emailSender.SendAsync(emailMessageToAdmin);

                    }
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
                if (userId == null || code == null)
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Proper data entry is required!");
                    return View(model);
                }

                //Find user and control whether email has been confirmed or not.
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "In order to activate your system and use your account, check your email and click activation link");
                        return View(model);
                    }
                }

                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or password!");
                    return View(model);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An unexpected error has occured!");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ViewBag.ResetPasswordMessage = "Email can not be found!";
                }
                else
                {
                    var code = await userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callBackUrl = Url.Action("ConfirmResetPassword","Account", new { userId = user.Id, code = code }, protocol : Request.Scheme);
                    var emailMessage = new EmailMessage()
                    {
                        Contacts = new string [] {user.Email},
                        Subject = "CDASLite - Forgot my password",
                        Body = $"Hello {user.Name} {user.Surname}!<br/>Click <a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>here</a> to renew your password."
                    };
                    await emailSender.SendAsync(emailMessage);
                    ViewBag.ResetPasswordMessage = "Password reset instructions have been sent to your email address.";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ResetPasswordMessage = "An unexpected error has occured!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConfirmResetPassword(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                //return BadRequest("test");
                ModelState.AddModelError(string.Empty, "User not found!");
                return View();
            }
            ViewBag.UserId = userId;
            ViewBag.Code = code;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found!");
                    return View(model);
                }
                var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));
                var result = await userManager.ResetPasswordAsync(user, code, model.NewPassword);
                if (result.Succeeded)
                {
                    TempData["ConfirmResetPasswordMessage"] = "Your password has been successfully reset.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Password reset failed");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error has occured!");
                return View(model);
            }
        }

        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", "Account", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }        
        
        public IActionResult FacebookLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", "Account", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }

        public IActionResult ExternalResponse(string returnUrl = "/")
        {
            try
            {
                ExternalLoginInfo info = signInManager.GetExternalLoginInfoAsync().Result;
                Microsoft.AspNetCore.Identity.SignInResult result = signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(returnUrl);
                }
                else
                {
                    AppUser newUser = new AppUser();
                    newUser.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                    string externalUserId = info.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var userExistence = userManager.FindByEmailAsync(newUser.Email).Result;

                    if (userExistence == null)
                    {
                        IdentityResult createResult = userManager.CreateAsync(newUser).Result;
                        if (createResult.Succeeded)
                        {
                            IdentityResult loginResult = userManager.AddLoginAsync(newUser, info).Result;
                            if (loginResult.Succeeded)
                            {
                                signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true);
                                return RedirectToAction(returnUrl);
                            }
                            else
                            {
                                AddModelErrors(loginResult);
                            }
                        }
                        else
                        {
                            AddModelErrors(createResult);
                        }
                    }
                    else
                    {
                        IdentityResult loginResult = userManager.AddLoginAsync(userExistence, info).Result;
                        signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true);
                        return RedirectToAction(returnUrl);
                    }
                }
                return RedirectToAction("/");
            }
            catch (Exception)
            {
                return RedirectToAction("/");
            }
        }
    }
}
