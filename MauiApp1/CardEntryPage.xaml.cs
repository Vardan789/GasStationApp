namespace MauiApp1
{
    public partial class CardEntryPage : ContentPage
    {
        private readonly HomePageDataProductDto _product;
        private readonly decimal _liters;

        public CardEntryPage(HomePageDataProductDto product, decimal liters)
        {
            InitializeComponent();
            _product = product;
            _liters = liters;
        }

        private void OnCardNumberChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            var digitsOnly = new string(entry.Text?.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length > 16)
                digitsOnly = digitsOnly.Substring(0, 16);

            var formatted = string.Join(" ", Enumerable.Range(0, digitsOnly.Length / 4 + 1)
                .Select(i => i * 4 < digitsOnly.Length ? digitsOnly.Substring(i * 4, Math.Min(4, digitsOnly.Length - i * 4)) : "")
                .Where(s => !string.IsNullOrEmpty(s)));

            entry.Text = formatted;
        }

        private void OnCvvChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            var digitsOnly = new string(entry.Text?.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length > 3)
                digitsOnly = digitsOnly.Substring(0, 3);

            entry.Text = digitsOnly;
        }

        private void OnExpiryDateChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            var raw = new string(entry.Text?.Where(char.IsDigit).ToArray());

            if (raw.Length > 4)
                raw = raw.Substring(0, 4);

            string formatted;
            if (raw.Length <= 2)
            {
                formatted = raw;
            }
            else
            {
                formatted = raw.Insert(2, "/");
            }

            entry.Text = formatted;
        }
        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Simulate validation
            if (string.IsNullOrWhiteSpace(CardNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(ExpiryDateEntry.Text) ||
                string.IsNullOrWhiteSpace(CvvEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields correctly.", "OK");
                return;
            }

            // Generate the QR text with liters
            string qrText = $"Fuel QR Code: {_liters} liters purchased at {_product.Title}";

            // Add purchase history (simulated)
            MockPurchaseHistory.AddPurchase(new PurchaseHistoryItem
            {
                ProductTitle = _product.Title,
                QRCodeImageSource = ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/8/8a/Qr-2.png")), // temporary sample image
                PurchaseDate = DateTime.Now
            });

            // Navigate to QR page and pass the QR text
            await Navigation.PushAsync(new QrPage(qrText));
        }
    }
}
