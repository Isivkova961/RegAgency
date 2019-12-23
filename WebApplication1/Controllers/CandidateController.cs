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
    public class CandidateController: BaseController
    {
        private CandidateRepository candidateRepository;

        public CandidateController(CandidateRepository candidateRepository)
        { 
            this.candidateRepository = candidateRepository;
        }

        public ActionResult Create()
        {
            var model = new CandidateEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CandidateEditModel model)
        { 
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            var candidate = new Candidate
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                DateBirth = model.DateBirth,
                Experience = model.Experience,
                FileId = model.Photo != null ? model.Photo.PhotoFile: null,
                UserId = candidateRepository.LoadByLogin(User.Identity.Name)
            };
            if (model.Photo != null)
            {
                GetFileProvider().Save(model.Photo.PhotoFile, model.Photo.PostedFile.InputStream);
            }
            candidateRepository.Save(candidate);
            return View(model);
        }


        public ActionResult List(CandidateFilter filter)
        {
            var model = new CandidateListModel
            {
                Items = candidateRepository.Find(filter)
            };
            return View(model);
        }
    }
}