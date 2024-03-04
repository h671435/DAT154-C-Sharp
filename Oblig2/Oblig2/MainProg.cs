using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy
{
    public static void Main()
    {
        Console.WriteLine("Write number of days since time 0");
        double time = double.Parse(Console.ReadLine());
        Console.WriteLine("Write the name of a planet (or none if you want all)");
        string planet1Name = Console.ReadLine();

        List<SpaceObject> solarSystem = new List<SpaceObject>
        {
            new Star("Sun", 100, "Yellow"),
            new Planet("Mercury", 10, 58, "Gray", 57910, 88),
            new Planet("Venus", 30, 243, "Yellow", 108200, 225),
            new Planet("Terra", 20, 24, "Blue", 149600, 365),
            new Moon("The Moon", 4, 27, "Gray", 384, 27),
            new DwarfPlanet("Pluto", 3, 150, "Brown", 5906000, 9052),
        };
        
        SpaceObject planet1 = null;
        if (!string.IsNullOrEmpty(planet1Name))
        {
            planet1 = solarSystem.FirstOrDefault(p => p.Name.ToLower() == planet1Name.ToLower());
        }

        if (planet1 == null)
        {
            AllPlanets(solarSystem, time);
        }
        else
        {
            OnePlanet(planet1, time);
        }

        Console.ReadLine();
    }

    private static void OnePlanet(SpaceObject planet, double time)
    {
        if (planet is Planet planet4)
        {
            var position = planet4.GetPositionAtTime(time);
            Console.WriteLine($"{planet.Name} position at time {time}: (X: {position.X}, Y: {position.Y}");
        } else if (planet is Moon moon)
        {
            var position = moon.GetPositionAtTime(time);
            Console.WriteLine($"{moon.Name} position at time {time}: (X: {position.X}, Y: {position.Y}");
        }
    }
    
    private static void AllPlanets(List<SpaceObject> list, double time)
    {
        foreach (SpaceObject spaceObj in list)
        {
            if (spaceObj is Planet planet2)
            {
                var position = planet2.GetPositionAtTime(time);
                Console.WriteLine($"{spaceObj.Name} position at time {time}: (X: {position.X}, Y: {position.Y}");
            }
            else if (spaceObj is Moon moon)
            {
                var planet3 = (Planet)list.Find(p => p.Name == "Terra");
                var planetPosition = planet3.GetPositionAtTime(time);
                var position = moon.GetPositionAtTime(time, planetPosition);
                Console.WriteLine($"{spaceObj.Name} position at time {time}: (X: {position.X}, Y: {position.Y})");
            }
            else
            {
                spaceObj.Draw();
            }
        }
    }
}