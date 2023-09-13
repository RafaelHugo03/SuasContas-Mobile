using Flunt.Validations;
using SuasContasMobile.Models.Input;

namespace SuasContasMobile.Contracts
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest request)
        {
            Requires()
                .IsEmail(request.EmailAddress, nameof(request.EmailAddress), "E-mail is invalid")
                .IsNotNullOrEmpty(request.EmailAddress, nameof(request.EmailAddress), "E-mail is invalid");

            Requires()
                .IsNotNullOrEmpty(request.Password, nameof(request.Password), "Password is invalid");
        }
    }
}
