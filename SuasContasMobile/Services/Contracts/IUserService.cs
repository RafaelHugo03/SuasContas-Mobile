using SuasContasMobile.Models.Input;
using SuasContasMobile.Models.Output;

namespace SuasContasMobile.Services.Contracts
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<LoginResponse> CreateAccount(CreateAccountRequest request);
    }
}
