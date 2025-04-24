namespace MauiApp1;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        string username = NewUsernameEntry.Text;
        string password = NewPasswordEntry.Text;

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            if (!MockAuth.Users.ContainsKey(username))
            {
                MockAuth.Users[username] = password;
                await DisplayAlert("Success", "Account created!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Username already exists.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
        }
    }

    private async void OnNavigateToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}