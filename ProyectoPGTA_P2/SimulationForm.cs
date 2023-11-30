using Accord;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoPGTA_P2.SimulationForm;

namespace ProyectoPGTA_P2
{
    public partial class SimulationForm : Form
    {
        private Dictionary<string, Avion> simulacion;
        private int pasoActual=4;
        static int totaltime;
        private int initialTime;
        public Timer timerSimulacion = new Timer();
        public GMap.NET.WindowsForms.GMapControl gmap;
        public SimulationForm(List<CAT48> avionList)
        {
            InitializeComponent();
            initialTime = Convert.ToInt32(avionList[0].itemContainer.GetDataItem2().time);
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
            InicializarSimulacion(avionList);
            ActivateOverlay();
            
        }

        private void Gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtener las coordenadas del punto donde se hizo doble clic
            double latitud = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
            double longitud = gmap.FromLocalToLatLng(e.X, e.Y).Lng;

            // Puedes mostrar las coordenadas en un MessageBox, por ejemplo
            MessageBox.Show($"Coordenadas: Latitud {latitud}, Longitud {longitud}");
        }
        private void InicializarSimulacion(List<CAT48> avionList)
        {
            simulacion = new Dictionary<string, Avion>();
            totaltime = Convert.ToInt32(avionList[avionList.Count - 1].itemContainer.GetDataItem2().time) - Convert.ToInt32(avionList[0].itemContainer.GetDataItem2().time);

            /*
             foreach( CAT48 avion in avionList)
            {
                string address = avion.itemContainer.GetDataItem8().AircraftAddress;
                if (!simulacion.ContainsKey(address))
                {                       
                    Avion plane = new Avion(address);                                                                            
                    plane.positionList.Add( new Position(avion.itemContainer.GetDataItem12().Xcord, avion.itemContainer.GetDataItem12().Ycord, Convert.ToInt32(avion.itemContainer.GetDataItem2().time), true));                                                                                                                                                                   
                    simulacion.Add(address, plane);
                }
                else
                {
                    simulacion[address].AddPosition(new Position(avion.itemContainer.GetDataItem12().Xcord, avion.itemContainer.GetDataItem12().Ycord, Convert.ToInt32(avion.itemContainer.GetDataItem2().time), true));
                }               
            };
            */

            for (int i = 0; i < avionList.Count; i++)
            {
                string address = avionList[i].itemContainer.GetDataItem8().AircraftAddress;
                if (!simulacion.ContainsKey(address))
                {
                    Avion plane = new Avion(address);
                    plane.positionList.Add(new Position(avionList[i].itemContainer.GetDataItem12().Xcord, avionList[i].itemContainer.GetDataItem12().Ycord, Convert.ToInt32(avionList[i].itemContainer.GetDataItem2().time), true));
                    simulacion.Add(address, plane);
                }
                else
                {
                    simulacion[address].AddPosition(new Position(avionList[i].itemContainer.GetDataItem12().Xcord, avionList[i].itemContainer.GetDataItem12().Ycord, Convert.ToInt32(simulacion[address].positionList[simulacion[address].positionList.Count-1].Time)+4, true));
                }
            };

            /*simulacion = new List<Avion>();
            List<string> PLANES = new List<string>();
            
            totaltime = Convert.ToInt32(avionList[avionList.Count - 1].itemContainer.GetDataItem2().time) - Convert.ToInt32(avionList[0].itemContainer.GetDataItem2().time);

            PLANES.Add(avionList[0].itemContainer.GetDataItem8().AircraftAddress);

            for (int i  = 0; i < avionList.Count; i++) {
                bool found = false;
                for (int j = 0; j < PLANES.Count; j++)
                {
                    string address = avionList[i].itemContainer.GetDataItem8().AircraftAddress;
                    string planestring = PLANES[j];
                    if (avionList[i].itemContainer.GetDataItem8().AircraftAddress == PLANES[j])
                    {
                        found = true;
                        //Avion plane = new Avion(avionList[i].itemContainer.GetDataItem8().AircraftAddress);
                        //simulacion.Add(plane);
                        break;
                    }
                    else if (avionList[i].itemContainer.GetDataItem8().AircraftAddress == null)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                }
                if (found == false)
                {
                    PLANES.Add(avionList[i].itemContainer.GetDataItem8().AircraftAddress);
                }
                
            }

            for (int i = 0; i < PLANES.Count; i++)
            {
                Avion plane = new Avion(avionList[i].itemContainer.GetDataItem8().AircraftAddress);

                for (int j = 0; j < totaltime; j++) //encontrar todas sus posiciones
                {
                    for (int k = 0; k < avionList.Count; k++)
                    {
                        if (avionList[k].itemContainer.GetDataItem8().AircraftAddress == PLANES[i])
                        {
                            plane.positionList[j] = new Position(avionList[k].itemContainer.GetDataItem12().Xcord, avionList[k].itemContainer.GetDataItem12().Ycord, Convert.ToInt32(avionList[k].itemContainer.GetDataItem2().time), true);
                        }
                        else
                        {
                            plane.positionList[j] = new Position(0, 0, j, false);
                        }
                    }

                } //no sale de este bucle REVISAR

                simulacion.Add(plane);
            }*/

        }
        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            // Actualiza la posición de los aviones para el próximo paso de la simulación
            pasoActual += 4; //% simulacion.Count;
            gmap.Overlays.Clear();
            ActivateOverlay();           
        }
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

            public void Dibujar()
            {
                
            }
        }

        public class Position
        {
            public double X { get; set; }
            public double Y { get; set; }

            public int Time { get; set; }

            public bool Draw { get; set; }

            public Position(double x, double y, int time, bool draw)
            {
                X = x;
                Y = y;
                Time = time;
                Draw = draw;

            }
        }

        private void AdvanceButton_Click(object sender, EventArgs e)
        {
            if (pasoActual <= totaltime)
            {
                pasoActual += 4; //% simulacion.Count;
                gmap.Overlays.Clear();                
                ActivateOverlay();

            }
            else {
                MessageBox.Show("Estás en el último paso, no puedes ir más alante");
            }           
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if(pasoActual > 4)
            {
                pasoActual -= 4; //% simulacion.Count;
                gmap.Overlays.Clear();                
                ActivateOverlay();
            }
            else
            {
                MessageBox.Show("Estás en el primer paso, no puedes ir más atrás");
            }            
        }

        private void ActivateOverlay()
        {
            GMap.NET.WindowsForms.GMapOverlay overlay = new GMap.NET.WindowsForms.GMapOverlay("Aviones");
            // Dibuja los aviones en el PictureBox

            int i = 0;
            int offset = 4;

            foreach(Avion avion in simulacion.Values)
            {
                for (int j = 0; j < avion.positionList.Count; j++)
                {
                    if ((avion.positionList[j].Time - initialTime) <= pasoActual && (avion.positionList[j].Time - initialTime) >= initialTime)
                    {
                        if (!((avion.positionList[j].Time - initialTime) <= pasoActual && (avion.positionList[j].Time - initialTime) >= (pasoActual - offset)))
                        {
                            GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(avion.positionList[j].X, avion.positionList[j].Y);
                            // Crear un marcador
                            GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                            {
                                ToolTipText = avion.Name
                            };
                            overlay.Markers.Add(marcador);
                            break;
                        }
                    }
                    if ((avion.positionList[j].Time - initialTime) <= pasoActual && (avion.positionList[j].Time - initialTime) >= (pasoActual - offset))
                    {
                        GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(avion.positionList[j].X, avion.positionList[j].Y);
                        // Crear un marcador
                        GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                        {
                            ToolTipText = avion.Name
                        };
                        overlay.Markers.Add(marcador);
                        break;
                    }
                }

                i++;
            }
            /*
            foreach (var avion in simulacion.Values)
            {
                foreach(var position in avion.positionList)
                {
                    if ((position.Time - initialTime) <= pasoActual && (position.Time - initialTime) > pasoActual - 8)
                    {
                        if ((position.Time - initialTime) <= pasoActual && (position.Time - initialTime) > pasoActual - 4)
                        {
                            GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(position.X, position.Y);
                            // Crear un marcador
                            GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                            {
                                ToolTipText = avion.Name
                            };
                            overlay.Markers.Add(marcador);
                            break;
                        }                       
                    }
                    if ((position.Time - initialTime) <= pasoActual && (position.Time-initialTime) > pasoActual - 4)
                    {
                        GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(position.X, position.Y);
                        // Crear un marcador
                        GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red)
                        {
                            ToolTipText = avion.Name
                        };
                        overlay.Markers.Add(marcador);
                        break;
                    }                              
                }                
            }
            */

            // Añadir el marcador al mapa                       
            gmap.Overlays.Add(overlay);
            gmap.Position = new GMap.NET.PointLatLng(41.38879, 2.15899);
            gmap.Update();           
        }

        private void InitSim_Click(object sender, EventArgs e)
        {
            // Inicia un temporizador para actualizar la simulación en intervalos regulares
            timerSimulacion.Interval = 100; // Ajusta el intervalo según tus necesidades
            timerSimulacion.Tick += TimerSimulacion_Tick;
            timerSimulacion.Start();

        }

        private void StopSimulation_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
        }
    }
}
