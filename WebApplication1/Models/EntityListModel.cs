using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecrutmentAgency.Models
{
    public class EntityListModel<T>
    {
        public IList<T> Items { get; set; }
    }
}