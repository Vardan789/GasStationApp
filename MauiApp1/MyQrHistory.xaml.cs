namespace MauiApp1
{
    public partial class MyQrHistory : ContentPage
    {
        public MyQrHistory()
        {
            InitializeComponent();

            // Adding mock data to the list
            MockPurchaseHistory.AddPurchase(new PurchaseHistoryItem
            {
                ProductTitle = "Premium Gasoline",
                QRCodeImageBase64 = "qr.jpeg",
                PurchaseDate = DateTime.Now.AddDays(-1)
            });

            MockPurchaseHistory.AddPurchase(new PurchaseHistoryItem
            {
                ProductTitle = "Super Diesel",
                QRCodeImageBase64 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA...",
                PurchaseDate = DateTime.Now.AddDays(-2)
            });

            // Binding the mock purchase history to the CollectionView
            QRListView.ItemsSource = MockPurchaseHistory.Items;
        }
    }

    public static class MockPurchaseHistory
    {
        public static List<PurchaseHistoryItem> Items { get; } = new List<PurchaseHistoryItem>();

        // Add a new purchase item to the list
        public static void AddPurchase(PurchaseHistoryItem item)
        {
            Items.Add(item);
        }
    }

    // Purchase History item model
    public class PurchaseHistoryItem
    {
        public string ProductTitle { get; set; }
        public string QRCodeImageBase64 { get; set; } // Base64 encoded string for the QR code image
        public DateTime PurchaseDate { get; set; }
    }
}