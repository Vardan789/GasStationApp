namespace MauiApp1;

public partial class ProductPurchasePage : ContentPage
{
    private readonly HomePageDataProductDto _product;
    private decimal _liters;

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
            _liters = liters; // Update the _liters field
            var totalPrice = liters * _product.Price;
            TotalPriceLabel.Text = $"Total: {totalPrice:F2}֏";
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

        // Navigate to CardEntryPage
        await Navigation.PushAsync(new CardEntryPage(_product, _liters));
    }

}