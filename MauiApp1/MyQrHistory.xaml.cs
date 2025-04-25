namespace MauiApp1
{
    public partial class MyQrHistory : ContentPage
    {
        public MyQrHistory()
        {
            InitializeComponent();

            // Binding the purchase history to the CollectionView
            QRListView.ItemsSource = MockPurchaseHistory.Items;
        }
    }

    public static class MockPurchaseHistory
    {
        public static List<PurchaseHistoryItem> Items { get; } = new List<PurchaseHistoryItem>();

        // Add a new purchase item to the list
        public static void AddPurchase(PurchaseHistoryItem item)
        {
            // Convert the file path to ImageSource
            if (!string.IsNullOrEmpty(item.QRCodeImageFilePath))
            {
                item.QRCodeImageSource = ImageSource.FromFile(item.QRCodeImageFilePath);
            }
            Items.Add(item);
        }
    }

    // Purchase History item model
    public class PurchaseHistoryItem
    {
        public string ProductTitle { get; set; }
        public string QRCodeImageFilePath { get; set; } // Store file path instead of Base64
        public ImageSource QRCodeImageSource { get; set; } // This will hold the ImageSource
        public DateTime PurchaseDate { get; set; }
    }

}