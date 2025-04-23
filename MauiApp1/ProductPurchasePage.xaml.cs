namespace MauiApp1;

public partial class ProductPurchasePage : ContentPage
{
    private readonly HomePageDataProductDto _product;
    private readonly decimal _liters;

    public ProductPurchasePage(HomePageDataProductDto product)
    {
        InitializeComponent();
        _product = product;
        BindingContext = product;
    }

    private void OnLitersChanged(object sender, TextChangedEventArgs e)
    {
        if (decimal.TryParse(e.NewTextValue, out var liters))
        {
            var totalPrice = liters * _product.Price;
            TotalPriceLabel.Text = $"Total: ${totalPrice:F2}";
        }
        else
        {
            TotalPriceLabel.Text = "";
        }
    }
    
    private async void OnBuyClicked(object sender, EventArgs e)
    {
        if (_liters <= 0)
        {
            await DisplayAlert("Invalid Input", "Please enter a valid amount of liters.", "OK");
            return;
        }

        // Simulate purchase logic here (e.g., API call or local DB update)
        await DisplayAlert("Success", $"You bought {_liters} liters of {_product.Title} for ${_liters * _product.Price:F2}", "OK");
        await Navigation.PopAsync();
    }
}