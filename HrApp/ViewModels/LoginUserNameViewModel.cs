using System.ComponentModel.DataAnnotations;

namespace HrApp.ViewModels
{
    public class LoginUserNameViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
