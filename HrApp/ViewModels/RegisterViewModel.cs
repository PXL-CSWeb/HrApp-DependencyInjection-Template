using System.ComponentModel.DataAnnotations;

namespace HrApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
