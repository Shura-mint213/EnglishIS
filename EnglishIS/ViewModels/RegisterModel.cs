using System.ComponentModel.DataAnnotations;

namespace EnglishIS.ViewModels
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
