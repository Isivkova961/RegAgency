using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;
using RecrutmentAgency.Files;

namespace RecrutmentAgency.Models
{
    public class CandidateEditModel: EntityModel<Candidate>
    {
        [Required]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }
        [DisplayName("Опыт")]
        public string Experience { get; set; }
        public User UserId { get; set; }

        [DisplayName("Фото")]
        [DataType(DataType.Upload)]
        public PhotoFileWrapper Photo { get; set; }
    }
}