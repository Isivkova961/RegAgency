using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;

namespace RecrutmentAgency.Models
{
    public class VacancyEditModel: EntityModel<Vacancy>
    {
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата начала")]
        public DateTime DateBegin { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата окончания")]
        public DateTime DateEnd { get; set; }
        [DisplayName("Компания")]
        public string Company { get; set; }
        [DisplayName("Требования")]
        public string Demand { get; set; }
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }
        public User UserId { get; set; }

    }
}