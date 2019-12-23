using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecrutmentAgency.Files
{
    public class PhotoFileModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var key = !string.IsNullOrEmpty(bindingContext.ModelName) ? bindingContext.ModelName + ".PostedFile" : "PostedFile";
            var res = bindingContext.ValueProvider.GetValue(key);
            if (res == null)
            {
                return null;
            }
            var postedFile = (HttpPostedFileBase) res.ConvertTo(typeof(HttpPostedFileBase));
            if (postedFile == null || postedFile.InputStream == null)
            {
                return null;
            }
            return new PhotoFileWrapper { 
                PhotoFile = new Data.PhotoFile { 
                    FileName = postedFile.FileName,
                    ContentType = postedFile.ContentType,
                    Length = postedFile.ContentLength
                },
                PostedFile = postedFile
            };
        }
    }
}