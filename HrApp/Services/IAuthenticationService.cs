using HrApp.ViewModels;

namespace HrApp.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> SignInAsync(string username, string email, string password);
        Task SignOutAsync();
        Task<AuthenticationResult> RegisterAsync(RegisterViewModel registerData);
 
    }
}
