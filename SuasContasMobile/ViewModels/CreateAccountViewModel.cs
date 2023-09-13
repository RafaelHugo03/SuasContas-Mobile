using CommunityToolkit.Maui.Alerts;
using SuasContasMobile.Contracts;
using SuasContasMobile.Models.Input;
using SuasContasMobile.Services.Contracts;
using System.Text;

namespace SuasContasMobile.ViewModels
{
    [ObservableObject]
    public partial class CreateAccountViewModel
    {
        private readonly IUserService userService;

        [ObservableProperty]
        public string email;
        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string passwordConfirm;

        public CreateAccountViewModel(IUserService userService)
        {
            this.userService = userService; 
        }

        [RelayCommand]
        public async Task CreateAccount()
        {
            var request = new CreateAccountRequest
            {
                EmailAddress = email,
                Password = password,
                Name = name
            };

            var validator = new CreateAccountContract(request);

            if (!validator.IsValid)
            {
                var messages = validator.Notifications.Select(x => x.Message);
                var sb = new StringBuilder();

                foreach (var message in messages)
                    sb.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
                return;
            }

            var result = await userService.CreateAccount(request);

            if (string.IsNullOrEmpty(result.AccessToken))
            {
                await Toast.Make("A requisação falhou, tente novamente.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                return;
            }

            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}
