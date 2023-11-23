using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPGTA_P2
{
    public partial class SimulationForm : Form
    {
        private List<Avion> simulacion;
        private int pasoActual;
        public Timer timerSimulacion = new Timer();
        public GMap.NET.WindowsForms.GMapControl gmap;
        public SimulationForm(List<CAT48> avionList)
        {
            InitializeComponent();
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
            simulacion = new List<Avion>();

            int totaltime = Convert.ToInt32(avionList[avionList.Count - 1].itemContainer.GetDataItem2().time) - Convert.ToInt32(avionList[0].itemContainer.GetDataItem2().time);

            /*
            for (int i = 0; i < avionList.Count; i++) //iterar sobre todos los aviones
            {
                for (int j = 0; j < simulacion.Count; j++) //iterar sobre la lista de simulación
                {
                    if (avionList[i].itemContainer.GetDataItem8().AircraftAddress != simulacion[j].Name) //comprobar si ya está incluido el avión
                    {
                        Avion plane = new Avion(avionList[i].itemContainer.GetDataItem8().AircraftAddress); //crear nuevo objeto avión

                        //esto probablemente podria ir fuera
                        for (int k = 0; k < totaltime; k++) //alomejor deberiamos analizar cada 4s
                        {
                            for (int l = 0; l < avionList.Count; l++) //buscar todas las posiciones del avión
                            {
                                if (avionList[l].itemContainer.GetDataItem2().time == k) //si hay una linea con el mismo time entonces creamos esa posición en el avión
                                {
                                    new Position(avionList[l].itemContainer.GetDataItem12().Xcord, avionList[l].itemContainer.GetDataItem12().Ycord, k, true);
                                    new Position(avionList[l].itemContainer.GetDataItem12().Xcord, avionList[l].itemContainer.GetDataItem12().Ycord, k+1, true);
                                    new Position(avionList[l].itemContainer.GetDataItem12().Xcord, avionList[l].itemContainer.GetDataItem12().Ycord, k+2, true);
                                    new Position(avionList[l].itemContainer.GetDataItem12().Xcord, avionList[l].itemContainer.GetDataItem12().Ycord, k+3, true);
                                }
                                else //si no hay un report de posición a esa hora, creamos una posición vacía con draw false
                                {
                                    new Position(0, 0, k, false);
                                }
                            }

                        }

                        simulacion.Add( plane );
                    }
                }
                
            }
            */

            // Agrega algunos aviones a la simulación
            /*simulacion.Add(new List<Avion>
            {
                
                // Agrega más aviones según sea necesario
            });*/

            // Puedes seguir añadiendo más listas con la información de cada paso de la simulación
            // simulacion.Add(new List<Avion> { /* ... */ });
        }
        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            // Actualiza la posición de los aviones para el próximo paso de la simulación
            pasoActual = (pasoActual + 1); //% simulacion.Count;
        }
        public class Avion
        {
            public Position[] positionList;

            public string Name { get; set; }

            public Avion(string name)
            {
                this.Name = name;
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

        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {

        }

        private void ActivateOverlay()
        {
            // Dibuja los aviones en el PictureBox
            /*
            foreach (var avion in simulacion[pasoActual])
            {
                GMap.NET.PointLatLng posicion = new GMap.NET.PointLatLng(avion.X, avion.Y);
                // Crear un marcador
                GMap.NET.WindowsForms.Markers.GMarkerGoogle marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(posicion, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red); ;
                marcador.ToolTipText = avion.Name;

                // Añadir el marcador al mapa
                GMap.NET.WindowsForms.GMapOverlay overlay = new GMap.NET.WindowsForms.GMapOverlay("Aviones");
                overlay.Markers.Add(marcador);
                gmap.Overlays.Add(overlay);
            }*/
        }

        private void InitSim_Click(object sender, EventArgs e)
        {
            // Inicia un temporizador para actualizar la simulación en intervalos regulares
            timerSimulacion.Interval = 1000; // Ajusta el intervalo según tus necesidades
            timerSimulacion.Tick += TimerSimulacion_Tick;
            timerSimulacion.Start();
        }
    }
}
