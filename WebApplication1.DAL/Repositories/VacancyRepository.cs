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
    public class VacancyRepository : Repository<Vacancy, VacancyFilter>
    {
        public VacancyRepository(ISession session) : base(session)
        {
        }

        protected override void SetupFilter(ICriteria crit, VacancyFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                crit.Add(Restrictions.Eq("Name", filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                crit.Add(Restrictions.Eq("Description", filter.Description));
            }
            if (filter.DateBegin.From.HasValue)
            {
                crit.Add(Restrictions.Ge("DateBegin", filter.DateBegin.From.Value));
            }
            if (filter.DateBegin.To.HasValue)
            {
                crit.Add(Restrictions.Le("DateBegin", filter.DateBegin.To.Value));
            }
            if (filter.DateEnd.From.HasValue)
            {
                crit.Add(Restrictions.Ge("DateEnd", filter.DateEnd.From.Value));
            }
            if (filter.DateEnd.To.HasValue)
            {
                crit.Add(Restrictions.Le("DateEnd", filter.DateEnd.To.Value));
            }
            if (!string.IsNullOrEmpty(filter.Company))
            {
                crit.Add(Restrictions.Eq("Company", filter.Company));
            }
            if (!string.IsNullOrEmpty(filter.Demand))
            {
                crit.Add(Restrictions.Eq("Demand", filter.Demand));
            }
            if (filter.Salary.From.HasValue)
            {
                crit.Add(Restrictions.Ge("Salary", filter.Salary.From.Value));
            }
            if (filter.Salary.To.HasValue)
            {
                crit.Add(Restrictions.Le("Salary", filter.Salary.To.Value));
            }
            if (filter.UserId != null && filter.UserId.Count > 0)
            {
                crit.Add(Restrictions.In("UserId", filter.UserId.ToArray()));
            }
        }

        public User GetByUser(Vacancy userId)
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
    }
}
