using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;

namespace RecrutmentAgency.Models
{
    public class VacancyListModel : EntityListModel<Vacancy>
    {
        public Vacancy Vacancy { get; set; }
    }
}