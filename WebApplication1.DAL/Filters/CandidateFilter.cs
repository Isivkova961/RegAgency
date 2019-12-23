using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data.Filters
{
    public class CandidateFilter: BaseFilter
    {
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DisplayName("Дата рождения")]
        public Range<DateTime> DateBirth { get; set; }
        [DisplayName("Опыт")]
        public string Experience { get; set; }

        public IList<User> UserId { get; set; }
    }
}
