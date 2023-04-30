
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Timers;
using SpaceSimulation;
using col = System.Windows.Media.Color;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        double YCenter = 0;
        double XCenter = 0;
        bool zoom = false;
        double zoomView = 1;
        double xZoom = 0;
        double yZoom = 0;
        double vinkel = 0;

        List<CelestialBody> solarSystem = new List<CelestialBody>
        {
            new Star(new CelestialBodyParameters { Title = "Sun", Orbit = 0, Dimensions = 695000, Appearance = "Yellow", Spin = 1 }),
            new Planet(new CelestialBodyParameters { Title = "Mercury", Orbit = 57910, Dimensions = 2440, Appearance = "Blue", Spin = 88 }),
            new Planet(new CelestialBodyParameters { Title = "Venus", Orbit = 108200, Dimensions = 6052, Appearance = "Tan", Spin = 225 }),
            new Planet(new CelestialBodyParameters { Title = "Earth", Orbit = 149600, Dimensions = 6368, Appearance = "Purple", Spin = 365 }),
            new Planet(new CelestialBodyParameters { Title = "Mars", Orbit = 227940, Dimensions = 3390, Appearance = "Red", Spin = 687 }),
            new Planet(new CelestialBodyParameters { Title = "Jupiter", Orbit = 778330, Dimensions = 69173, Appearance = "Pink", Spin = 4333 }),
            new Planet(new CelestialBodyParameters { Title = "Saturn", Orbit = 1429400, Dimensions = 57316, Appearance = "Tan", Spin = 10760 }),
            new Planet(new CelestialBodyParameters { Title = "Uranus", Orbit = 2870990, Dimensions = 25266, Appearance = "Teal", Spin = 30685 }),
            new Planet(new CelestialBodyParameters { Title = "Neptune", Orbit = 4504300, Dimensions = 24553, Appearance = "Blue", Spin = 60190 }),
            new DwarfPlanet(new CelestialBodyParameters { Title = "Pluto", Orbit = 5913520, Dimensions = 1184, Appearance = "Tan", Spin = 90550 })
        };


        public MainWindow()
         {
            InitializeComponent();
            Planet earth = (Planet)solarSystem[3];
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "The Moon", Orbit = 384, Dimensions = 1738, Appearance = "Gray", Spin = 27}, earth));
            Planet mars = (Planet)solarSystem[4];
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Phobos", Orbit = 23, Dimensions = 11, Appearance = "Red", Spin = 1 }, mars));
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Deimos", Orbit = 9, Dimensions = 6, Appearance = "Gray", Spin = 2 }, mars));
            Planet jupiter = (Planet)solarSystem[5];
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Ananke", Orbit = 21200, Dimensions = 15, Appearance = "Pink", Spin = -631 }, jupiter));


            System.Timers.Timer timer = new System.Timers.Timer(40);
             timer.Elapsed += Timer_Elapsed;
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

            foreach (CelestialBody spaceObject in solarSystem)
            {
                double Xpos;
                double Ypos;
                if (spaceObject.GetType() == typeof(Moon))
                {
                    Moon luna = (Moon)spaceObject;
                    double XoffsetPos = luna.GetOrbiting().GetXPos(vinkel, XCenter) + luna.GetOrbiting().ObtainRadius() / 2;
                    double YoffsetPos = luna.GetOrbiting().GetYPos(vinkel, YCenter) + luna.GetOrbiting().ObtainRadius() / 2;
                    Xpos = luna.GetXPos(vinkel, XoffsetPos);
                    Ypos = luna.GetYPos(vinkel, YoffsetPos);
                }
                else
                {
                    Xpos = spaceObject.GetXPos(vinkel, XCenter);
                    Ypos = spaceObject.GetYPos(vinkel, YCenter);
                }
                Xpos *= zoomView;
                Ypos *= zoomView;

                // Add canvas center coordinates to the calculated positions
                Xpos += canvasCenterX;
                Ypos += canvasCenterY;

                drawObject(spaceObject, Xpos, Ypos);
            }
        }
        


        private void drawObject(CelestialBody spaceobject, double x, double y)
        {
            Ellipse ellipse = DrawEllipse(spaceobject.ObtainRadius(), spaceobject.ObtainRadius(), spaceobject.GetColor());
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




