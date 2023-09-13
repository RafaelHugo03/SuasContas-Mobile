namespace SuasContasMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
