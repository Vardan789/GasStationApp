namespace MauiApp1;

public partial class QrPage : ContentPage
{
    public QrPage()
    {
        InitializeComponent();
    }
    
    private async void OnDoneClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync(); // Or navigate somewhere else as needed
    }
}