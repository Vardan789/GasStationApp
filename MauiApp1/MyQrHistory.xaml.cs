using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp1;

public partial class MyQrHistory : ContentPage
{
    public MyQrHistory()
    {
        InitializeComponent();
        QRListView.ItemsSource = MockPurchaseHistory.GroupedItems;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MockPurchaseHistory.LoadPurchases();
        QRListView.ItemsSource = MockPurchaseHistory.GroupedItems;
    }
}

public static class MockPurchaseHistory
{
    public static ObservableCollection<PurchaseHistoryItem> Items { get; private set; } = new ObservableCollection<PurchaseHistoryItem>();
    public static ObservableCollection<PurchaseHistoryGroup> GroupedItems { get; private set; } = new ObservableCollection<PurchaseHistoryGroup>();

    private static readonly string SaveFilePath = Path.Combine(FileSystem.AppDataDirectory, "purchase_history.json");

    static MockPurchaseHistory()
    {
        LoadPurchases();
    }

    public static void AddPurchase(PurchaseHistoryItem item)
    {
        if (!string.IsNullOrEmpty(item.QRCodeImageFilePath))
        {
            item.QRCodeImageSource = ImageSource.FromFile(item.QRCodeImageFilePath);
        }
        Items.Add(item);
        SavePurchases();
        GroupPurchases(); // regroup after adding
    }

    public static void SavePurchases()
    {
        var json = JsonSerializer.Serialize(Items.ToList());
        File.WriteAllText(SaveFilePath, json);
    }

    public static void LoadPurchases()
    {
        if (File.Exists(SaveFilePath))
        {
            var json = File.ReadAllText(SaveFilePath);
            var loadedItems = JsonSerializer.Deserialize<List<PurchaseHistoryItem>>(json) ?? new List<PurchaseHistoryItem>();

            Items.Clear();
            foreach (var item in loadedItems)
            {
                if (!string.IsNullOrEmpty(item.QRCodeImageFilePath))
                {
                    item.QRCodeImageSource = ImageSource.FromFile(item.QRCodeImageFilePath);
                }
                Items.Add(item);
            }
            GroupPurchases();
        }
    }
        
    private static void GroupPurchases()
    {
        MainThread.BeginInvokeOnMainThread(() =>  // make sure UI update is on main thread
        {
            GroupedItems.Clear();

            for (int i = 0; i < Items.Count; i += 2)
            {
                var group = new PurchaseHistoryGroup
                {
                    LeftItem = Items[i],
                    RightItem = (i + 1 < Items.Count) ? Items[i + 1] : null
                };
                GroupedItems.Add(group);
            }
        });
    }

}

public class PurchaseHistoryGroup
{
    public PurchaseHistoryItem LeftItem { get; set; }
    public PurchaseHistoryItem RightItem { get; set; }
}

public class PurchaseHistoryItem
{
    public string ProductTitle { get; set; }
    public string QRCodeImageFilePath { get; set; }

    [JsonIgnore]
    public ImageSource QRCodeImageSource { get; set; }

    public DateTime PurchaseDate { get; set; }
}