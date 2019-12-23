using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data.Filters
{
    public class FilterAttribute: Attribute
    {
        public Type Type { get; set; }
    }
}
