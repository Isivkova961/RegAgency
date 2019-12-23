using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using RecrutmentAgency.Data.Filters;

namespace RecrutmentAgency.Models
{
    public class SortLinkModel
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public SortDirection? SortDirection { get; set; }

        public RouteValueDictionary RouteValues { get; set; }

        public string LinkText { get; set; }
    }
}