namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        
        var mockData = new HomePageDataDto
        {
            Products = new List<HomePageDataProductDto>
            {
                new() {Id = 1, Title = "Premium Fuel", Price = 3.99m},
                new() {Id = 2, Title = "Regular Fuel", Price = 2.89m},
                new() {Id = 3, Title = "Snacks", Price = 1.49m},
                new() {Id = 4, Title = "Drinks", Price = 0.99m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
                new() {Id = 5, Title = "Car Wash", Price = 5.00m},
            },
            Stations = new List<HomePageDataStationDto>
            {
                new()
                {
                    Id = 1,
                    Title = "Shell Station",
                    Address = "123 Main St, LA",
                    Lat = 34.0522,
                    Lng = -118.2437,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                },
                new()
                {
                    Id = 2,
                    Title = "Chevron Station",
                    Address = "456 Sunset Blvd, LA",
                    Lat = 34.0900,
                    Lng = -118.3617,
                    Image =
                        "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4="
                }
            }
        };
        InitializeComponent();
        BindingContext = mockData;
    }
   
    private async void OnProductTapped(object sender, EventArgs e)
    {
        var tappedProduct = (sender as BindableObject)?.BindingContext as HomePageDataProductDto;

        if (tappedProduct != null)
        {
            await Navigation.PushAsync(new ProductPurchasePage(tappedProduct));
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        StationsGridLayout.Span = DeviceInfo.Idiom == DeviceIdiom.Phone ? 2 : 4;
        MainBannerGridLayout.WidthRequest = DeviceInfo.Idiom == DeviceIdiom.Phone ? 350 : 1200;
    }
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