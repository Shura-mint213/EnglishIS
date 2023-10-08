using System.ComponentModel.DataAnnotations;

namespace EnglishIS.ViewModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Не указан логин")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
