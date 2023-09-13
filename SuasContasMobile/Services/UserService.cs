using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using SuasContasMobile.Models.Input;
using SuasContasMobile.Models.Output;
using SuasContasMobile.Services.Contracts;
using System.Text;

namespace SuasContasMobile.Services
{
    public class UserService : IUserService
    {
        public async Task<LoginResponse> CreateAccount(CreateAccountRequest request)
        {
            try
            {
                var response = await Helper.Constants.BASE_API_URL
                    .AppendPathSegment("/user/register")
                    .WithTimeout(30)
                    .PostJsonAsync(request);

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponse>(content);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new LoginResponse(null);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
			try
			{
                var response = await Helper.Constants.BASE_API_URL
                    .AppendPathSegment("/user/login")
                    .WithTimeout(30)
                    .PostJsonAsync(request);

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponse>(content);
                }
            }
            catch (Exception)
			{
				throw;
			}
            return new LoginResponse(null);
        }
    }
}
