using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RecrutmentAgency.Data.Filters;
using RecrutmentAgency.Data.Repositories;

namespace RecrutmentAgency
{
    public static class EntityHelper
    {
        public static IRepository GetRepository(Type type)
        {
            var filterType = type.GetCustomAttribute<Data.Filters.FilterAttribute>();
            var repType = typeof(Repository<,>).MakeGenericType(type, filterType.Type);
            return (IRepository)DependencyResolver.Current.GetService(repType);
        }
    }
}
