using System.ComponentModel.DataAnnotations;

namespace HrApp.ViewModels
{
    public class LoginEmailViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
