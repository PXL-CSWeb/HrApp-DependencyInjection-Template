using Microsoft.AspNetCore.Identity;

namespace HrApp.Services
{
    public class AuthenticationResult
    {
        private List<string> _errors = new List<string>();

        public IEnumerable<string> Errors => _errors;
        public IdentityUser IdentityUser { get; private set; } = default!;
        public bool Succeeded { get; private set; }

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        internal AuthenticationResult()
        {
            //internal constructor: Alleen de static methods van deze klasse kunnen een instantie aanmaken.
            //Op deze manier vermijdt je eenvoudig een "corrupte" instantie zoals een succes resultaat met errors.
        }

        public static AuthenticationResult Failure(string errorMessage)
        {
            var result = new AuthenticationResult()
            {
                Succeeded = false
            };
            result.AddError(errorMessage);
            return result;
        }

        public static AuthenticationResult Success() 
        {
            var result = new AuthenticationResult()
            {
                Succeeded = true
            };
            return result;
        }

        public static AuthenticationResult Success(IdentityUser user)
        {
            var result = new AuthenticationResult()
            {
                Succeeded = true,
                IdentityUser = user
            };
            return result;
        }
    }
}
