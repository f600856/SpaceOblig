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
        double centerY = 0;
        double centerX = 0;
        bool magnify = false;
        double magnification = 1;
        double xMagnify = 0;
        double yMagnify = 0;
        double angle = 0;

        // Initialize solar system with celestial bodies
        List<CelestialBody> solarSystem = new List<CelestialBody>
        {
            new Star(new CelestialBodyParameters { Title = "Sun", Orbit = 0, Dimensions = 695000, Appearance = "Yellow", Spin = 1 }),
            new Planet(new CelestialBodyParameters { Title = "Mercury", Orbit = 57910, Dimensions = 2440, Appearance = "Gray", Spin = 88 }),
            new Planet(new CelestialBodyParameters { Title = "Venus", Orbit = 108200, Dimensions = 6052, Appearance = "Tan", Spin = 225 }),
            new Planet(new CelestialBodyParameters { Title = "Earth", Orbit = 149600, Dimensions = 6368, Appearance = "Blue", Spin = 365 }),
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
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "The Moon", Orbit = 384, Dimensions = 1738, Appearance = "Gray", Spin = 27 }, earth));
            Planet mars = (Planet)solarSystem[4];
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Phobos", Orbit = 23, Dimensions = 11, Appearance = "Red", Spin = 1 }, mars));
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Deimos", Orbit = 9, Dimensions = 6, Appearance = "Gray", Spin = 2 }, mars));
            Planet jupiter = (Planet)solarSystem[5];
            solarSystem.Add(new Moon(new CelestialBodyParameters { Title = "Ananke", Orbit = 21200, Dimensions = 15, Appearance = "Pink", Spin = -631 }, jupiter));


            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Start();


            centerX = DisplayCanvas.ActualWidth / 2;
            centerY = DisplayCanvas.ActualHeight / 2;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angle += 0.5 / 360.0;
            RenderCelestialBodies();
        }


        // Timer elapsed event to update the solar system display
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(new Action(() => { RenderCelestialBodies(); }));
                angle += 0.5 / 360.0;
            }
            catch
            {
            }
        }

        // Render an orbit ellipse for a celestial body
        private void RenderOrbit(double centerX, double centerY, double orbitRadiusX, double orbitRadiusY)
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

        // Render all celestial bodies and their orbits in the solar system
        private void RenderCelestialBodies()
        {
            DisplayCanvas.Children.Clear();
            double canvasCenterX = DisplayCanvas.ActualWidth / 2;
            double canvasCenterY = DisplayCanvas.ActualHeight / 2;

            foreach (CelestialBody spaceObject in solarSystem)
            {
                double xPos;
                double yPos;
                if (spaceObject.GetType() == typeof(Moon))
                {
                    Moon moon = (Moon)spaceObject;
                    double xOffsetPos = moon.GetOrbiting().GetXPos(angle, centerX) + moon.GetOrbiting().ObtainRadius() / 2;
                    double yOffsetPos = moon.GetOrbiting().GetYPos(angle, centerY) + moon.GetOrbiting().ObtainRadius() / 2;
                    xPos = moon.GetXPos(angle, xOffsetPos);
                    yPos = moon.GetYPos(angle, yOffsetPos);
                }
                else
                {
                    xPos = spaceObject.GetXPos(angle, centerX);
                    yPos = spaceObject.GetYPos(angle, centerY);
                }
                xPos *= magnification;
                yPos *= magnification;

                // Add canvas center coordinates to the calculated positions
                xPos += canvasCenterX;
                yPos += canvasCenterY;

                RenderObject(spaceObject, xPos, yPos, canvasCenterX, canvasCenterY);
            }

        }

        // Render a celestial object on the canvas
        private void RenderObject(CelestialBody spaceObject, double x, double y, double canvasCenterX, double canvasCenterY)
        {
            Ellipse ellipse = CreateEllipse(spaceObject.ObtainRadius(), spaceObject.ObtainRadius(), spaceObject.GetColor());
            DisplayCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, x - spaceObject.ObtainRadius() / 2);
            Canvas.SetTop(ellipse, y - spaceObject.ObtainRadius() / 2);

            // Render orbits for planets only
            if (spaceObject.GetType() == typeof(Planet))
            {
                double orbitRadius = spaceObject.FetchOrbit() * magnification;
                RenderOrbit(canvasCenterX, canvasCenterY, orbitRadius, orbitRadius);
            }
        }



        // Create an ellipse with the specified dimensions and color
        private Ellipse CreateEllipse(double width, double height, String colorName)
        {
            Color color = (Color)ColorConverter.ConvertFromString(colorName);
            SolidColorBrush fillBrush = new SolidColorBrush(color);
            return new Ellipse
            {
                Width = width,
                Height = height,
                Fill = fillBrush,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
        }

        // Mouse wheel event to zoom in and out
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                magnification *= 1.1;
            }
            else if (e.Key == Key.Down)
            {
                magnification /= 1.1;
            }

            // Clamp zoomView to reasonable limits
            magnification = Math.Clamp(magnification, 0.1, 10);
            RenderCelestialBodies();
        }

    }
}
