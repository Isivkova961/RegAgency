using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecrutmentAgency.Data.Filters;


namespace RecrutmentAgency.Data
{
    [Filter(Type = typeof(UserFilter))]
    public class User: IUser<long>
    {
        public virtual long Id { get; set; }

        [FastSearch]
        public virtual string UserName { get; set; }


        public virtual string Password { get; set; }

        public virtual Role RoleName { get; set; }


       
    }

    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id);
            Map(u => u.UserName);   
            Map(u => u.Password);
            References(f => f.RoleName).Column("RoleId").Cascade.SaveUpdate();
        }
    }
}
