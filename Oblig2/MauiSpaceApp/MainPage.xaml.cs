using Microsoft.Maui.Controls.Shapes;
using SpaceSim;

namespace MauiSpaceApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        List<SpaceObject> solarSystem = SpaceLibrary.SpaceObjectsList.SolarSystem;
        List<Ellipse> ellipses = new List<Ellipse>();
        int 

        foreach (SpaceObject so in solarSystem)
        {
            Ellipse ellipse = new Ellipse
            {
                WidthRequest = so.ObjectRadius,
                HeightRequest = so.ObjectRadius,
                Fill = (Brush)new BrushTypeConverter().ConvertFromString(so.ObjectColor)!,
                Margin = new Thickness(3),
                Stroke = Brush.Black,
            };

            ellipses.Add(ellipse);
            ((Grid)SpaceImage.Parent).Children.Add(ellipse);
        }
    }


    private void Planet_OnClicked(object? sender, EventArgs e)
    {
    }
}