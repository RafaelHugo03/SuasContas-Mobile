namespace SuasContasMobile.Models.Input
{
    public class LoginRequest
    {
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }

        public LoginRequest(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
