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
                MessageBox.Show("The ASTERIX file was decoded correctly");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OpenSimButton_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                SimulationForm simulationForm = new SimulationForm(lista);
                simulationForm.Show();
            }
            else
            {
                MessageBox.Show("No has hecho ninguna decodificación aún");
            }

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                ofd.SelectedPath = "..\\";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.SelectedPath;
                    // Crear un StringBuilder para almacenar el contenido CSV
                    StringBuilder csvContent = new StringBuilder();
                    csvContent.AppendLine("NUM;SAC;SIC;TIME;SEC;TYP;SIM;RDP;SPI;RAB;TST;ERR;XPP;ME;MI;FOE/FRI;ADSB_EP;ADSB_VAL;SCN_EP;SCN_VAL;PAI_EP;PAI_VAL;RHO;THETA;V;G;L;MODE3;V;G;FL;SRL;SRR;SAM;PRL;PAM;RPD;APD;A/C ADDRESS;A/C IDENTIFICATION;BDS VERSION;REPETITIONS;MCP/FCU SELECTED ALTITUDE;FMS SELECTED ALTITUDE;BAROMETRIC PRESSURE SETTING;STATUS OF MCP/FCU MODE;VNAV MODE;ALT HOLD MODE;APP MODE;STATUS OF TARGET ALTITUDE SOURCE;TARGET ALTITUDE SOURCE;ROLL ANGLE;TRUE TRACK ANGLE;GS;TRACK ANGLE RATE;TAS;MAGNETIC HEADING;IAS;MACH;BAROMETRIC ALTITUDE RATE;INERTIAL VERTICAL VELOCITY;TRACK NUMBER;X;Y;Z;GS;HEADING;CNF;RAD;DOU;MAH;CDM;TRE;GHO;SUP;TCC;3D HEIGHT;COM;STAT;SI;MSSC;ARC;AIC;B1A;B1B");

                    int i = 1;

                    foreach (CAT48 items in lista)
                    {
                        Dictionary<int, List<string>> datos = items.GetDataDecodedPerItem();
                        StringBuilder rowDataBuilder = new StringBuilder();
                        // Itera a través de los datos y agrega cada fila al contenido CSV

                        rowDataBuilder.Append(i.ToString());
                        rowDataBuilder.Append(";");


                        foreach (var kvp in datos)
                        {
                            if (kvp.Key >= 1 && kvp.Key <= 28)
                            {
                                //rowDataBuilder.Append("DataItem: " + kvp.Key);


                                foreach (string value in kvp.Value)
                                {
                                    //rowDataBuilder.Append(";");
                                    if (value.Contains(","))
                                    {
                                        rowDataBuilder.Append(value.Replace(",", "."));
                                    }
                                    else
                                    {
                                        rowDataBuilder.Append(value);
                                    }
                                    rowDataBuilder.Append(";");
                                }

                            }
                        }
                        string rowData = rowDataBuilder.ToString();
                        csvContent.AppendLine(rowData);
                        i++;
                    }

                    // Guarda el contenido en un archivo CSV
                    File.WriteAllText(filePath + "\\"+ "DecodedASTERIXData.csv", csvContent.ToString());

                    // Muestra un mensaje de confirmación
                    MessageBox.Show("Archivo CSV generado exitosamente." + filePath + "\\" + "DecodedASTERIXData.csv");

                }
            }
            else
            {
                MessageBox.Show("No has hecho ninguna decodificación aún");
            }          
        }

        private void ShowCSVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                CargarCSV(filePath);
            }
        }
        private void CargarCSV(string filePath)
        {
            try
            {
                // Lee todo el contenido del archivo CSV
                string[] lines = File.ReadAllLines(filePath);

                // Divide las líneas en columnas y carga los datos en el DataGridView
                dataGridView1.ColumnCount = lines[0].Split(';').Length;
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(';');
                    dataGridView1.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
