using System;
using Drawing = System.Drawing;
using Certificates = System.Security.Cryptography.X509Certificates;

namespace SpaceSimulation
{

    public class CelestialBodyParameters
    {
        public string Title { get; set; }
        public int Orbit { get; set; }
        public int Dimensions { get; set; }
        public string Appearance { get; set; }
        public int Spin { get; set; }
    }

    public class CelestialBody
    {
        protected String EntityName { get; set; }
        protected int OrbitRadius { get; set; }
        protected int BodySize { get; set; }
        protected String BodyColor { get; set; }
        protected int SpinPeriod { get; set; }
        protected double CoordX { get; set; }
        protected double CoordY { get; set; }

        public CelestialBody(CelestialBodyParameters parameters)
        {
            this.EntityName = parameters.Title;
            this.OrbitRadius = parameters.Orbit;
            this.BodySize = parameters.Dimensions;
            this.BodyColor = parameters.Appearance;
            this.SpinPeriod = parameters.Spin;
        }
        public String RetrieveName()
        {
            return EntityName;
        }
        public int FetchOrbit()
        {
            if (OrbitRadius > 800000) return OrbitRadius / 7500;
            if (OrbitRadius > 500000) return OrbitRadius / 6000;
            if (OrbitRadius < 500 && OrbitRadius > 1) return 10;
            return OrbitRadius / 2000;
        }
        public double ObtainRadius()
        {
            if (BodySize > 100000) return BodySize / 25000;
            if (BodySize > 10000) return BodySize / 4500;
            if (BodySize < 50) return BodySize / 3;
            return BodySize / 500;
        }
        public int AcquirePeriod()
        {
            return SpinPeriod;
        }
        public virtual void Show()
        {
            Console.WriteLine(EntityName);
        }

        public double GetXPos()
        {
            return CoordX;
        }
        public double GetXPos(double tick, double centerX)
        {
            if (FetchOrbit() == 0)
            {
                CoordX = centerX;
            }
            else
            {
                CoordX = centerX + FetchOrbit() * Math.Cos(tick * 1000 / SpinPeriod);
            }
            return CoordX;
        }

        public double GetYPos(double tick, double centerY)
        {
            if (FetchOrbit() == 0)
            {
                CoordY = centerY;
            }
            else
            {
                CoordY = centerY + FetchOrbit() * Math.Sin(tick * 1000 / SpinPeriod);
            }
            return CoordY;
        }

        public double GetYPos()
        {
            return CoordY;
        }

        public String GetColor()
        {
            return BodyColor;
        }
    }

    public class Star : CelestialBody
    {
        public Star(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Star: ");
            base.Show();
        }
    }

    public class Planet : CelestialBody
    {
        public Moon[] moons { get; set; }
        public Planet(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Planet: ");
            base.Show();
        }
    }

    public class Moon : Planet
    {
        protected CelestialBody Orbiting { get; set; }
        public Moon(CelestialBodyParameters parameters, CelestialBody orbit) : base(parameters) {
            this.Orbiting = orbit;
        }
        public override void Show()
        {
            Console.Write("Moon: ");
            base.Show();
        }
        public CelestialBody GetOrbiting()
        {
            return Orbiting;
        }
    }

    public class Astroid : CelestialBody
    {
        public Astroid(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Astroid: ");
            base.Show();
        }
    }

    public class AstroidBelt : CelestialBody
    {
        public AstroidBelt(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Astroid belt: ");
            base.Show();
        }
    }

    public class DwarfPlanet : CelestialBody
    {
        public DwarfPlanet(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Dwarf Planet: ");
            base.Show();
        }
    }

    public class Comet : CelestialBody
    {
        public Comet(CelestialBodyParameters parameters) : base(parameters) { }
        public override void Show()
        {
            Console.Write("Comet: ");
            base.Show();
        }
    }
}

