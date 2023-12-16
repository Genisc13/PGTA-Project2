using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoPGTA_P2
{
    public partial class SimulationForm : Form
    {
        //This is the dictionary of every plane
        private Dictionary<string, Avion> simulacion;
        //This is the actual step of the simulation
        private int pasoActual = 0;
        //This is the total time of the simulation
        static int totaltime;
        //This is the initial time (is seconds) of the simulation
        private int initialTime;
        //This is the timer used for the simulation
        public Timer timerSimulacion = new Timer();
        //This is the controller of the map on the simulation
        public GMap.NET.WindowsForms.GMapControl gmap;
        //Here there is a dictionary with the visible aircrafts
        public Dictionary<string, bool> ACVisibles;
        //The starting speed of the 
        int startspeed = 1 * 4000;

        public List<string[]> AllDayDepartures;
        /// <summary>
        /// Here we have the simulation Form, it takes the decoded data and transforms it
        /// into the ubication of all the planes that are known by the radar, we can edit
        /// the parameters of the simulation and export a KML file with all the rutes
        /// off all the planes
        /// </summary>
        /// <param name="avionList"></param>
        public SimulationForm(List<CAT48> avionList)
        {
            //Initialization of all components of the simulation
            InitializeComponent();
            initialTime = Convert.ToInt32(Math.Truncate(avionList[0].time));
            ACVisibles = new Dictionary<string, bool>();
            //Gmap initializationS
            gmap = new GMap.NET.WindowsForms.GMapControl();
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gmap.Dock = DockStyle.Fill;
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.ShowCenter = false;
            gmap.Position = new GMap.NET.PointLatLng(40.4165, -3.70256);
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;
            gmap.Zoom = 5;
            splitContainer1.Panel2.Controls.Add(gmap);
            gmap.DragButton = MouseButtons.Left;
            gmap.MouseDoubleClick += Gmap_MouseDoubleClick;
            //Function to print all the markers on the map and start the simulation when needed
            InicializarSimulacion(avionList);
            //Exclusive function to put the markers depending on the actual step of the simulation
            ActivateOverlay(pasoActual);
            SimulTime.Text = initialTime.ToString();
            //Depending on the speed the interval of the timer will be one or other
            timerSimulacion.Interval = startspeed;
            SIMspeed.Text = (4000 / startspeed).ToString() + "x";

            totaltime = Convert.ToInt32(Math.Truncate(avionList[avionList.Count - 1].time)) - initialTime;

            statisticDATA(avionList);
        }

        private void statisticDATA (List<CAT48> avionList)
        {
            string filePath = @"..\\..\\2305_02_dep_lebl.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            AllDayDepartures = new List<string[]>();
            int id = 0;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                AllDayDepartures.Add(line.Split(','));


                id++;
            }

            List<Departure> orderDepartures = new List<Departure>();

            for (int i = initialTime; i < initialTime + totaltime; i+=4) {
                List<Departure> DEP = getPlanesDEPAtTime(i);

                if (DEP.Count > 0)
                {
                    if (orderDepartures.Count == 0)
                    {
                        orderDepartures.Add(DEP[0]);
                    }

                    if (orderDepartures[orderDepartures.Count-1].name != DEP[0].name)
                    {
                        orderDepartures.Add(DEP[0]);
                    }
                    
                }                
            }
        }
        private List<Departure> getPlanesDEPAtTime(int step)
        {
            int offset = 4;

            List<Departure> stepList = new List<Departure>();

            for (int i = 0; i < simulacion.Count; i++)
            {
                Avion avion = simulacion.Values.ElementAt(i);

                for (int j = 0; j < avion.positionList.Count; j++)
                {
                    if ((avion.positionList[j].Time - initialTime) <= step + offset && (avion.positionList[j].Time) >= step)
                    {
                        if (double.IsNaN(avion.positionList[j].X) && double.IsNaN(avion.positionList[j].Y))
                        {
                            break;
                        }
                        else
                        {
                            if (Math.Abs(avion.positionList[j].Time - step) < offset)
                            {
                                if (avion.positionList[j].X > 41.2873 && avion.positionList[j].X < 41.295)
                                {
                                    if (avion.positionList[j].Y > 2.087 && avion.positionList[j].Y < 2.1039)
                                    {
                                        string wake = "N/A";

                                        for (int k = 0; k < AllDayDepartures.Count; k++)
                                        {
                                            string compname = AllDayDepartures[k][1];
                                            if (compname == avion.Name)
                                            {
                                                wake = AllDayDepartures[k][5]; ;
                                                break;
                                            }
                                        }

                                        stepList.Add(new Departure(avion.Name, wake, avion.positionList[j].X, avion.positionList[j].Y, avion.positionList[j].Time));
                                        break;
                                    }
                                }
                            }

                            
                        }
                    }
                }
            }
            /*
            int i = 0;

            foreach (Avion avion in simulacion.Values)
            {
                for (int j = 0; j < avion.positionList.Count; j++)
                {
                    if ((avion.positionList[j].Time - initialTime) <= step + offset && (avion.positionList[j].Time - initialTime) >= step)
                    {
                        if (double.IsNaN(avion.positionList[j].X) && double.IsNaN(avion.positionList[j].Y))
                        {
                            break;
                        }
                        else
                        {
                            if(avion.Name == "3463C6")
                            {
                                int b = 0;
                            }
                            
                            if ( avion.positionList[j].X > 41.2873 | avion.positionList[j].X < 41.2929)
                            {
                                if (avion.positionList[j].Y > 2.087 | avion.positionList[j].Y < 2.101)
                                {
                                    stepList.Add(avion);
                                    break;
                                }
                            }
                        }
                    }
                }

                i++;
            }
            */
            if (stepList.Count > 0)
            {
                int a = 0;
            }

            return stepList;
        }

        public class Departure
        {
            public string name;
            public string estela;
            public Position pos;

            public Departure(string Name, string Estela, double x, double y, float time)
            {
                name = Name;
                estela = Estela;
                pos = new Position(x, y, time, true) ;
            }
        }

        /// <summary>
        /// If you doubleclick on the map it can be seen exatcly at what latitude
        /// and longitude you are pointing at
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtener las coordenadas del punto donde se hizo doble clic
            double latitud = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
            double longitud = gmap.FromLocalToLatLng(e.X, e.Y).Lng;

            // Puedes mostrar las coordenadas en un MessageBox, por ejemplo
            MessageBox.Show($"Coordinates: Latitude {latitud}, Longitude {longitud}");
        }
        /// <summary>
        /// Here we take the CAT48 packets and distribute it on planes and 
        /// position information of every plane
        /// </summary>
        /// <param name="avionList"></param>
        private void InicializarSimulacion(List<CAT48> avionList)
        {
            //Initialization of simulacion
            simulacion = new Dictionary<string, Avion>();
            
            for (int i = 0; i < avionList.Count; i++)
            {
                if (avionList[i].AircraftIdentification == null)
                {
                    avionList[i].AircraftIdentification = "N/A";
                }
                string identification = avionList[i].AircraftIdentification.Replace(" ", "");

                if (identification.Length <=3)
                {
                    //identification = avionList[i].itemContainer.GetDataItem9().AircraftAddress;
                    identification = "N/A";
                }
                
                if (!simulacion.ContainsKey(identification))
                {
                    Avion plane = new Avion(identification);
                    plane.positionList.Add(new Position(avionList[i].Xcord, avionList[i].Ycord, avionList[i].time, true));
                    simulacion.Add(identification, plane);
                }
                else
                {
                    simulacion[identification].AddPosition(new Position(avionList[i].Xcord, avionList[i].Ycord, avionList[i].time, true));
                }
            };
        }
        /// <summary>
        /// This function is performed every time there is a tick on the 
        /// simulation timer, what it does is to change pasoActual and regenerate
        /// the position of the plains
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            if (pasoActual <= totaltime - 4)
            {
                pasoActual += 4;
                gmap.Overlays.Clear();
                //Regenerates the new position of the plains
                ActivateOverlay(pasoActual);
                SimulTime.Text = (initialTime + pasoActual).ToString();
            }
            else
            {
                timerSimulacion.Stop();
                MessageBox.Show("Currenyly on the last step of the simulation, can not advance forward");
            }
        }
        /// <summary>
        /// This is the Avion Class, this class contains 
        /// all the Aircraft data of the planes and information
        /// of the position of every aircraft on every time of the
        /// simulation
        /// </summary>
        public class Avion
        {
            public List<Position> positionList = new List<Position>(totaltime);
            public string Name { get; set; }
            public Avion(string name)
            {
                this.Name = name;
            }
            public void AddPosition(Position pos)
            {
                positionList.Add(pos);
            }
        }
        /// <summary>
        /// This is the class with the position of the AirCrafts,
        /// the X is the Latitude and the Y is the longitude
        /// </summary>
        public class Position
        {
            public double X { get; set; }
            public double Y { get; set; }
            public float Time { get; set; }
            public bool Draw { get; set; }
            public Position(double x, double y, float time, bool draw)
            {
                X = x;
                Y = y;
                Time = time;
                Draw = draw;
            }
        }
        /// <summary>
        /// It does the same as the tick of the timer, but it is done
        /// click by click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvanceButton_Click(object sender, EventArgs e)
        {
            if (pasoActual <= totaltime - 4)
            {
                pasoActual += 4; //% simulacion.Count;
                gmap.Overlays.Clear();
                ActivateOverlay(pasoActual);
                SimulTime.Text = (initialTime + pasoActual).ToString();
            }
            else
            {
                MessageBox.Show("Currenyly on the last step of the simulation, can not advance fordward");
            }
        }
        /// <summary>
        /// This function is created to go steps back on the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if (pasoActual > 0)
            {
                pasoActual -= 4; //% simulacion.Count;
                gmap.Overlays.Clear();
                ActivateOverlay(pasoActual);
                SimulTime.Text = (initialTime + pasoActual).ToString();
            }
            else
            {
                MessageBox.Show("Currently in the first step of the simulation, can not reverse");
            }
        }
        /// <summary>
        /// This is the function thas is used to create the markers on GMap,
        /// it sees the time of the positions and puts a marker of the correct time
        /// </summary>
        private void ActivateOverlay(int step)
        {
            GMap.NET.WindowsForms.GMapOverlay overlay = new GMap.NET.WindowsForms.GMapOverlay("Planes");
            // Dibuja los aviones en el PictureBox

            int i = 0;
            int offset = 4;

            foreach (Avion avion in simulacion.Values)
            {
                for (int j = 0; j < avion.positionList.Count; j++)
                {
                    if ((avion.positionList[j].Time - initialTime) <= step + offset && (avion.positionList[j].Time - initialTime) >= step)
                    {
                        if (double.IsNaN(avion.positionList[j].X) && double.IsNaN(avion.positionList[j].Y))
                        {
                            /*GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(avion.positionList[j-1].X, avion.positionList[j-1].Y);
                            // Crear un marcador
                            GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                            {
                                ToolTipText = avion.Name + " on time: " + avion.positionList[j-1].Time.ToString()
                            };
                            overlay.Markers.Add(marcador);
                            */
                            break;
                        }
                        else
                        {
                            GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(avion.positionList[j].X, avion.positionList[j].Y);
                            // Crear un marcador
                            GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                            {
                                ToolTipText = avion.Name + " on time: " + avion.positionList[j].Time.ToString()
                            };
                            overlay.Markers.Add(marcador);
                            break;
                        }
                    }
                }

                i++;
            }
            // Añadir el marcador al mapa                       
            gmap.Overlays.Add(overlay);
            gmap.Position = new GMap.NET.PointLatLng(41.297445, 2.0832941);
            gmap.Update();
        }
        /// <summary>
        /// This function initializes the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitSim_Click(object sender, EventArgs e)
        {
            // Inicia un temporizador para actualizar la simulación en intervalos regulares
            //timerSimulacion.Interval = startspeed; // Ajusta el intervalo según tus necesidades 4000 = realtime
            timerSimulacion.Tick += TimerSimulacion_Tick;
            timerSimulacion.Start();

        }
        /// <summary>
        /// This function stops the timer when needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopSimulation_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
        }
        /// <summary>
        /// This button takes the information of the textBox and 
        /// generates the complete rute of the Selected Aircraft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                gmap.Overlays.Clear();

                if (AirCraftForRoute.Text == "")
                {
                    MessageBox.Show("You have to use the name of the aircraft");
                }
                else
                {
                    string aircraftName = AirCraftForRoute.Text;

                    // Check if the specified aircraft exists in the simulation
                    if (simulacion.ContainsKey(aircraftName))
                    {
                        Avion aircraft = simulacion[aircraftName];

                        GMap.NET.PointLatLng[] routePoints = new GMap.NET.PointLatLng[aircraft.positionList.Count];
                        for (int i = 0; i < aircraft.positionList.Count; i++)
                        {
                            routePoints[i] = new GMap.NET.PointLatLng(aircraft.positionList[i].X, aircraft.positionList[i].Y);
                        }

                        // Create a route with the positions of the specified aircraft
                        GMap.NET.WindowsForms.GMapRoute route = new GMap.NET.WindowsForms.GMapRoute(routePoints, "Route");

                        // Set the route color and width
                        route.Stroke = new Pen(Color.Blue, 3);

                        // Create a new overlay for the route
                        GMap.NET.WindowsForms.GMapOverlay routeOverlay = new GMap.NET.WindowsForms.GMapOverlay("RouteOverlay");

                        // Add the route to the overlay
                        routeOverlay.Routes.Add(route);

                        // Add the overlay to the map
                        gmap.Overlays.Add(routeOverlay);

                        gmap.Position = new GMap.NET.PointLatLng(41.297445, 2.0832941);
                        gmap.Update();
                    }
                    else
                    {
                        MessageBox.Show($"Aircraft with name '{aircraftName}' not found in the simulation.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// This button is created to make slower the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (timerSimulacion.Interval / 2 > 0)
            {
                timerSimulacion.Interval = timerSimulacion.Interval / 2;
                SIMspeed.Text = Math.Round(4000f / timerSimulacion.Interval, 2).ToString() + "x";
            }

        }
        /// <summary>
        /// This button was created to make the simulation
        /// twice as quick as before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (timerSimulacion.Interval * 2 > 0)
            {
                timerSimulacion.Interval *= 2;
                SIMspeed.Text = Math.Round(4000f / timerSimulacion.Interval, 2).ToString() + "x";
            }
        }
        /// <summary>
        /// This button is the one that generates a .kml file on 
        /// a directory of our choice, this .kml can be readed
        /// on google earth and will contain all the routes of
        /// every aircraft on the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportKMLButton_Click(object sender, EventArgs e)
        {
            try
            {
                //We open the Folder browser dialog
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                ofd.SelectedPath = "..\\";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Use the selected path to create the .kml
                    string filePath = ofd.SelectedPath;
                    StringBuilder kmlContent = new StringBuilder();

                    //We create the .kml string by string 
                    kmlContent.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    kmlContent.AppendLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
                    kmlContent.AppendLine("<Document>");

                    // Iterate over all aircraft in the simulation
                    foreach (var aircraft in simulacion.Values)
                    {
                        kmlContent.AppendLine("<Placemark>");
                        kmlContent.AppendLine($"<name>{aircraft.Name}</name>");
                        kmlContent.AppendLine("<LineString>");
                        kmlContent.AppendLine("<coordinates>" + GetCoordinatesString(aircraft.positionList) + "</coordinates>");
                        kmlContent.AppendLine("</LineString>");
                        kmlContent.AppendLine("</Placemark>");
                    }

                    kmlContent.AppendLine("</Document>");
                    kmlContent.AppendLine("</kml>");

                    // Save the KML content to a file                   
                    File.WriteAllText(filePath + "\\" + "AircraftRoutes.kml", kmlContent.ToString());

                    MessageBox.Show($"KML file created successfully: {filePath}\\AircraftRoutes.kml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// This function takes the positions of the aircrafts and the routes and changes them 
        /// to .kml format in a string
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        private string GetCoordinatesString(List<Position> positions)
        {
            return string.Join(" ", positions.Select(pos => $"{pos.Y.ToString().Replace(",", ".")},{pos.X.ToString().Replace(",", ".")}"));
        }
    }
}
