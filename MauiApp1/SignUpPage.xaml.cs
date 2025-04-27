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
        string confirmPassword = ConfirmPasswordEntry.Text;

        // Hide any previous error messages
        ErrorLabel.IsVisible = false;
        SuccessLabel.IsVisible = false;  // Hide success message initially

        // Check if all fields are filled
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            ErrorLabel.Text = "Please fill in all fields.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Validate email format (simple check for '@' character)
        if (!username.Contains('@'))
        {
            ErrorLabel.Text = "Please enter a valid email address.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Check if passwords match
        if (password != confirmPassword)
        {
            ErrorLabel.Text = "Passwords do not match.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Simple password strength check (length >= 6)
        if (password.Length < 6)
        {
            ErrorLabel.Text = "Password must be at least 6 characters long.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Check if username already exists (using mock data)
        if (!MockAuth.Users.ContainsKey(username))
        {
            MockAuth.Users[username] = password;

            // Show success message
            SuccessLabel.Text = "Account created successfully!";
            SuccessLabel.IsVisible = true;

            // Navigate to the login page after 2 seconds
            await Task.Delay(2000); // Wait for 2 seconds to display success message
            await Navigation.PopAsync(); // Navigate back to login page
        }
        else
        {
            ErrorLabel.Text = "Username already exists.";
            ErrorLabel.IsVisible = true;
        }
    }

    private async void OnNavigateToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();  // Navigate back to login page
    }
}
