using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1;

public partial class ProductListPage : ContentPage
{
    public ProductListPage()
    {
        InitializeComponent();
        BindingContext = new ProductListViewModel();
    }

    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Product selected)
        {
            await DisplayAlert("Product Selected",
                $"You selected: {selected.title}\nPrice: {selected.price:C}\nVariation: {selected.variation}",
                "OK");

            // Optional: deselect item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
public class Product
{
    public int id { get; set; }
    public string title { get; set; }
    public decimal price { get; set; }
    public int variation { get; set; }
}

public class ProductListViewModel
{
    public ObservableCollection<Product> Products { get; set; } = new()
    {
        new Product { id = 0, title = "Sample Product", price = 19.99m, variation = 1 },
        new Product { id = 0, title = "Sample Product", price = 19.99m, variation = 1 },
        new Product { id = 0, title = "Sample Product", price = 19.99m, variation = 1 },
        new Product { id = 0, title = "Sample Product", price = 19.99m, variation = 1 },
    };
}
