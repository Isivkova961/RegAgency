using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace RecrutmentAgency.Data
{
    public class PhotoFileContent
    {
        public virtual long Id { get; set; }

        public virtual PhotoFile PhotoFile { get; set; }

        public virtual byte[] Content { get; set; }

    }

    public class PhotoFileContentMap : ClassMap<PhotoFileContent>
    {
        public PhotoFileContentMap()
        {
            Id(f => f.Id);
            Map(f => f.Content);
            References(f => f.PhotoFile).Column("PhotoFileId").Cascade.SaveUpdate();
        }
    }
}
