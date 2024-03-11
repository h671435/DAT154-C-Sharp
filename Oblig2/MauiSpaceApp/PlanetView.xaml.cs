using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;
using SpaceSim;

namespace MauiSpaceApp;

public partial class PlanetView : ContentView
{
    public PlanetView(string planetName)
    {
        InitializeComponent();

        SpaceObject planet = SpaceLibrary.SpaceObjectsList.SolarSystem.FirstOrDefault(so => so.Name == planetName);
        
        Ellipse ellipse = new Ellipse
        {
            WidthRequest = planet.ObjectRadius,
            HeightRequest = planet.ObjectRadius,
            Fill = (Brush)new BrushTypeConverter().ConvertFromString(planet.ObjectColor)!,
            Margin = new Thickness(3),
            Stroke = Brush.Black,
        };
        
        Label planetLabel = new Label
        {
            Text = $"{planet.Name}\nRadius: {planet.ObjectRadius} km",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        
        ((StackLayout)Planet.Parent).Children.Add(ellipse);
        ((StackLayout)Planet.Parent).Children.Add(planetLabel);

    }
}