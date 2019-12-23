using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data.Filters
{
    public class FastSearchAttribute: Attribute
    {
        public FiledType FiledType { get; set; }
    }

    public enum FiledType
    {
        String,
        Int
    }
}
