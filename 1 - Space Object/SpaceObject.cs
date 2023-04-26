using System;
using System.Collections.Generic;

namespace Space  {
    public class SpaceObject {

        public String name;
        public int period;
        public int distance;
        public double velocity ;

        public SpaceObject(String name, int period,int distance) {
            this.name = name;
            this.period = period;
            this.distance = distance;
        }
        public virtual void Draw() {
            Console.WriteLine(name,distance,period);
        }

       

    }

    public class Star : SpaceObject {

        public String name { get; set; }
        public int period { get; set; }

        public int distance { get; set; }



        public Star(String name, int period, int distance) : base(name,period,distance) { }

    

    
         
       
        public override void Draw() {
            velocity = distance * 2 * Math.PI / period;
            Console.Write("Star  : " + name + "  period: " + period + " distance: " + distance + " km  velocity: " + velocity + " of the ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject {

        public String name { get; set; }
        public int period { get; set; }

        public int distance { get; set; }


        public Planet(String name, int period, int distance) : base(name,period,distance) { }

        public override void Draw() {
            velocity = distance * 2 * Math.PI / period;
            Console.Write("Planet: " + name + "  period: " + period + " distance: " + distance + " km  velocity: " + velocity + " of the ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject {

        public String name { get; set; }
        public int period { get; set; }

        public int distance { get; set; }


        public Moon(String name, int period, int distance) : base(name,period,distance) { }

        public override void Draw() {
            velocity = distance * 2 * Math.PI / period;
            Console.Write("Moon  : " + name + "  period: " + period + " distance: " + distance + " km  velocity: " + velocity + " of the ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject { 

             public String name { get; set; }
             public int period { get; set; }

             public int distance { get; set; }
        public DwarfPlanet(String name, int period, int distance) : base(name, period, distance) { }

        public int position(int position)
        {
            
            return position;
        }

        public override void Draw()
        {
            velocity = distance * 2 * Math.PI / period;
            Console.Write("DwarfPlanet  : " + name + "  period: " + period + " distance: " + distance + " km  velocity: " + velocity + " of the ");
            base.Draw();
        }
    }
}

        
       