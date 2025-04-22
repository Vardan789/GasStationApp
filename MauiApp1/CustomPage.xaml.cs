using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class CustomPage : ContentPage
{
    public CustomPage()
    {
        var sidebar = new StackLayout
        {
            WidthRequest = 100,
            BackgroundColor = Colors.Gray,
            Padding = 10,
            Children =
            {
                new Label {Text = "Menu", FontAttributes = FontAttributes.Bold},
                new Button {Text = "Home"},
                new Button {Text = "About"},
                new Button {Text = "Contact"}
            }
        };

        var banner = new Image
        {
            Source = "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4=", // Replace with your actual banner image file
            HeightRequest = 200,
            Aspect = Aspect.AspectFill
        };

        var productLayer = new StackLayout
        {
            Padding = 20,
            BackgroundColor = Colors.LightGray,
            Children =
            {
                new Label {Text = "Product Name", FontSize = 24, FontAttributes = FontAttributes.Bold},
                new Label {Text = "$99.99", FontSize = 20, TextColor = Colors.Green},
                new Button {Text = "Buy Now", BackgroundColor = Colors.Blue, TextColor = Colors.White}
            }
        };

        var stationsSection = new StackLayout
        {
            Padding = 20,
            Children =
            {
                new Label {Text = "Our Stations", FontSize = 24, FontAttributes = FontAttributes.Bold},
                new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new Image {Source = "https://media.istockphoto.com/id/154226161/photo/gas-station.jpg?s=612x612&w=0&k=20&c=RZiuXIakFwZlRFU6WRpQ81SDrCFfue958aAJr1EL7I4=", WidthRequest = 100, HeightRequest = 100},
                        new StackLayout
                        {
                            Children =
                            {
                                new Label {Text = "Station One"},
                                new Label {Text = "123 Main St"}
                            }
                        }
                    }
                }
            }
        };

        var mainContent = new StackLayout
        {
            Children = {banner, productLayer, stationsSection}
        };

        var layout = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition {Width = new GridLength(100)},
                new ColumnDefinition {Width = GridLength.Star}
            }
        };

        layout.Add(sidebar, 0, 0);
        layout.Add(new ScrollView {Content = mainContent}, 1, 0);

        Content = layout;
    }
}