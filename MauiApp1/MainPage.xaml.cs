using System.Net.Http.Json;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public MainPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        StationsGridLayout.Span = DeviceInfo.Idiom == DeviceIdiom.Phone ? 2 : 4;
        MainBannerGridLayout.WidthRequest = DeviceInfo.Idiom == DeviceIdiom.Phone ? 380 : 1200;
        MainBannerFontSize.HorizontalOptions = DeviceInfo.Idiom == DeviceIdiom.Phone
            ? LayoutOptions.Start : LayoutOptions.Center;
        MainBannerFontSize.TextColor = Colors.White;
        MainBannerFontSize.FontSize = DeviceInfo.Idiom == DeviceIdiom.Phone ? 24 : 48;
        MainBannerFontLabel.FontSize = DeviceInfo.Idiom == DeviceIdiom.Phone ? 22 : 42;
        MainBannerFontLabel.HorizontalOptions = DeviceInfo.Idiom == DeviceIdiom.Phone 
            ? LayoutOptions.Start
            : LayoutOptions.Center;

        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("version","1");
            client.DefaultRequestHeaders.Add("OsType","2");
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<HomePageDataDto>>("http://localhost:5165/api/v1/Web/Data");

            if (response != null && response.Success)
            {
                BindingContext = response.Data;
            }
            
            else
            {
                await DisplayAlert("Error", "Failed to load data from server.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private async void OnProductTapped(object sender, EventArgs e)
    {
        var tappedProduct = (sender as BindableObject)?.BindingContext as HomePageDataProductDto;

        if (tappedProduct != null)
        {
            await Navigation.PushAsync(new ProductPurchasePage(tappedProduct));
        }
    }
}
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
}
public class HomePageDataDto
{
    public List<HomePageDataProductDto> Products { get; set; }
    public List<HomePageDataStationDto> Stations { get; set; }
}

public class HomePageDataProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}

public class HomePageDataStationDto
{
    public int Id { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
}

