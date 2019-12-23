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
    public class CandidateRepository : Repository<Candidate, CandidateFilter>
    {
        public CandidateRepository(ISession session) : base(session)
        {
        }

        protected override void SetupFilter(ICriteria crit, CandidateFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                crit.Add(Restrictions.Eq("LastName", filter.LastName));
            }
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                crit.Add(Restrictions.Eq("FirstName", filter.FirstName));
            }
            if (!string.IsNullOrEmpty(filter.Patronymic))
            {
                crit.Add(Restrictions.Eq("Patronymic", filter.Patronymic));
            }
            if (filter.DateBirth.From.HasValue)
            {
                crit.Add(Restrictions.Ge("DateBirth", filter.DateBirth.From.Value));
            }
            if (filter.DateBirth.To.HasValue)
            {
                crit.Add(Restrictions.Le("DateBirth", filter.DateBirth.To.Value));
            }
            if (!string.IsNullOrEmpty(filter.Experience))
            {
                crit.Add(Restrictions.Eq("Experience", filter.Experience));
            }
            if (filter.UserId != null && filter.UserId.Count > 0)
            {
                crit.Add(Restrictions.In("UserId", filter.UserId.ToArray()));
            }
        }

        public User GetByUser(Candidate userId)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("UserId", userId));
            return crit.UniqueResult<User>();
        }

        public User LoadByLogin(string login)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("UserName", login));
            return crit.UniqueResult<User>();
        }

        public PhotoFile GetByFile(PhotoFile file)
        {
            var crit = session.CreateCriteria<PhotoFile>()
                .Add(Restrictions.Eq("FileId", file));
            return crit.UniqueResult<PhotoFile>();
        }
    }
}
