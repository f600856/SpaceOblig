
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using SpaceSim;
using System.Drawing;
using System.Net.Security;
using System.Windows.Automation;
using System.Numerics;
using col = System.Windows.Media.Color;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double YCenter = 0;
        double XCenter = 0;
        bool zoom = false;
        double zoomView = 1;
        double xZoom = 0;
        double yZoom = 0;
        double vinkel = 0;

        List<SpaceObject> solarSystem = new List<SpaceObject>
            {
                new Star("Sun", 0, 695000, "Yellow", 1),
                new Planet("Mercury", 57910, 2440, "Blue", 88),
                new Planet("Venus", 108200, 6052, "Tan", 225),
                new Planet("Terra", 149600, 6368, "Purple", 365),
               
                //new Moon("The Moon", 384, 1738, "Grey", 27),
                new Planet("Mars", 227940, 3390, "Red", 687),
                new Planet("Jupiter", 778330, 69173, "Pink", 4333),
                new Planet("Saturn", 1429400, 57316, "Tan", 10760),
                new Planet("Uranus", 2870990, 25266, "Teal", 30685),
                new Planet("Neptune", 4504300, 24553, "Blue", 60190),
                new DwarfPlanet("Pluto", 5913520, 1184, "Tan", 90550)
            };

         public MainWindow()
         {
             InitializeComponent();
             Planet earth = (Planet)solarSystem[3];
             solarSystem.Add(new Moon("The Moon", 384, 1738, "Gray", 27, earth));
             Planet mars = (Planet)solarSystem[4];
             solarSystem.Add(new Moon("Phobos", 23, 11, "Red", 1, mars));
             solarSystem.Add(new Moon("Deimos", 9, 6, "Gray", 2, mars));
             Planet jupiter = (Planet)solarSystem[5];
             solarSystem.Add(new Moon("Ananke", 21200, 15, "Pink", -631, jupiter));

             System.Timers.Timer timer = new System.Timers.Timer(40);
             timer.Elapsed += Timer_Elapsed; //timer.Elapsed er et event, og med += subscriber Time_Elapsed til det eventet.
             timer.Start();

             XCenter = DisplayCanvas.ActualWidth / 2;
             YCenter = DisplayCanvas.ActualHeight / 2;
         }
        
        
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(new Action(() => { DrawPlanets(); }));
                vinkel += 0.5 / 360.0;
            }
            catch
            {


            }
        }

            private void DrawOrbit(double centerX, double centerY, double orbitRadiusX, double orbitRadiusY)
            {
                Ellipse orbitEllipse = new Ellipse
                {
                    Width = orbitRadiusX * 2,
                    Height = orbitRadiusY * 2,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 1,
                };

                DisplayCanvas.Children.Add(orbitEllipse);
                Canvas.SetLeft(orbitEllipse, centerX - orbitRadiusX);
                Canvas.SetTop(orbitEllipse, centerY - orbitRadiusY);
            }

        private void DrawOrbitalRing(double centerX, double centerY, double orbitRadiusX, double orbitRadiusY)
        {
            Ellipse orbitEllipse = new Ellipse
            {
                Width = orbitRadiusX * 2,
                Height = orbitRadiusY * 2,
                Stroke = Brushes.LightGray,
                StrokeThickness = 1,
            };

            DisplayCanvas.Children.Add(orbitEllipse);
            Canvas.SetLeft(orbitEllipse, centerX - orbitRadiusX);
            Canvas.SetTop(orbitEllipse, centerY - orbitRadiusY);
        }

      


        private void DrawPlanets()
        {
            DisplayCanvas.Children.Clear();
            double canvasCenterX = DisplayCanvas.ActualWidth / 2;
            double canvasCenterY = DisplayCanvas.ActualHeight / 2;

            foreach (SpaceObject spaceObject in solarSystem)
            {
                double Xpos;
                double Ypos;
                if (spaceObject.GetType() == typeof(Moon))
                {
                    Moon luna = (Moon)spaceObject;
                    double XoffsetPos = luna.getOrbits().XPos(vinkel, XCenter) + luna.getOrbits().getRadius() / 2;
                    double YoffsetPos = luna.getOrbits().YPos(vinkel, YCenter) + luna.getOrbits().getRadius() / 2;
                    Xpos = luna.XPos(vinkel, XoffsetPos);
                    Ypos = luna.YPos(vinkel, YoffsetPos);
                }
                else
                {
                    Xpos = spaceObject.XPos(vinkel, XCenter);
                    Ypos = spaceObject.YPos(vinkel, YCenter);
                }
                Xpos *= zoomView;
                Ypos *= zoomView;

                // Add canvas center coordinates to the calculated positions
                Xpos += canvasCenterX;
                Ypos += canvasCenterY;

                drawObject(spaceObject, Xpos, Ypos);
            }
        }
        


        private void drawObject(SpaceObject spaceobject, double x, double y)
        {
            Ellipse ellipse = DrawEllipse(spaceobject.getRadius(), spaceobject.getRadius(), spaceobject.getColor());
            DisplayCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
        }
        public Ellipse DrawEllipse(double height, double width, String colorName)
        {
            col color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorName);
            SolidColorBrush fillBrush = new SolidColorBrush() { Color = color };
            Ellipse el = new Ellipse()
            {
                Height = height,
                Width = width,
                Fill = fillBrush
            };
            return el;
        }
        private void Mouse_click(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                zoom = true;
                zoomView *= 1.5;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                if (zoom) zoomView /= 1.5;
                zoom = false;
            }
            System.Windows.Point mousePointer = e.GetPosition(DisplayCanvas);
            xZoom = mousePointer.X;
            yZoom = mousePointer.Y;
        }
        private void Window_SizeChanged(object sender, EventArgs e)
        {
            YCenter = DisplayCanvas.ActualHeight / 2;
            XCenter = DisplayCanvas.ActualWidth / 2;
        }
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            //Canvas.InvalidateVisual();  
        }
    }
}




