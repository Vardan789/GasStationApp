using System.Text;
using System.Text.Json;

namespace MauiApp1;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        string name = NewUsernameEntry.Text;
        string password = NewPasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        ErrorLabel.IsVisible = false;
        SuccessLabel.IsVisible = false;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            ErrorLabel.Text = "Please fill in all fields.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (password != confirmPassword)
        {
            ErrorLabel.Text = "Passwords do not match.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (password.Length < 6)
        {
            ErrorLabel.Text = "Password must be at least 6 characters long.";
            ErrorLabel.IsVisible = true;
            return;
        }

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("version","1");
            client.DefaultRequestHeaders.Add("OsType","2");
            client.BaseAddress = new Uri("http://localhost:5165");

            var registerData = new
            {
                Name = name,
                Password = password
            };

            string json = JsonSerializer.Serialize(registerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/v1/User/Register", content);

            if (response.IsSuccessStatusCode)
            {
                SuccessLabel.Text = "Account created successfully!";
                SuccessLabel.IsVisible = true;

                await Task.Delay(2000);
                await Navigation.PopAsync(); // Go back to login page
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                ErrorLabel.Text = $"Registration failed: {errorResponse}";
                ErrorLabel.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = $"Error: {ex.Message}";
            ErrorLabel.IsVisible = true;
        }
    }

    private async void OnNavigateToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
