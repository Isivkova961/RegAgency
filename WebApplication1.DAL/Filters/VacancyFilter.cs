using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data.Filters
{
    public class VacancyFilter: BaseFilter
    {
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Дата открытия")]
        public Range<DateTime> DateBegin { get; set; }
        [DisplayName("Дата закрытия")]
        public Range<DateTime> DateEnd { get; set; }
        [DisplayName("Компания")]
        public string Company { get; set; }
        [DisplayName("Требование")]
        public string Demand { get; set; }
        [DisplayName("Зарплата")]
        public Range<decimal> Salary { get; set; }
        public IList<User> UserId { get; set; }

        public Vacancy Vacancy { get; set; }
    }                  
}
