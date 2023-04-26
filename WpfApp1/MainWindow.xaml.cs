using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;
using WpfApp1;
using Space;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        private Ellipse sun = new Ellipse();
        private Ellipse mercury = new Ellipse();
        private Ellipse venus = new Ellipse();
        private Ellipse earth = new Ellipse();
        private Ellipse moon = new Ellipse();
        private Ellipse mars = new Ellipse();
        private Ellipse jupiter = new Ellipse();
        private Ellipse saturn = new Ellipse();
        private Ellipse uranus = new Ellipse();
        private Ellipse neptune = new Ellipse();


        private Ellipse orbitalmercury = new Ellipse();
        private Ellipse orbitalvenus = new Ellipse();
        private Ellipse orbitalearth = new Ellipse();
        private Ellipse orbitalmars = new Ellipse();
        private Ellipse orbitaljupiter = new Ellipse();
        private Ellipse orbitalsaturn = new Ellipse();
        private Ellipse orbitaluranus = new Ellipse();
        private Ellipse orbitalneptune = new Ellipse();

        private Point sunPos = new(200, 380);
        private Point mercuryPos = new(200, 323);
        private Point venusPos = new(200, 249);
        private Point earthPos = new(200, 192);
        private Point moonPos = new(200, 205);
        private Point marsPos = new(200, 135);
        private Point jupiterPos = new(200, 76);
        private Point saturnPos = new(200, 61);
        private Point neptunePos = new(200, 45);
        private Point uranusPos = new(200, 30);
        private Boolean inUse = false;

        private Label suntekst = new Label();
        private Label mercurytekst = new Label();
        private Label venustekst = new Label();
        private Label earthtekst = new Label();
        private Label moontekst = new Label();
        private Label marstekst = new Label();
        private Label jupitertekst = new Label();
        private Label saturntekst = new Label();
        private Label neptunetekst = new Label();
        private Label uranustekst = new Label();

        private Grid gridboxc = new Grid();
        private Grid gridboxmercury = new Grid();
        private Grid gridboxmoon= new Grid();
        private Grid gridboxmars = new Grid();
        private Grid gridboxearth = new Grid();
        private Grid gridboxjupiter= new Grid();
        private Grid gridboxneptune=new Grid();
        private Grid gridboxsaturn= new Grid();
        private Grid  gridboxuranus = new Grid();
        private Grid  gridboxvenus = new Grid();
        private App app = new App();
        private SpaceObject obj = new SpaceObject("mercury",80,57910);



        //  private String

        public MainWindow()
        {
            InitializeComponent();
            
            orbitalmercury.Width = orbitalmercury.Height = app.orbitalring(obj);
            orbitalvenus.Width = orbitalvenus.Height = app.orbitalring(obj);
            orbitalearth.Width = orbitalearth.Height = app.orbitalring(obj); 
            orbitalmars.Width = orbitalmars.Height = app.orbitalring(obj);
            jupiter.Width = jupiter.Height = app.orbitalring(obj);


            sun.Width = sun.Height = app.proportionsystem(obj);
            mercury.Width = mercury.Height = app.proportionsystem(obj);
            venus.Width = venus.Height = app.proportionsystem(obj);
            earth.Width = earth.Height = app.proportionsystem(obj);
            mars.Width = mars.Height = app.proportionsystem(obj);
            moon.Width = moon.Height = app.proportionsystem(obj);
            jupiter.Width = jupiter.Height = app.proportionsystem(obj);

            sun.Fill = new SolidColorBrush(Colors.Yellow);
            mercury.Fill = new SolidColorBrush(Colors.LightGray);
            venus.Fill = new SolidColorBrush(Colors.DarkGray);
            earth.Fill = new SolidColorBrush(Colors.DarkSeaGreen);
            mars.Fill = new SolidColorBrush(Colors.OrangeRed);
            moon.Fill = new SolidColorBrush(Colors.LightGray);
            jupiter.Fill = new SolidColorBrush(Colors.Brown);
            saturn.Fill=new SolidColorBrush(Colors.Green);
            neptune.Fill=new SolidColorBrush(Colors.Blue);
            uranus.Fill=new SolidColorBrush(Colors.Lime);

            combobox1.Items.Add("mercury");
            combobox1.Items.Add("venus");
            combobox1.Items.Add("earth");
            combobox1.Items.Add("mars");
            combobox1.Items.Add("jupiter");
            combobox1.Items.Add("saturn");
            combobox1.Items.Add("neptune");
            combobox1.Items.Add("uranus");

            main.Text = "";



            if (inUse == false)
            {
                space.Children.Add(sun);
                Canvas.SetTop(sun, sunPos.X);
                Canvas.SetLeft(sun, sunPos.Y);


                space.Children.Add(mercury);
                Canvas.SetTop(mercury, mercuryPos.X);
                Canvas.SetLeft(mercury, mercuryPos.Y);

                space.Children.Add(venus);
                Canvas.SetTop(venus, venusPos.X);
                Canvas.SetLeft(venus, venusPos.Y);

                space.Children.Add(earth);
                Canvas.SetTop(earth, earthPos.X);
                Canvas.SetLeft(earth, earthPos.Y);

                space.Children.Add(moon);
                Canvas.SetTop(moon, moonPos.X);
                Canvas.SetLeft(moon, moonPos.Y);

                space.Children.Add(mars);
                Canvas.SetTop(mars, marsPos.X);
                Canvas.SetLeft(mars, marsPos.Y);

                space.Children.Add(jupiter);
                Canvas.SetTop(jupiter, jupiterPos.X);
                Canvas.SetLeft(jupiter, jupiterPos.Y);

                space.Children.Add(uranus);
                Canvas.SetTop(uranus, uranusPos.X);
                Canvas.SetLeft(uranus, uranusPos.Y);

                space.Children.Add(saturn);
                Canvas.SetTop(saturn, saturnPos.X);
                Canvas.SetLeft(saturn, saturnPos.Y);

                space.Children.Add(neptune);
                Canvas.SetTop(neptune, neptunePos.X);
                Canvas.SetLeft(neptune, neptunePos.Y);
            }

            suntekst.Content = "Sun";
            mercurytekst.Content = "Mercury";
            venustekst.Content = "Venus";
            earthtekst.Content = "Earth";
            moontekst.Content = "Moon";
            marstekst.Content = "Mars";
            jupitertekst.Content = "Jupiter";
            uranustekst.Content = "uranus";
            saturntekst.Content = "saturn";
            neptunetekst.Content = "neptune";

            suntekst.Width = 30;
            mercurytekst.Width = 30;
            venustekst.Width = 30;
            earthtekst.Width = 30;
            moontekst.Width = 30;
            marstekst.Width = 30;
            jupitertekst.Width = 30;
            uranustekst.Width = 30;
            saturntekst.Width = 30;
            neptunetekst.Width = 30;

            suntekst.Height = 15;
            mercurytekst.Height = 15;
            venustekst.Height = 15;
            earthtekst.Height = 15;
            moontekst.Height = 15;
            marstekst.Height = 15;
            jupitertekst.Height = 15;
            uranustekst.Height = 15;
            saturntekst.Height = 15;
            neptunetekst.Height = 15;






            Canvas.SetTop(suntekst, sunPos.X + 20);
            Canvas.SetLeft(suntekst, sunPos.Y);

            Canvas.SetTop(mercurytekst, mercuryPos.X + 20);
            Canvas.SetLeft(mercurytekst, mercuryPos.Y);

            Canvas.SetTop(venustekst, venusPos.X + 20);
            Canvas.SetLeft(venustekst, venusPos.Y);

            Canvas.SetTop(earthtekst, earthPos.X + 20);
            Canvas.SetLeft(earthtekst, earthPos.Y);

            Canvas.SetTop(moontekst, moonPos.X + 20);
            Canvas.SetLeft(moontekst, moonPos.Y);

            Canvas.SetTop(marstekst, marsPos.X + 20);
            Canvas.SetLeft(marstekst, marsPos.Y);

            Canvas.SetTop(jupitertekst, jupiterPos.X + 20);
            Canvas.SetLeft(jupitertekst, jupiterPos.Y);

            Canvas.SetTop(saturntekst, saturnPos.X + 20);
            Canvas.SetLeft(saturntekst, saturnPos.Y);

            Canvas.SetTop(neptunetekst, neptunePos.X + 20);
            Canvas.SetLeft(neptunetekst, neptunePos.Y);

            Canvas.SetTop(uranustekst, uranusPos.X + 20);
            Canvas.SetLeft(uranustekst, uranusPos.Y);

            DispatcherTimer tick = new()
            {
                Interval = TimeSpan.FromMilliseconds(60)


            };

            tick.Tick += dotick;

            button.MouseDoubleClick += dotick;
            HideText.MouseDoubleClick += buttonclick;


            tick.Start();

          //gridboxc.MouseRightClick += reversegrid;
        }

        private void dotick(object sender, EventArgs e)
        {
            int teller = 1;

            if (teller == 365)
            {
                teller = 1;
            }

            if (combobox1 != null)
            {

                if (combobox1.SelectedItem.Equals("mercury"))

                {
                    gridboxmercury.Focus();
                    main.Text = "Object radius: 57910 Object period: 88 days Color: Azure";

                }
                else if (combobox1.SelectedItem.Equals("venus"))

                {
                    gridboxvenus.Focus();
                    main.Text = "Object radius: 108200 Object period: 224 days Color: Pearly white";

                }
                else if (combobox1.SelectedItem.Equals("earth"))
                {
                    gridboxearth.Focus();    

                    main.Text = "Object radius: 149600 Object Period: 365 Color: Mostly blue";

                }
                else if (combobox1.SelectedItem.Equals("mars"))
                {

                    gridboxmars.Focus(); 
                    main.Text = "Object radius: 227940 Object period: 686 days Color: OrangeRed";
                }
                else if (combobox1.SelectedItem.Equals("saturn"))
                {
                    gridboxsaturn.Focus(); 
                    main.Text = "Object radius: 778330 Object period: 4333 Color: Brown - Orange";
                }
                else if (combobox1.SelectedItem.Equals("neptune"))
                {
                    gridboxneptune.Focus();
                    main.Text = "Object radius: 778330 Object period: 4333 Color: Brown - Orange";
                }
                else if (combobox1.SelectedItem.Equals("jupiter"))
                {
                    gridboxjupiter.Focus();
                    main.Text = "Object radius: 778330 Object period: 4333 Color: Brown - Orange";
                }
                else if (combobox1.SelectedItem.Equals("uranus"))
                {
                    gridboxuranus.Focus();
                    main.Text = "Object radius: 778330 Object period: 4333 Color: Brown - Orange";
                }


                int degree = 1;
                Canvas.SetTop(mercury, mercuryPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(mercury, mercuryPos.Y * Math.Sin((degree * teller) * Math.PI / 180));
                // mercuryPos.X =  mercuryPos.X * Math.Cos((degree*teller)*Math.PI / 180);
                //mercuryPos.Y = mercuryPos.Y * Math.Sin((degree * teller)*Math.PI / 180);
                Canvas.SetTop(venus, venusPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(venus, venusPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(earth, earthPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(earth, earthPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(moon, moonPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(moon, moonPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(mars, marsPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(mars, marsPos.Y * Math.Sin((degree * teller) * Math.PI / 180));


                Canvas.SetTop(jupiter, jupiterPos.X * Math.Cos((degree * teller) * Math.PI / 180));
                Canvas.SetLeft(jupiter, jupiterPos.Y * Math.Sin((degree * teller) * Math.PI / 180));
                

                Canvas.SetTop(venustekst, venusPos.X * Math.Cos((degree * teller) * Math.PI / 180) + 20);
                Canvas.SetLeft(venustekst, venusPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(earthtekst, earthPos.X * Math.Cos((degree * teller) * Math.PI / 180) + 20);
                Canvas.SetLeft(earthtekst, earthPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(moontekst, moonPos.X * Math.Cos((degree * teller) * Math.PI / 180) + 20);
                Canvas.SetLeft(moontekst, moonPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(marstekst, marsPos.X * Math.Cos((degree * teller) * Math.PI / 180) + 20);
                Canvas.SetLeft(marstekst, marsPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

                Canvas.SetTop(jupitertekst, jupiterPos.X * Math.Cos((degree * teller) * Math.PI / 180) + 20);
                Canvas.SetLeft(jupitertekst, jupiterPos.Y * Math.Sin((degree * teller) * Math.PI / 180));

            }

            teller++;
        }
        private void buttonclick(object sender, MouseEventArgs e)
        {
            int teller2 = 0;
            if (sender is Button)
            {
                if (teller2 == 1)
                {
                    suntekst.Content = "Sun";
                    mercurytekst.Content = "Mercury";
                    venustekst.Content = "Venus";
                    earthtekst.Content = "Earth";
                    moontekst.Content = "Moon";
                    marstekst.Content = "Mars";
                    jupitertekst.Content = "Jupiter";
                    saturntekst.Content = "saturn";
                    neptunetekst.Content = "neptune";
                    uranustekst.Content = "uranus";
                    teller2--;
                    // break;
                }

            }
            else {
                suntekst.Content = "";
                mercurytekst.Content = "";
                venustekst.Content = "";
                earthtekst.Content = "";
                moontekst.Content = "";
                marstekst.Content = "";
                jupitertekst.Content = "";
                saturntekst.Content = "";
                neptunetekst.Content = "";
                uranustekst.Content = "";
                teller2++;
            }


        }

        private void reversegrid(object sender, EventArgs e)
        {
            if (gridbox1 != null)
            {
                gridbox1.Focus();

            }
        }

       
       
            }
        }

    


    

    

