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
        private List<List<Avion>> simulacion;
        private int pasoActual;
        public Timer timerSimulacion = new Timer();
        public GMap.NET.WindowsForms.GMapControl gmap;
        public SimulationForm()
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
            InicializarSimulacion();
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
        private void InicializarSimulacion()
        {
            simulacion = new List<List<Avion>>();

            // Agrega algunos aviones a la simulación
            simulacion.Add(new List<Avion>
            {
                new Avion(40.5, -2,"Avion 1"),
                new Avion(40.6235, -2.456, "Avion 2"),
                new Avion(41.6239, -1.4657, "Avion 3")
                // Agrega más aviones según sea necesario
            });

            // Puedes seguir añadiendo más listas con la información de cada paso de la simulación
            // simulacion.Add(new List<Avion> { /* ... */ });
        }
        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            // Actualiza la posición de los aviones para el próximo paso de la simulación
            pasoActual = (pasoActual + 1) % simulacion.Count;        }
        public class Avion
        {
            public double X { get; set; }
            public double Y { get; set; }

            public string Name { get; set; }

            public Avion(double x, double y, string name)
            {
                X = x;
                Y = y;
                Name = name;
            }

            public void Dibujar()
            {
                
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
            }
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
