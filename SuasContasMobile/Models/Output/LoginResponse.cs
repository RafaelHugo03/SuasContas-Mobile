using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuasContasMobile.Models.Output
{
    public class LoginResponse
    {
        public string AccessToken { get; private set; }

        public LoginResponse(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
