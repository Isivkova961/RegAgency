using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace RecrutmentAgency.Data
{
    public class PhotoFile
    {
        public virtual long Id { get; set; }

        public virtual string FileName { get; set; }

        public virtual string ContentType { get; set; }

        public virtual long Length { get; set; }
    }

    public class PhotoFileMap : ClassMap<PhotoFile>
    {
        public PhotoFileMap()
        {
            Id(f => f.Id);
            Map(f => f.FileName);
            Map(f => f.ContentType);
            Map(f => f.Length);
        }
    }
}
