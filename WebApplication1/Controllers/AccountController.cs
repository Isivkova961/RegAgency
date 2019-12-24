using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using NHibernate;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Repositories;
using RecrutmentAgency.Models;
using Microsoft.Owin.Security;

namespace RecrutmentAgency.Controllers
{
    public class AccountController: Controller
    {
        private UserRepository userRepository;

        public AccountController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Result == SignInStatus.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                RoleName = userRepository.GetByRole(3)
            };
            var res = UserManager.CreateAsync(user, model.Password);
            if (res.Result == IdentityResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}