using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;
using RecrutmentAgency.Files;
using RecrutmentAgency.Validation;

namespace RecrutmentAgency.Models
{
    public class UserModel: EntityModel<User>
    {

        [Required]
        [Login]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Роль")]
        public Role Role { get; set; }


    }
}