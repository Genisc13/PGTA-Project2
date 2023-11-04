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
            ofd.Filter = "All files (*.*)|*.*";
            //ofd.FilterIndex = 2;
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

                    // Itera a través de los datos y agrega cada fila al contenido CSV
                    foreach (var kvp in datos)
                    {
                        if (kvp.Key >= 1 && kvp.Key <= 28)
                        {
                            string rowData = string.Join(",", kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2]);
                            csvContent.AppendLine(rowData);
                        }
                    }
                }

                // Guarda el contenido en un archivo CSV
                File.WriteAllText(filePath + "Data.csv", csvContent.ToString());

                // Muestra un mensaje de confirmación
                MessageBox.Show("Archivo CSV generado exitosamente." + filePath + "Data.csv");
            }
            /*if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                decoder = new Reader(filePath);
                lista = decoder.GetListCAT48();
                dataGridView1.Rows.Clear();
                Console.WriteLine("Las CAT48 que hay son: "+lista.Count());
                dataGridView1.ColumnCount = lista.Count();
                foreach (CAT48 items in lista)
                {
                    // Supongamos que tienes un diccionario llamado 'datos'
                    Dictionary<int, List<string>> datos = items.GetDataDecodedPerItem();

                    // Agrega las filas con datos desde el diccionario
                    foreach (var kvp in datos)
                    {
                        if (kvp.Key == 1)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 2)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 3)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 4)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 5)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 6)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 7)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 8)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 9)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 10)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 11)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 12)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 13)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 14)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 15)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 16)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 17)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 18)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 19)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 20)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 21)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 22)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 23)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 24)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 25)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 26)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 27)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 28)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                        if (kvp.Key == 1)
                        {
                            dataGridView1.Rows.Add(new object[] { kvp.Key, kvp.Value[0], kvp.Value[1], kvp.Value[2] });
                        }
                    }
                }
            }*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
