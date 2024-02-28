using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>
        {
            new Star("Sun", 100, "Yellow"),
            new Planet("Mercury", 10, 58, "Gray", 57910, 88),
            new Planet("Venus", 30, 243, "Yellow", 108200, 225),
            new Planet("Terra", 20, 24, "Blue", 149600, 365),
            new Moon("The Moon", 4, 27, "Gray", 384, 27),
            new DwarfPlanet("Pluto", 3, 150, "Brown", 5906000, 9052),
        };

        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }

        Console.ReadLine();
    }
}