using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecrutmentAgency.Data.Repositories;

namespace RecrutmentAgency.Controllers
{
    public class FileController: BaseController
    {
        private FileRepository fileRepository;

        public FileController(FileRepository fileRepository)
        { 
            this.fileRepository = fileRepository;
        }

        public ActionResult Download(long id)
        {
            var photoFile = fileRepository.Load(id);
            var stream = GetFileProvider().Load(photoFile);
            if (stream == null)
            {
                return new EmptyResult();
            }
            return File(stream, photoFile.ContentType, photoFile.FileName);           
        }
    }
}