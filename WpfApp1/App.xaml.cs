﻿
/*
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Space;
//using SpaceSim;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public int proportionsystem(int x)
        public int proportionsystem(SpaceObject spaceObject)
        {
            int x = spaceObject.distance / 10000;

            return x;
        }
        //public int orbitalring(int y)
        public int orbitalring(SpaceObject spaceObject)
        {
            var y = (int)(2 * (spaceObject.radius * Math.PI));

            return y;
        }


    }
  


/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Space;
//using SpaceSim;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public int proportionsystem(int x)
        public int proportionsystem(SpaceObject spaceObject )
        {
            int x = spaceObject.distance / 1000;
            
            return x;
        }
        //public int orbitalring(int y)
        public  int orbitalring( SpaceObject spaceObject)
        {
           var y = (int)(2 * (spaceObject.distance * Math.PI));

            return y;
        }


    }
}
*/

using System;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.Run(new MainWindow());
        }
    }
}
