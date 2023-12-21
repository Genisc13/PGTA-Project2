using Accord.Math;
using GMap.NET.MapProviders;
using MultiCAT6.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoPGTA_P2.SimulationForm;

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
        public GeoUtils geoutils = new GeoUtils(0.081819190842622, 6378137,new CoordinatesWGS84(41.065656 * Math.PI / 180, 0.014133010 * Math.PI / 180));
        //The starting speed of the 
        int startspeed = 1 * 4000;

        public List<CAT48> avionList;      
        public Dictionary<string, List<string>> FlightClasses;
        public Dictionary<string, List<string>> SIDs24;
        public Dictionary<string, List<string>> SIDs06;
        public List<string[]> SIDs24Read;
        public List<string[]> SIDs06Read;
        public List<string[]> AllDayDepartures;
        /// <summary>
        /// Here we have the simulation Form, it takes the decoded data and transforms it
        /// into the ubication of all the planes that are known by the radar, we can edit
        /// the parameters of the simulation and export a KML file with all the rutes
        /// off all the planes
        /// </summary>
        /// <param name="avionList"></param>
        public SimulationForm(List<CAT48> avionList1)
        {
            avionList = avionList1;

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
            LoadCSVs();
        }

        private void RadarMinimaBtn_Click(object sender, EventArgs e)
        {
            RadarMinima();
        }
        private void WakeMinimaBtn_Click(object sender, EventArgs e)
        {
            WakeMinima();
        }

        private void LoaMinimaBtn_Click(object sender, EventArgs e)
        {
            LoAMinima();
        }
        private void LoadCSVs()
        {
            string filePath = @"..\\..\\2305_02_dep_lebl.csv";
            string filePath2 = @"..\\..\\Tabla_Clasificacion_aeronaves.csv";
            string filePath3 = @"..\\..\\Tabla_misma_SID_06R.csv";
            string filePath4 = @"..\\..\\Tabla_misma_SID_24L.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            StreamReader reader2 = new StreamReader(File.OpenRead(filePath2));
            StreamReader reader3 = new StreamReader(File.OpenRead(filePath3));
            StreamReader reader4 = new StreamReader(File.OpenRead(filePath4));
            AllDayDepartures = new List<string[]>();
            List<string[]> FlightClassRead = new List<string[]>();
            FlightClasses = new Dictionary<string, List<string>>();
            SIDs24 = new Dictionary<string, List<string>>();
            SIDs06 = new Dictionary<string, List<string>>();
            SIDs24Read = new List<string[]>();
            SIDs06Read = new List<string[]>();

            int id = 0;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                AllDayDepartures.Add(line.Split(','));


                id++;
            }
            id = 0;
            while (!reader2.EndOfStream)
            {
                line = reader2.ReadLine();
                FlightClassRead.Add(line.Split(','));

                id++;
            }
            id = 0;
            while (!reader3.EndOfStream)
            {
                line = reader3.ReadLine();
                SIDs06Read.Add(line.Split(','));

                id++;
            }
            id = 0;
            while (!reader4.EndOfStream)
            {
                line = reader4.ReadLine();
                SIDs24Read.Add(line.Split(','));

                id++;
            }

            for (int t = 0; t < FlightClassRead.Count; t++)
            {
                if (t == 0)
                {
                    FlightClasses.Add(FlightClassRead[t][0], new List<string>());
                    FlightClasses.Add(FlightClassRead[t][1], new List<string>());
                    FlightClasses.Add(FlightClassRead[t][2], new List<string>());
                    FlightClasses.Add(FlightClassRead[t][3], new List<string>());
                    FlightClasses.Add(FlightClassRead[t][4], new List<string>());
                }
                else
                {
                    if (FlightClassRead[t][0] != "")
                    {
                        FlightClasses[FlightClassRead[0][0]].Add(FlightClassRead[t][0]);
                    }
                    if (FlightClassRead[t][1] != "")
                    {
                        FlightClasses[FlightClassRead[0][1]].Add(FlightClassRead[t][1]);
                    }
                    if (FlightClassRead[t][2] != "")
                    {
                        FlightClasses[FlightClassRead[0][2]].Add(FlightClassRead[t][2]);
                    }
                    if (FlightClassRead[t][3] != "")
                    {
                        FlightClasses[FlightClassRead[0][3]].Add(FlightClassRead[t][3]);
                    }
                    if (FlightClassRead[t][4] != "")
                    {
                        FlightClasses[FlightClassRead[0][4]].Add(FlightClassRead[t][4]);
                    }
                }
            }
            for (int t = 0; t < SIDs24Read.Count; t++)
            {
                if (t == 0)
                {
                    SIDs24.Add(SIDs24Read[t][0], new List<string>());
                    SIDs24.Add(SIDs24Read[t][1], new List<string>());
                    SIDs24.Add(SIDs24Read[t][2], new List<string>());
                }
                else
                {
                    if (SIDs24Read[t][0] != "")
                    {
                        SIDs24[SIDs24Read[0][0]].Add(SIDs24Read[t][0]);
                    }
                    if (SIDs24Read[t][1] != "")
                    {
                        SIDs24[SIDs24Read[0][1]].Add(SIDs24Read[t][1]);
                    }
                    if (SIDs24Read[t][2] != "")
                    {
                        SIDs24[SIDs24Read[0][2]].Add(SIDs24Read[t][2]);
                    }
                }
            }
            for (int t = 0; t < SIDs06Read.Count; t++)
            {
                if (t == 0)
                {
                    SIDs06.Add(SIDs06Read[t][0], new List<string>());
                    SIDs06.Add(SIDs06Read[t][1], new List<string>());
                    SIDs06.Add(SIDs06Read[t][2], new List<string>());
                }
                else
                {
                    if (SIDs06Read[t][0] != "")
                    {
                        SIDs06[SIDs06Read[0][0]].Add(SIDs06Read[t][0]);
                    }
                    if (SIDs06Read[t][1] != "")
                    {
                        SIDs06[SIDs06Read[0][1]].Add(SIDs06Read[t][1]);
                    }
                    if (SIDs06Read[t][2] != "")
                    {
                        SIDs06[SIDs06Read[0][2]].Add(SIDs06Read[t][2]);
                    }
                }
            }
        }

        private void RadarMinima()
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath = "..\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string[]> breakMinima = new List<string[]>();
                List<Departure> orderDepartures = new List<Departure>();

                for (int i = initialTime; i < initialTime + totaltime; i += 4)
                {
                    List<Departure> DEP = getPlanesDEPAtTime(i);

                    if (DEP.Count > 0)
                    {
                        if (orderDepartures.Count == 0)
                        {
                            orderDepartures.Add(DEP[0]);
                        }

                        if (orderDepartures[orderDepartures.Count - 1].name != DEP[0].name)
                        {
                            orderDepartures.Add(DEP[0]);
                        }
                    }
                }

                List<float> Distances = new List<float>();

                for (int i = 1; i < orderDepartures.Count; i++)
                {
                    int time = (int)Math.Floor(orderDepartures[i].pos.Time);
                    Position thispos = orderDepartures[i].pos;
                    Position prepos;
                    string preplane = orderDepartures[i - 1].name;
                    string thisplane = orderDepartures[i].name;

                    for (int k = 0; k < simulacion[preplane].positionList.Count; k++)
                    {
                        if (simulacion[preplane].positionList[k].Time < time + 4 && simulacion[preplane].positionList[k].Time > time)
                        {
                            prepos = simulacion[preplane].positionList[k];

                            float dist = Distance2D(prepos, thispos);
                            orderDepartures[i].distance = dist;

                            if (dist < 3)
                            { 
                                breakMinima.Add(new string[] { orderDepartures[i].name, orderDepartures[i].estela, orderDepartures[i - 1].name, orderDepartures[i - 1].estela, orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                            }

                            break;
                        }
                    }


                }
                string filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                StringBuilder csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                int h = 1;
                csvContent.AppendLine("NUM;Name;Estela;Lat;Lon;Altitude;Time;Distance");
                foreach (var minimadata in orderDepartures)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.name.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.estela.ToString());
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.X.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Y.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Z.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString());
                    }
                    rowDataBuilder.Append(";");

                    rowDataBuilder.Append(minimadata.pos.Time.ToString());

                    rowDataBuilder.Append(";");
                    if (minimadata.distance.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString());
                    }

                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "RadarMinimaData.csv", csvContent.ToString());

                filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                h = 1;
                csvContent.AppendLine("NUM;ID_1;WAKE_1;ID_2;WAKE_2;Time;Distance"); //PODRIAMOS QUITAR LOS WAKE
                foreach (var minimadata in breakMinima)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    foreach (var value in minimadata)
                    {
                        rowDataBuilder.Append(";");
                        if (value.ToString().Contains(","))
                        {
                            rowDataBuilder.Append(value.ToString().Replace(",", "."));
                        }
                        else
                        {
                            rowDataBuilder.Append(value.ToString());
                        }
                    }
                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "BreakRadarMinimaData.csv", csvContent.ToString());

                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "BreakRadarMinimaData.csv");
                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "RadarMinimaData.csv");
            }
        }

        private void AllRadarMinima() //Distancia minima 3NM TODOS ENTRE TODOS
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath = "..\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string[]> breakMinima = new List<string[]>();
                int calcdist = 0;
                List<List<Avion>> planes = new List<List<Avion>>();

                int[] timeMatrix = new int[totaltime / 4];
                int index = 0;
                for (var i = initialTime; index < timeMatrix.Length; i += 4)
                {
                    timeMatrix[index] = i;
                    index++;
                }
                Parallel.ForEach(timeMatrix, time =>
                {
                    List<Avion> planestime = new List<Avion>();
                    List<Position> positionstime = new List<Position>();

                    foreach (Avion Avion1 in simulacion.Values)
                    {
                        ConcurrentBag<Avion> planestimeLocal = new ConcurrentBag<Avion>();
                        ConcurrentBag<Position> positionstimeLocal = new ConcurrentBag<Position>();

                        foreach (Position pos1 in Avion1.positionList)
                        {
                            if (pos1.Time > time && pos1.Time < time + 4 && pos1 != null)
                            {
                                planestimeLocal.Add(Avion1);
                                positionstimeLocal.Add(pos1);
                            }
                        }

                        // Combina las listas locales en la lista global después de que se hayan completado las iteraciones
                        lock (breakMinima)
                        {
                            planestime.AddRange(planestimeLocal);
                            positionstime.AddRange(positionstimeLocal);
                        }
                    }

                    List<string[]> localBreakMinima = new List<string[]>(); // Lista local para almacenar resultados

                    for (int i = 0; i < positionstime.Count; i++)
                    {
                        for (int j = 0; j < positionstime.Count; j++)
                        {
                            if (positionstime[i] != positionstime[j])
                            {
                                float distance = (float)Math.Round(Distance2D(positionstime[i], positionstime[j]), 2);

                                if (distance < 3)
                                {
                                    string[] row = new string[] { planestime[i].Name, planestime[j].Name, time.ToString(), ((float)Math.Round(Distance2D(positionstime[i], positionstime[j]), 2)).ToString() };
                                    localBreakMinima.Add(row);

                                }

                                calcdist++;
                            }
                        }
                    }
                    lock (breakMinima)
                    {
                        breakMinima.AddRange(localBreakMinima);
                    }
                });                

                string filePath = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                StringBuilder csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                int h = 1;
                csvContent.AppendLine("NUM;ID_1;ID_2;Time;Distance");
                foreach(var minimadata in breakMinima)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());                   
                    foreach (var value in minimadata)
                    {
                        rowDataBuilder.Append(";");
                        if (value.ToString().Contains(","))
                        {
                            rowDataBuilder.Append(value.ToString().Replace(",", "."));
                        }
                        else
                        {
                            rowDataBuilder.Append(value.ToString());
                        }                      
                    }                                                                                       
                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath + "\\" + "BreakRadarMinimaRadarData.csv", csvContent.ToString());

                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath + "\\" + "BreakRadarMinimaRadarData.csv");
            }        
        }

        private void LoAMinima() //No se lo que es
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath = "..\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string[]> breakMinima = new List<string[]>();
                
                List<Departure> orderDepartures = new List<Departure>();

                for (int i = initialTime; i < initialTime + totaltime; i += 4)
                {
                    List<Departure> DEP = getPlanesDEPAtTime(i);

                    if (DEP.Count > 0)
                    {
                        if (orderDepartures.Count == 0)
                        {
                            orderDepartures.Add(DEP[0]);
                        }

                        if (orderDepartures[orderDepartures.Count - 1].name != DEP[0].name)
                        {
                            orderDepartures.Add(DEP[0]);
                        }
                    }
                }

                List<float> Distances = new List<float>();

                for (int i = 1; i < orderDepartures.Count; i++)
                {
                    int time = (int)Math.Floor(orderDepartures[i].pos.Time);
                    Position thispos = orderDepartures[i].pos;
                    Position prepos;
                    string preplane = orderDepartures[i - 1].name;
                    string thisplane = orderDepartures[i].name;

                    for (int k = 0; k < simulacion[preplane].positionList.Count; k++)
                    {
                        if (simulacion[preplane].positionList[k].Time < time + 4 && simulacion[preplane].positionList[k].Time > time)
                        {
                            prepos = simulacion[preplane].positionList[k];

                            orderDepartures[i].distance = Distance2D(prepos, thispos);

                            if (orderDepartures[i - 1].estela == "Ligera")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }
                            else if (orderDepartures[i - 1].estela == "Media")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 5)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }
                            else if (orderDepartures[i - 1].estela == "Pesada")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 6)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 5)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 4)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }
                            else if (orderDepartures[i - 1].estela == "Super Pesada")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 8)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 7)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 6)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }
                            break;
                        }
                    }


                }
                string filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                StringBuilder csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                int h = 1;
                csvContent.AppendLine("NUM;Name;Estela;Lat;Lon;Altitude;Time;Distance");
                foreach (var minimadata in orderDepartures)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.name.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.estela.ToString());
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.X.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Y.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Z.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString());
                    }
                    rowDataBuilder.Append(";");

                    rowDataBuilder.Append(minimadata.pos.Time.ToString());

                    rowDataBuilder.Append(";");
                    if (minimadata.distance.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString());
                    }

                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "LoAMinimaData.csv", csvContent.ToString());

                filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                h = 1;
                csvContent.AppendLine("NUM;ID_1;WAKE_1;ID_2;WAKE_2;Time;Distance");
                foreach (var minimadata in breakMinima)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    foreach (var value in minimadata)
                    {
                        rowDataBuilder.Append(";");
                        if (value.ToString().Contains(","))
                        {
                            rowDataBuilder.Append(value.ToString().Replace(",", "."));
                        }
                        else
                        {
                            rowDataBuilder.Append(value.ToString());
                        }
                    }
                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "BreakLoAMinimaData.csv", csvContent.ToString());

                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "BreakLoAMinimaData.csv");
                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "LoAMinimaData.csv");
            }
        }

        private void WakeMinima () //Distancia minima WAKE entre despegues
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath = "..\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {               
                List<string[]> breakMinima = new List<string[]>();               
                List<Departure> orderDepartures = new List<Departure>();

                for (int i = initialTime; i < initialTime + totaltime; i += 4)
                {
                    List<Departure> DEP = getPlanesDEPAtTime(i);

                    if (DEP.Count > 0)
                    {
                        if (orderDepartures.Count == 0)
                        {
                            orderDepartures.Add(DEP[0]);
                        }

                        if (orderDepartures[orderDepartures.Count - 1].name != DEP[0].name)
                        {
                            orderDepartures.Add(DEP[0]);
                        }
                    }
                }

                List<float> Distances = new List<float>();

                for (int i = 1; i < orderDepartures.Count; i++)
                {                  
                    int time = (int)Math.Floor(orderDepartures[i].pos.Time);
                    Position thispos = orderDepartures[i].pos;
                    Position prepos;
                    string preplane = orderDepartures[i - 1].name;
                    string thisplane = orderDepartures[i].name;                                                    
                                        
                    for (int k = 0; k < simulacion[preplane].positionList.Count; k++)
                    {
                        if (simulacion[preplane].positionList[k].Time < time + 4 && simulacion[preplane].positionList[k].Time > time)
                        {
                            prepos = simulacion[preplane].positionList[k];

                            orderDepartures[i].distance = Distance2D(prepos, thispos);

                            /*if (orderDepartures[i - 1].estela == "Ligera")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }
                            else */if (orderDepartures[i - 1].estela == "Media")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 5)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                /*else  if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }*/
                            }
                            else if (orderDepartures[i - 1].estela == "Pesada")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 6)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 5)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 4)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                /*else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }*/
                            }
                            /*else if (orderDepartures[i - 1].estela == "Super Pesada")
                            {
                                if (orderDepartures[i].estela == "Ligera")
                                {
                                    if (orderDepartures[i].distance < 8)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Media")
                                {
                                    if (orderDepartures[i].distance < 7)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Pesada")
                                {
                                    if (orderDepartures[i].distance < 6)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                                else if (orderDepartures[i].estela == "Super Pesada")
                                {
                                    if (orderDepartures[i].distance < 3)
                                    {
                                        breakMinima.Add(new string[] {orderDepartures[i].name,orderDepartures[i].estela, orderDepartures[i-1].name,orderDepartures[i-1].estela,
                                            orderDepartures[i].pos.Time.ToString(), orderDepartures[i].distance.ToString() });
                                    }
                                }
                            }*/
                            break;
                        }
                    }
                    
                    
                }
                string filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                StringBuilder csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                int h = 1;
                csvContent.AppendLine("NUM;Name;Estela;Lat;Lon;Altitude;Time;Distance");
                foreach (var minimadata in orderDepartures)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.name.ToString());
                    rowDataBuilder.Append(";");
                    rowDataBuilder.Append(minimadata.estela.ToString());
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.X.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.X.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Y.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Y.ToString());
                    }
                    rowDataBuilder.Append(";");
                    if (minimadata.pos.Z.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.pos.Z.ToString());
                    }
                    rowDataBuilder.Append(";");

                    rowDataBuilder.Append(minimadata.pos.Time.ToString());

                    rowDataBuilder.Append(";");
                    if (minimadata.distance.ToString().Contains(","))
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString().Replace(",", "."));
                    }
                    else
                    {
                        rowDataBuilder.Append(minimadata.distance.ToString());
                    }

                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "WakeMinimaData.csv", csvContent.ToString());

                filePath1 = ofd.SelectedPath;
                // Create a StringBuilder to store the CSV content
                csvContent = new StringBuilder();
                //Here the CSV content is written string by string
                h = 1;
                csvContent.AppendLine("NUM;ID_1;WAKE_1;ID_2;WAKE_2;Time;Distance");
                foreach (var minimadata in breakMinima)
                {
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Iterates on the data and agregates every row at the CSV content 
                    rowDataBuilder.Append(h.ToString());
                    foreach (var value in minimadata)
                    {
                        rowDataBuilder.Append(";");
                        if (value.ToString().Contains(","))
                        {
                            rowDataBuilder.Append(value.ToString().Replace(",", "."));
                        }
                        else
                        {
                            rowDataBuilder.Append(value.ToString());
                        }
                    }
                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                    h++;
                }
                // Save the complete content on a .csv file
                File.WriteAllText(filePath1 + "\\" + "BreakWakeMinimaData.csv", csvContent.ToString());

                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "BreakWakeMinimaData.csv");
                // Shows a confirmation message
                MessageBox.Show("CSV file succesfully generated: " + filePath1 + "\\" + "WakeMinimaData.csv");
            }
        }

        private float Distance2D(Position pos1, Position pos2)
        {
            

            double lat1Rad = pos1.X * Math.PI / 180;
            double lon1Rad = pos1.Y * Math.PI / 180;
            double lat2Rad = pos2.X * Math.PI / 180;
            double lon2Rad = pos2.Y * Math.PI / 180;

            CoordinatesWGS84 pos1coords = new CoordinatesWGS84(lat1Rad, lon1Rad, pos1.Z);
            CoordinatesWGS84 pos2coords = new CoordinatesWGS84(lat2Rad, lon2Rad, pos2.Z);

            CoordinatesXYZ pos1XYZ = geoutils.change_geodesic2geocentric(pos1coords);
            CoordinatesXYZ pos2XYZ = geoutils.change_geodesic2geocentric(pos2coords);

            CoordinatesXYZ pos1systemCart = geoutils.change_geocentric2system_cartesian(pos1XYZ);
            CoordinatesXYZ pos2systemCart = geoutils.change_geocentric2system_cartesian(pos2XYZ);

            CoordinatesUVH pos1systemStereo = geoutils.change_system_cartesian2stereographic(pos1systemCart);
            CoordinatesUVH pos2systemStereo = geoutils.change_system_cartesian2stereographic(pos2systemCart);

            float delta_x = (float)((pos1systemStereo.U - pos2systemStereo.U)*(pos1systemStereo.U - pos2systemStereo.U)) ;
            float delta_y = (float)((pos1systemStereo.V - pos2systemStereo.V) * (pos1systemStereo.V - pos2systemStereo.V));

            return (float)(Math.Sqrt(delta_x+delta_y)/1852);
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
                                if (avion.positionList[j].X > 41.2817 && avion.positionList[j].X < 41.294) 
                                {
                                    if (avion.positionList[j].Y > 2.073 && avion.positionList[j].Y < 2.1041)
                                    {
                                        string wake = "N/A";

                                        for (int k = 0; k < AllDayDepartures.Count; k++)
                                        {
                                            string compname = AllDayDepartures[k][1];
                                            if (compname == avion.Name)
                                            {
                                                wake = AllDayDepartures[k][5];
                                                stepList.Add(new Departure(avion.Name, wake, AllDayDepartures[k][5], avion.positionList[j].X, avion.positionList[j].Y,avion.positionList[j].Z, avion.positionList[j].Time));
                                                break;
                                            }
                                        }

                                        
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

            return stepList;
        }

        public class Departure
        {
            public string name;
            public string estela;
            public Position pos;
            public float distance = 999;
            public string model;


            public Departure(string Name, string Estela,string Model ,double x, double y, double z, float time)
            {
                name = Name;
                estela = Estela;
                model = Model;
                pos = new Position(x, y, z, time, true) ;
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
                    plane.positionList.Add(new Position(avionList[i].Xcord, avionList[i].Ycord, avionList[i].Zcord, avionList[i].time, true));
                    simulacion.Add(identification, plane);
                }
                else
                {
                    simulacion[identification].AddPosition(new Position(avionList[i].Xcord, avionList[i].Ycord, avionList[i].Zcord, avionList[i].time, true));
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
            public double Z { get; set; }
            public float Time { get; set; }
            public bool Draw { get; set; }
            public Position(double x, double y, double z, float time, bool draw)
            {
                X = x;
                Y = y;
                Z = z;
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
                                ToolTipText = avion.Name + " on time: " + avion.positionList[j].Time.ToString() + " at altitude: " + avion.positionList[j].Z
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
