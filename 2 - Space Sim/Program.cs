using System;
using System.Collections.Generic;
using System.Linq;
using Space;

class Astronomy {
    public static void Main() {
        List<SpaceObject> a = new List<SpaceObject>
        {
            new Star("Sun",0,0),
            new Planet("Mercury",88,57910),
            new Planet("Venus",225,108200),
            new Planet("terra",365,149600),
            new Moon("The Moon",27,384),
            new Planet("mars",686,227940),
            new Moon("Phobos",1,9),
            new Planet("jupiter",4333,778330),
            new Moon("Metis",1,128),
            new Planet("Saturn",10760,1429400),
            new Moon("Pan", 1,134),
            new Planet("Uranus",30685,2870990),
            new Moon("Cordelia",1,50),
            new DwarfPlanet("Pluto",90550,5913520),
            

        };

        Console.WriteLine("enter day");
        string day;
        //int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Space Planet");
        string nameRead = Console.ReadLine();
        
     
        foreach (var b in a) {
  //        if (a.Contains(nameRead)==true)
//          {

           //   Console.Write(a);
             // break;
           ///}
    //      else
      //    {
                b.Draw();
        //  }
        }
       
    }
}


   