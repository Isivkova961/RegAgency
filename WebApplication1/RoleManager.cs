using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using RecrutmentAgency.Data;

namespace RecrutmentAgency
{
    public class RoleManager: RoleManager<Role, long>
    {
        public RoleManager(IRoleStore<Role, long> store) : base(store)
        {
        }
    }
}