using Microsoft.Maui.Controls.Shapes;
using SpaceSim;

namespace MauiSpaceApp;

public partial class MainPage : ContentPage
{
    private bool isTimerRunning = false;
    private TimeSpan elapsedTime = TimeSpan.Zero;
    List<SpaceObject> solarSystem = SpaceLibrary.SpaceObjectsList.SolarSystem;


    public MainPage()
    {
        InitializeComponent();

        List<Ellipse> ellipses = new List<Ellipse>();

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
            PlanetLayout.Children.Add(ellipse);
        }
    }

    private async void StartTimer(object sender, EventArgs e)
    {
        isTimerRunning = true;
        while (isTimerRunning)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            await Task.Delay(100);
        }
    }

    private void Planet_OnClicked(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string planetName = button.Text;
            ZoomIn(planetName);
        }
    }

    private void ZoomIn(string planetName)
    {
        SpaceObject planet = solarSystem.Find(so => so.Name == planetName);

        ((HorizontalStackLayout)PlanetLayout.Parent).Children.Clear();
        AddSpaceObjectToLayout(planet);

        DisplayPlanetData(planet);
    }

    private void ZoomOut()
    {
        ((HorizontalStackLayout)PlanetLayout.Parent).Children.Clear();
        foreach (SpaceObject planet in solarSystem)
        {
            AddSpaceObjectToLayout(planet);
        }
    }

    private void AddSpaceObjectToLayout(SpaceObject so)
    {
        Ellipse ellipse = new Ellipse
        {
            WidthRequest = so.ObjectRadius,
            HeightRequest = so.ObjectRadius,
            Fill = (Brush)new BrushTypeConverter().ConvertFromString(so.ObjectColor)!,
            Margin = new Thickness(3),
            Stroke = Brush.Black,
        };

        ((HorizontalStackLayout)PlanetLayout.Parent).Children.Add(ellipse);
    }

    private void DisplayPlanetData(SpaceObject planet)
    {
        string planetData = $"Name: {planet.Name}\n" +
                            $"Radius: {planet.ObjectRadius}\n" +
                            $"Color: {planet.ObjectColor}";

        PlanetData.Text = planetData;
        PlanetData.IsVisible = true;
    }

    private bool areLabelsVisible = true;

    private void ToggleLabels()
    {
        areLabelsVisible = !areLabelsVisible;

        foreach (var child in ((HorizontalStackLayout)PlanetLayout.Parent).Children)
        {
            if (child is Label label)
            {
                label.IsVisible = areLabelsVisible;
            }
        }
    }

    private void ToggleLabels(object? sender, CheckedChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ToggleOrbits(object? sender, CheckedChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
}