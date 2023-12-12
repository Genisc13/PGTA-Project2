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
        /// <summary>
        /// This Button (The decode button) will be used to open a file browser
        /// and decode any .ast and process all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //The initial directory
            ofd.InitialDirectory ="..\\";
            //The filter
            ofd.Filter = "Asterix Files (*.ast*)|*.ast|All files (*.*)|*.";
            //The filter Index
            ofd.FilterIndex = 1;
            //The option of RestoreDirectory at true
            ofd.RestoreDirectory = true;
            //If the OpenFile is a success the next code will be done
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                //We create a Reader that reads the file and starts de decoding
                decoder = new Reader(filePath);
                lista = decoder.GetListCAT48();
                MessageBox.Show("ASTERIX file decoded succesfully!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //If the DataGridView is clicked nothing happens
        }
        /// <summary>
        /// This button opens the Simulation Form, this one will only be
        /// shown if the data is decoded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSimButton_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                SimulationForm simulationForm = new SimulationForm(lista);
                simulationForm.Show();
            }
            else
            {
                MessageBox.Show("No ASTERIX file decoded yet");
            }

        }
        /// <summary>
        /// This button exports the ASTERIX decoded data on
        /// a .csv and can be exported on a directory of choice
        /// The CSV file contains data of one packet per row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                ofd.SelectedPath = "..\\";
                //If the folder browser is OK the next code is done
                if (ofd.ShowDialog() == DialogResult.OK)
                {                  
                    string filePath = ofd.SelectedPath;                  
                    // Create a StringBuilder to store the CSV content
                    StringBuilder csvContent = new StringBuilder();
                    //Here the CSV content is written string by string
                    csvContent.AppendLine("NUM;SAC;SIC;TIME;SEC;TYP;SIM;RDP;SPI;RAB;TST;ERR;XPP;ME;MI;FOE/FRI;ADSB_EP;ADSB_VAL;SCN_EP;SCN_VAL;PAI_EP;PAI_VAL;RHO;THETA;V;G;L;MODE3;V;G;FL;SRL;SRR;SAM;PRL;PAM;RPD;APD;A/C ADDRESS;A/C IDENTIFICATION;BDS VERSION;REPETITIONS;MCP/FCU SELECTED ALTITUDE;FMS SELECTED ALTITUDE;BAROMETRIC PRESSURE SETTING;STATUS OF MCP/FCU MODE;VNAV MODE;ALT HOLD MODE;APP MODE;STATUS OF TARGET ALTITUDE SOURCE;TARGET ALTITUDE SOURCE;ROLL ANGLE;TRUE TRACK ANGLE;GS;TRACK ANGLE RATE;TAS;MAGNETIC HEADING;IAS;MACH;BAROMETRIC ALTITUDE RATE;INERTIAL VERTICAL VELOCITY;TRACK NUMBER;X;Y;Z;GS;HEADING;CNF;RAD;DOU;MAH;CDM;TRE;GHO;SUP;TCC;3D HEIGHT;COM;STAT;SI;MSSC;ARC;AIC;B1A;B1B");

                    int i = 1;

                    foreach (CAT48 items in lista)
                    {
                        Dictionary<int, List<string>> datos = items.GetDataDecodedPerItem();
                        StringBuilder rowDataBuilder = new StringBuilder();
                        // Iterates on the data and agregates every row at the CSV content 
                        rowDataBuilder.Append(i.ToString());
                        rowDataBuilder.Append(";");
                        foreach (var kvp in datos)
                        {
                            if (kvp.Key >= 1 && kvp.Key <= 28)
                            {
                                foreach (string value in kvp.Value)
                                {
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
                    // Save the complete content on a .csv file
                    File.WriteAllText(filePath + "\\"+ "DecodedASTERIXData.csv", csvContent.ToString());

                    // Shows a confirmation message
                    MessageBox.Show("CSV file succesfully generated: " + filePath + "\\" + "DecodedASTERIXData.csv");

                }
            }
            else
            {
                MessageBox.Show("No ASTERIX file decoded yet");
            }          
        }
        /// <summary>
        /// This function was made to be able to show the CSV data on the Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCSVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                LoadCSV(filePath);
            }
        }
 
        /// <summary>
        /// This function reads the CSV data and transforms it into columns
        /// and rows of the DataGridView
        /// </summary>
        /// <param name="filePath"></param>
        private void LoadCSV(string filePath)
        {
            try
            {
                //Reads all the content of the CSV file
                string[] lines = File.ReadAllLines(filePath);
                // Divides the lines on columns and loads the DataGridView Data
                dataGridView1.ColumnCount = lines[0].Split(';').Length;
                for (int i = 0; i < 100; i++)
                {
                    string[] values = lines[i].Split(';');
                    dataGridView1.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed loading CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
