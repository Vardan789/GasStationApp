namespace MauiApp1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Check if username or password is empty or null
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                // Show error if either field is empty
                ErrorLabel.Text = "Please enter both username and password.";
                ErrorLabel.IsVisible = true;
                return;  // Exit the method early
            }

            // Check if the user exists and if the password matches
            if (MockAuth.Users.TryGetValue(username, out string storedPass) && storedPass == password)
            {
                // If credentials are correct, navigate to the home page (AppShell)
                Application.Current.MainPage = new AppShell();  // Redirect to AppShell (home page)
            }
            else
            {
                // If credentials are invalid, show an error and stay on the login page
                ErrorLabel.Text = "Invalid username or password.";
                ErrorLabel.IsVisible = true;  // Show the error message label
            }
        }

        private async void OnNavigateToSignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        // This method is triggered when the eye icon is clicked
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
}