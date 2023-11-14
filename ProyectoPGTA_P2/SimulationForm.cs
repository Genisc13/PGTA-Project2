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
        public SimulationForm()
        {
            InitializeComponent();

            InicializarSimulacion();
            
        }
        private void InicializarSimulacion()
        {
            simulacion = new List<List<Avion>>();

            // Agrega algunos aviones a la simulación
            simulacion.Add(new List<Avion>
            {
                new Avion(100, 150),
                new Avion(200, 300),
                // Agrega más aviones según sea necesario
            });

            // Puedes seguir añadiendo más listas con la información de cada paso de la simulación
            // simulacion.Add(new List<Avion> { /* ... */ });
        }
        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            // Actualiza la posición de los aviones para el próximo paso de la simulación
            pasoActual = (pasoActual + 1) % simulacion.Count;
            pictureBoxMap.Invalidate(); // Vuelve a dibujar el mapa con la nueva posición de los aviones
        }
        private void PictureBoxMapa_Paint(object sender, PaintEventArgs e)
        {
            // Dibuja los aviones en el PictureBox
            foreach (var avion in simulacion[pasoActual])
            {
                avion.Dibujar(e.Graphics);
            }
        }
        public class Avion
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Avion(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Dibujar(Graphics g)
            {
                // Dibuja el avión en la posición actual
                g.FillEllipse(Brushes.Red, X, Y, 10, 10);
                // Puedes personalizar el dibujo del avión según tus necesidades
            }
        }

        private void AdvanceButton_Click(object sender, EventArgs e)
        {

        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            // Dibuja los aviones en el PictureBox
            foreach (var avion in simulacion[pasoActual])
            {
                avion.Dibujar(e.Graphics);
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
