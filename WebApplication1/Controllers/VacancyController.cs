using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Filters;
using RecrutmentAgency.Data.Repositories;
using RecrutmentAgency.Models;

namespace RecrutmentAgency.Controllers
{
    [Authorize]
    public class VacancyController: BaseController
    {
        private VacancyRepository vacancyRepository;

        public VacancyController(VacancyRepository vacancyRepository)
        { 
            this.vacancyRepository = vacancyRepository;
        }

        public ActionResult Create()
        {
            var model = new VacancyEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VacancyEditModel model)
        { 
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            var vacancy = new Vacancy
            {
                Name = model.Name,
                Description = model.Description,
                DateBegin = model.DateBegin,
                DateEnd = model.DateEnd,
                Demand = model.Demand,
                Company = model.Company,
                Salary = model.Salary,
                UserId = vacancyRepository.LoadByLogin(User.Identity.Name)
            };
            vacancyRepository.Save(vacancy);
            return RedirectToAction("List");
        }


        public ActionResult List(VacancyFilter filter)
        {
            var model = new VacancyListModel
            {
                Items = vacancyRepository.Find(filter)
            };
            return View(model);
        }

        public ActionResult Index(long? vacancy, FetchOptions fetchOptions)
        {
            Vacancy vacancyData = null;
            if (vacancy.HasValue)
            {
                vacancyData = vacancyRepository.Load(vacancy.Value);
            }
            var model = new VacancyListModel
            {
                Items = vacancyRepository.Find(new VacancyFilter { Vacancy = vacancyData }, fetchOptions),
            };
            return View("List", model);
        }
    }
}