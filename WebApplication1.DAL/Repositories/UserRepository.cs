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
    public class UserRepository : Repository<User, UserFilter>
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }

        public bool Exists(string login)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("UserName", login))
                .SetProjection(Projections.Count("Id"));
            var count = Convert.ToInt64(crit.UniqueResult());
            return count > 0;
        }



        protected override void SetupFilter(ICriteria crit, UserFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (!string.IsNullOrEmpty(filter.Login))
            {
                crit.Add(Restrictions.Eq("Login", filter.Login));
            }

        }
    }
}
