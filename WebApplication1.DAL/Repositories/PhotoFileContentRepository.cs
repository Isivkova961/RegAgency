using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using RecrutmentAgency.Data.Filters;

namespace RecrutmentAgency.Data.Repositories
{
    public class PhotoFileContentRepository: Repository<PhotoFileContent, PhotoFileContentFilter>
    {
        public PhotoFileContentRepository(ISession session) : base(session)
        {
        }

        public PhotoFileContent GetByBinaryFile(PhotoFile file)
        {
            var crit = session.CreateCriteria<PhotoFileContent>()
                .Add(Restrictions.Eq("PhotoFile", file));
            return crit.UniqueResult<PhotoFileContent>();
        }
    }
}
