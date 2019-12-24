using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Repositories;
using RecrutmentAgency.Models;

namespace RecrutmentAgency.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {     

        public HomeController()
        {

        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeModel 
            { 
                Title = "Кадровое агенство",
                Time = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        { 
            model.Time = DateTime.Now;
            return View(model);
        }
    }
}