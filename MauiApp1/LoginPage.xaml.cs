namespace MauiApp1
{
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

            if (MockAuth.Users.TryGetValue(username, out string storedPass) && storedPass == password)
            {
                //Application.Current.MainPage = new NavigationPage(new MainPage());

                // Optionally, you could use a delay here for better UX if needed:
                 await Task.Delay(300);
                 Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid credentials", "OK");
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