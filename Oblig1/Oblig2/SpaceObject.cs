using System;

namespace SpaceSim
{
    public class SpaceObject
    {
        protected string name;
        protected double objectRadius;
        protected string objectColor;

        public SpaceObject(string name, double objectRadius, string objectColor)
        {
            this.name = name;
            this.objectRadius = objectRadius;
            this.objectColor = objectColor;
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double ObjectRadius
        {
            get { return objectRadius; }
            set { objectRadius = value; }
        }

        public string ObjectColor
        {
            get { return objectColor; }
            set { objectColor = value; }
        }
    }

    public class Star : SpaceObject
    {
        public Star(string name, double objectRadius, string objectColor) : base(name, objectRadius, objectColor)
        {
        }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        protected double orbitalRadius; // in kilometers
        protected double orbitalPeriod; // in days
        protected double rotationalPeriod; // in hours

        public Planet(string name, double objectRadius, double rotationalPeriod, string objectColor,
            double orbitalRadius, double orbitalPeriod)
            : base(name, objectRadius, objectColor)
        {
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.rotationalPeriod = rotationalPeriod;
        }

        public override void Draw()
        {
            Console.Write("Planet : ");
            base.Draw();
        }

        public double OrbitalRadius
        {
            get { return orbitalRadius; }
            set { orbitalRadius = value; }
        }

        public double OrbitalPeriod
        {
            get { return orbitalPeriod; }
            set { orbitalPeriod = value; }
        }

        public double RotationalPeriod
        {
            get { return rotationalPeriod; }
            set { rotationalPeriod = value; }
        }
    }

    public class Moon : Planet
    {
        public Moon(string name, double objectRadius, double rotationalPeriod, string objectColor,
            double orbitalRadius, double orbitalPeriod)
            : base(name, objectRadius, rotationalPeriod, objectColor, orbitalRadius, orbitalPeriod)
        {
        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(string name, double objectRadius, double rotationalPeriod, string objectColor,
            double orbitalRadius, double orbitalPeriod)
            : base(name, objectRadius, rotationalPeriod, objectColor, orbitalRadius, orbitalPeriod)
        {
        }

        public override void Draw()
        {
            Console.Write("Dwarf Planet : ");
            base.Draw();
        }
    }
}