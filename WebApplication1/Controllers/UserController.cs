using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Filters;
using RecrutmentAgency.Data.Repositories;
using RecrutmentAgency.Files;
using RecrutmentAgency.Models;

namespace RecrutmentAgency.Controllers
{
    [Authorize]
    public class UserController: BaseController
    {
        private UserRepository userRepository;        

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public RoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<RoleManager>(); }
        }

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Create()
        {           
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
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
                return RedirectToAction("List");
            }
            return View(model);
        }

        public ActionResult List(UserFilter filter)
        {
            var model = new UserListModel 
            {
                Items = userRepository.Find(filter)
            };
            return View(model);
        }        

    }
}