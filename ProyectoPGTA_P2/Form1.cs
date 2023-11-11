using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPGTA_P2
{
    public partial class Form1 : Form
    {
        public Reader decoder;
        public List<CAT48> lista;
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory ="..\\";
            ofd.Filter = "Asterix Files (*.ast*)|*.ast|All files (*.*)|*.";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                decoder = new Reader(filePath);
                lista = decoder.GetListCAT48();
                Console.WriteLine("Las CAT48 que hay son: " + lista.Count());

                // Crear un StringBuilder para almacenar el contenido CSV
                StringBuilder csvContent = new StringBuilder();

                foreach (CAT48 items in lista)
                {
                    Dictionary<int, List<string>> datos = items.GetDataDecodedPerItem();
                    StringBuilder rowDataBuilder = new StringBuilder();
                    // Itera a través de los datos y agrega cada fila al contenido CSV
                    int i = 1;
                    rowDataBuilder.Append(i.ToString());
                    foreach (var kvp in datos)
                    {
                        if (kvp.Key >= 1 && kvp.Key <= 28)
                        {
                            rowDataBuilder.Append("DataItem: " + kvp.Key);

                            foreach (string value in kvp.Value)
                            {
                                rowDataBuilder.Append(";");
                                if (value.Contains(","))
                                {
                                    rowDataBuilder.Append(value.Replace(",","."));
                                }
                                else
                                {
                                    rowDataBuilder.Append(value);
                                } 
                            }
                            rowDataBuilder.Append(";");
                        }
                    }
                    string rowData = rowDataBuilder.ToString();
                    csvContent.AppendLine(rowData);
                }

                // Guarda el contenido en un archivo CSV
                File.WriteAllText(filePath + "Data.txt", csvContent.ToString());

                // Muestra un mensaje de confirmación
                MessageBox.Show("Archivo CSV generado exitosamente." + filePath + "Data.csv");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
