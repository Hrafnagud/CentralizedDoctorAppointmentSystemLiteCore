using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteEntityLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using CDASLiteUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CDASLiteUI.Areas.Management.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public DoctorController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IEmailSender emailSender, IUnitOfWork unitOfWork, IConfiguration configuration)
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
                    var roleResult = await userManager.AddToRoleAsync(newUser, RoleNames.PassiveDoctor.ToString());
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callBackcUrl = Url.Action("ConfirmEmail", "Account", new { UserId = newUser.Id, code = code }, protocol: Request.Scheme);

                    var emailMessage = new EmailMessage()
                    {
                        Contacts = new string[] { newUser.Email },
                        Subject = "CDASLite - Email Activation",
                        Body = $"Hello DR. {newUser.Name} {newUser.Surname}, <br/>Click <a href='{HtmlEncoder.Default.Encode(callBackcUrl)}'>here</a> to activate your account"
                    };
                    await emailSender.SendAsync(emailMessage);

                    Doctor newDoctor= new Doctor()  //Add doctor to doctor's table
                    {
                        TRID = model.TRID,
                        UserId = newUser.Id
                    };
                    if (unitOfWork.DoctorReposittory.Add(newDoctor) == false)
                    {
                        //Send mail to administrator if an error occurs.
                        var emailMessageToAdmin = new EmailMessage()
                        {
                            Contacts = new string[] { configuration.GetSection("ManagerEmails:Email").Value },
                            Cc = new string[] { configuration.GetSection("ManagerEmails:EmailToCC").Value },
                            Subject = "CDASLite - Error! Doctor Table",
                            Body = $"Error occured while adding passive user to the doctor table with following information: TRID: {model.TRID}, UserId: {newUser.Id}"
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
    }
}
