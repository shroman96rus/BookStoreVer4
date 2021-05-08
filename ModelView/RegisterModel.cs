using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.ModelView
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Вы не указали имя")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Вы не указали Фамилию")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Вы не ввели пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Вы не ввели пароль")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "Вы не указали адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Вы не указали номер телефна")]
        [DataType(DataType.PhoneNumber)]
        public int phoneNumber { get; set; }
    }
}
