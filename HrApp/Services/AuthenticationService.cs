using HrApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private async Task<IdentityUser?> GetUser(string username, string email) 
        {
            IdentityUser identityUser = null;

            if (!string.IsNullOrEmpty(username))
                identityUser = await _userManager.FindByNameAsync(username);

            if (!string.IsNullOrEmpty(email))
                identityUser = await _userManager.FindByEmailAsync(email);


            return identityUser!;

        }

        public async Task<AuthenticationResult> SignInAsync(string username, string email, string password)
        {
            var user = await GetUser(username, email);

            if (user == null)
            {
                return AuthenticationResult.Failure("Onbekende gebruiker.");
            }

            var signin = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if(signin.Succeeded)
            {
                return AuthenticationResult.Success();
            }
            else
            {
                return AuthenticationResult.Failure("Ongeldig wachtwoord.");
            }
        }

        public async Task<AuthenticationResult> RegisterAsync(RegisterViewModel registrationData)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = registrationData.UserName,
                Email = registrationData.Email
            };

            IdentityResult registration = await _userManager.CreateAsync(user, registrationData.Password);

            if(!registration.Succeeded)
            {
                return AuthenticationResult.Failure(registration.Errors.Select(e => e.Description).FirstOrDefault());
            }

            return AuthenticationResult.Success();
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
