using CommunityToolkit.Maui.Alerts;
using SuasContasMobile.Contracts;
using SuasContasMobile.Models.Input;
using SuasContasMobile.Services.Contracts;
using System.Text;

namespace SuasContasMobile.ViewModels;

[ObservableObject]
public partial class MainViewModel
{
    private readonly IUserService userService;

    [ObservableProperty]
    private string email;
    [ObservableProperty]
    private string password;

    public MainViewModel(IUserService userService)
    {
        this.userService = userService;
    }

    [RelayCommand]
    public async Task Login()
    {
        var loginRequest = new LoginRequest(email, password);

        var validator = new LoginContract(loginRequest);
        if(!validator.IsValid)
        {
            var messages = validator.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
            return;
        }

        var result = await userService.Login(loginRequest);

        if (string.IsNullOrEmpty(result.AccessToken))
        {
            await Toast.Make("A requisação falhou, tente novamente.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    [RelayCommand]
    public async Task CreateAccount()
    {
        await Shell.Current.GoToAsync(nameof(CreateAccountPage));
    }
}
