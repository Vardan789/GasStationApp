using QRCoder;


namespace MauiApp1
{
    public partial class QrPage : ContentPage
    {
        public QrPage(string qrText)
        {
            InitializeComponent();
            GenerateQr(qrText);
        }

        private async void GenerateQr(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            byte[] qrCodeAsPng = qrCode.GetGraphic(20);

            // Save QR code to the AppData directory
            string filePath = Path.Combine(FileSystem.AppDataDirectory, $"qr_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            try
            {
                // Write the QR code to the file
                File.WriteAllBytes(filePath, qrCodeAsPng);

                // Optionally display the QR code as an image in the app
                qrImage.Source = ImageSource.FromFile(filePath);

                Console.WriteLine($"QR code saved at: {filePath}");

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    MockPurchaseHistory.AddPurchase(new PurchaseHistoryItem
                    {
                        ProductTitle = "Fuel Purchase",
                        QRCodeImageFilePath = filePath,
                        PurchaseDate = DateTime.Now
                    });
                });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving QR code: {ex.Message}");
            }
        }

        private async void OnDoneClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}