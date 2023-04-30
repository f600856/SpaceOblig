
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using col = System.Drawing.Color;

namespace SpaceSim
{
    public class SpaceObject
    {
        protected String Name { get; set; }
        protected int OrbitalRadius { get; set; }
        protected int Size { get; set; }
        protected String ObjectColor { get; set; }
        protected int RotationalPeriod { get; set; }
        protected double Xpos { get; set; }
        protected double Ypos { get; set; }
       

        public SpaceObject(String name, int orbitalRadius, int size, String color, int rotationalPeriod)
        {
            this.Name = name;
            this.OrbitalRadius = orbitalRadius;
            this.Size = size;
            this.ObjectColor = color;
            this.RotationalPeriod = rotationalPeriod;
        }
        public String getName()
        {
            return Name;
        }
        public int getOrbit()
        {
            if (OrbitalRadius > 800000) return OrbitalRadius / 7500;
            if (OrbitalRadius > 500000) return OrbitalRadius / 6000;
            if (OrbitalRadius < 500 && OrbitalRadius > 1) return 10;
            return OrbitalRadius / 2000;
        }
        public double getRadius()
        {
            if (Size > 100000) return Size / 25000;
            if (Size > 10000) return Size / 4500;
            if (Size < 50) return Size / 3;
            return Size / 500;
        }
        public int getPeriod()
        {
            return RotationalPeriod;
        }
        public virtual void Draw()
        {
            Console.WriteLine(Name);
        }
        //public double XPos(double timeTick, double offset)
        //{
        //    Xpos = offset - (getRadius() / 2) + getOrbit() * Math.Cos(timeTick * 1000 / RotationalPeriod);
        //    return Xpos;
        //}
        public double XPos()
        {
            return Xpos;
        }
        public double XPos(double timeTick, double centerX)
        {
            if (getOrbit() == 0) // If the space object is the Sun
            {
                Xpos = centerX - (getRadius() / 2);
            }
            else
            {
                Xpos = centerX - (getRadius() / 2) + getOrbit() * Math.Cos(timeTick * 1000 / RotationalPeriod);
            }
            return Xpos;
        }

        public double YPos(double timeTick, double centerY)
        {
            if (getOrbit() == 0) // If the space object is the Sun
            {
                Ypos = centerY - (getRadius() / 2);
            }
            else
            {
                Ypos = centerY - (getRadius() / 2) + getOrbit() * Math.Sin(timeTick * 1000 / RotationalPeriod);
            }
            return Ypos;
        }
        public double YPos()
        {
            return Ypos;
        }


        /*public double XPos()
        {
            return Xpos;
        }
        public double YPos(double timeTick, double offset)
        {

            Ypos = offset - (getRadius() / 2) + getOrbit() * Math.Sin(timeTick * 1000 / RotationalPeriod);
            return Ypos;
        }
        public double YPos()
        {
            return Ypos;
        }*/
        public String getColor()
        {
            return ObjectColor;
        }

    }

    public class Star : SpaceObject
    {
        public Star(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Moon[] moons { get; set; }
        public Planet(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : Planet
    {
        protected SpaceObject Orbits { get; set; }
        public Moon(String name, int orbitalRadius, int size, String color, int rotationalPeriod, SpaceObject orbits) : base(name, orbitalRadius, size, color, rotationalPeriod)
        {
            this.Orbits = orbits;
        }
        public override void Draw()
        {
            Console.Write("Moon: ");
            base.Draw();
        }
        public SpaceObject getOrbits()
        {
            return Orbits;
        }
    }

    public class Astroid : SpaceObject
    {
        public Astroid(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Astroid: ");
            base.Draw();
        }
    }

    public class AstroidBelt : SpaceObject
    {
        public AstroidBelt(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Astroid belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Dwarf Planet: ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String name, int orbitalRadius, int size, String color, int rotationalPeriod) : base(name, orbitalRadius, size, color, rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }

}



