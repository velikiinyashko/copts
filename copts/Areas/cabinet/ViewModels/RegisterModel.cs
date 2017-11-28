using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace copts.Areas.cabinet.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не введен Логин")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 6 до 20 символов")]
        [RegularExpression(@"[A-Za-z0-9]")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 6 до 20 символов")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[A-Za-z0-9]")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
