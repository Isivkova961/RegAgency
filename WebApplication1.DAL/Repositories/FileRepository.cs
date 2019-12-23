using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using RecrutmentAgency.Data.Filters;

namespace RecrutmentAgency.Data.Repositories
{
    public class FileRepository : Repository<PhotoFile, FileFilter>
    {
        public FileRepository(ISession session) : base(session)
        {
        }
    }
}
