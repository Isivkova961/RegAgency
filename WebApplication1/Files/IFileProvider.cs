using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;

namespace RecrutmentAgency.Files
{
    public interface IFileProvider
    {
        string Name { get; }

        void Save(PhotoFile file, Stream content);

        Stream Load(PhotoFile file);
    }
}