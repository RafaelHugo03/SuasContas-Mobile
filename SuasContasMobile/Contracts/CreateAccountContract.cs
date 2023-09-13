using Flunt.Validations;
using SuasContasMobile.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuasContasMobile.Contracts
{
    public class CreateAccountContract : Contract<CreateAccountRequest>
    {
        public CreateAccountContract(CreateAccountRequest request) 
        {
            Requires()
                .IsNotNullOrEmpty(request.Name, nameof(request.Name), "Name is invalid");

            Requires()
               .IsEmail(request.EmailAddress, nameof(request.EmailAddress), "E-mail is invalid")
               .IsNotNullOrEmpty(request.EmailAddress, nameof(request.EmailAddress), "E-mail is invalid");

            Requires()
                .IsNotNullOrEmpty(request.Password, nameof(request.Password), "Password is invalid");
        }
    }
}
