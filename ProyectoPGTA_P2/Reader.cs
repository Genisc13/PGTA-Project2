using System.Collections.Generic;
using System.Data;
using System.IO;


namespace ProyectoPGTA_P2
{
    public class Reader
    {
        string path;
        //List of all the CAT48 packets
        private List<CAT48> listaCAT48 = new List<CAT48>();
        private DataTable tablaCAT48 = new DataTable();
        /// <summary>
        /// The reader takes the path of the .ast file and decodes 
        /// it with the leer fucntion 
        /// </summary>
        /// <param name="nombre"></param>
        public Reader(string nombre)
        {
            this.path = nombre;
            this.Leer();
        }
        /// <summary>
        /// This is a getter of listaCAT48
        /// </summary>
        /// <returns></returns>
        public List<CAT48> GetListCAT48()
        {
            return this.listaCAT48;
        }
        /// <summary>
        /// This function takes all the Bytes of the 
        /// binary .ast file and decodes it using the
        /// CAT48 class and the dataItems
        /// </summary>
        public void Leer()
        {
            //StreamReader fichero = new StreamReader(path);
            //string linea_1 = fichero.ReadLine();
            byte[] fileBytes = File.ReadAllBytes(path); //We convert the entire file to 8-bit arrays placed in a one-row matrix

            List<byte[]> listabyte = new List<byte[]>(); //New empty byte array list
            int i = 0; //We place the i in the first byte of the file
            int contador = fileBytes[2]; //contador = to the second byte of the file, determines the length of the line in the bytelist

            while (i < fileBytes.Length) //Break it down into small byte arrays (to figure out the size) and put them in a list
            {
                byte[] array = new byte[contador]; //Array = new byte array equal to the length of the 2nd byte of the file
                for (int j = 0; j < array.Length;) //It fills the array with the bytes of the binary file until the array is completely filled.
                {
                    array[j] = fileBytes[i];
                    i++;
                    j++;
                }
                listabyte.Add(array); //Add array to byte list
                //length += array.Length;
                if (i + 2 < fileBytes.Length) //once the length is known and the entire first message is passed, it skips to the next one to continue 
                {
                    contador = fileBytes[i + 2]; //Determines the length of the next byte array or length of the next entry in the bytelist list
                }
            }

            List<string[]> listahex = new List<string[]>(); //New list of string arrays. bytelist in hex format

            for (int x = 0; x < listabyte.Count; x++) //Loop to convert each bytelist entry to a hex value
            {
                byte[] buffer = listabyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    arrayhex[y] = buffer[y].ToString("X");
                }
                listahex.Add(arrayhex);
            }


            for (int q = 0; q < listahex.Count; q++) //Iterate over entire list of bytes in hex
            {
                List<string> arraystring = new List<string>(listahex[q].Length); //Every line in hex
                for (int k = 0; k < listahex[q].Length; k++)
                {
                    arraystring.Add(listahex[q][k]);
                }
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber); //Convert each pair of hex values to a decimal
                //Filter by decimal value in different categories ordered by lists 10, 20 and 21
                if (CAT == 48)
                {
                    CAT48 newcat10 = new CAT48(arraystring);

                    bool ADD = false;

                    string Mode3 = newcat10.itemContainer.GetDataItem3().TYP;
                    
                    //Check modeS
                    if (Mode3 == "Single ModeS All-Call" || Mode3 == "Single ModeS Roll-Call" || Mode3 == "ModeS All-Call + PSR" || Mode3 == "ModeS Roll-Call + PSR")
                    {
                        //Check aircraft airborne
                        int stat = newcat10.itemContainer.GetDataItem21().statINT;

                        if (stat == 0 || stat == 2 || stat == 4 || stat == 5)
                        {
                            //Check lat and long in a certain range
                            double lat = newcat10.itemContainer.GetDataItem12().Xcord;
                            
                            if ( lat > 40.9 && lat < 41.7)
                            {
                                double lon = newcat10.itemContainer.GetDataItem12().Ycord;

                                if (lon > 1.5 && lon < 2.6)
                                {
                                    ADD = true;
                                }
                            }
                        }
                    }

                    if (ADD == true)
                    {
                        listaCAT48.Add(newcat10); //Only add if it is Mode S Call
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
