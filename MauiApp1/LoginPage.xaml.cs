using System.Text;
using System.Text.Json;

namespace MauiApp1;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please enter both username and password.";
            ErrorLabel.IsVisible = true;
            return;
        }

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("version","1");
            client.DefaultRequestHeaders.Add("OsType","2");
            client.BaseAddress = new Uri("http://localhost:5165");

            var loginData = new
            {
                Username = username,
                Password = password
            };

            string json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/api/v1/User/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    // Successful login
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    ErrorLabel.Text = "Invalid username or password.";
                    ErrorLabel.IsVisible = true;
                }
        }
        catch (Exception ex)
        {
            // Handle error, e.g., server unreachable
            ErrorLabel.Text = $"Error: {ex.Message}";
            ErrorLabel.IsVisible = true;
        }
    }


    private async void OnNavigateToSignUpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

    private void OnEyeIconClicked(object sender, EventArgs e)
    {
        // Toggle the password visibility
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
    }
}

public static class MockAuth
{
    public static Dictionary<string, string> Users = new()
    {
        { "admin", "password" },
        { "user1", "1234" },
        { "testuser", "test123" }
    };
}