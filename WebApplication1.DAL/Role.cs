using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity;

namespace RecrutmentAgency.Data
{
    public class Role:IRole<long>
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }

    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(f => f.Id);
            Map(f => f.Name);
        }
    }
}
