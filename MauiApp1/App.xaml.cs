namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        /*bool isLoggedIn = CheckLoginStatus();
        return new Window(isLoggedIn ? new AppShell() : new NavigationPage(new LoginPage()));bool isLoggedIn = CheckLoginStatus();
        return new Window(isLoggedIn ? new AppShell() : new NavigationPage(new LoginPage()));*/
        
        // Use LoginPage for now instead of AppShell
        return new Window(new NavigationPage(new LoginPage()));
    }
    
}