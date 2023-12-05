using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;


namespace ProyectoPGTA_P2
{
    public class Reader
    {
        string path;

        private List<CAT48> listaCAT48 = new List<CAT48>();
        private DataTable tablaCAT48 = new DataTable();

        public Reader(string nombre)
        {
            this.path = nombre;
            this.Leer();
        }
        public List<CAT48> GetListCAT48()
        {
            return this.listaCAT48;
        }
        public void Leer()
        {
            //StreamReader fichero = new StreamReader(path);
            //string linea_1 = fichero.ReadLine();
            byte[] fileBytes = File.ReadAllBytes(path); //Pasamos todo el fichero a conjuntos de 8 bits puestos en una matriz de una fila
            
            List<byte[]> listabyte = new List<byte[]>(); //Nueva lista de arrays de bytes vacía
            int i = 0; //Colocamos la i en el primer byte del fichero
            int contador = fileBytes[2]; //contador = al segundo byte del fichero?? Determina la longitud de la linea en la listabyte
            //int length = 0;

            while (i < fileBytes.Length) //Descomponer en pequeñas arrays de bytes (por descifrar el tamaño) y colocarlos en una lista
            {
                byte[] array = new byte[contador]; //Array = nueva array de bytes igual de larga que el 2o byte del fichero??
                for (int j = 0; j < array.Length;) //Va rellenando array con los bytes del fichero binario hasta que se llena array por completo
                {
                    array[j] = fileBytes[i];
                    i++;
                    j++;
                }
                listabyte.Add(array); //Añade array a la lista de bytes
                //length += array.Length;
                if (i + 2 < fileBytes.Length) //Básicamente, lo que ocurre es que, una vez se sabe la length y se pasa por todo el primer mensaje, se salta al siguiente para seguir
                {
                    contador = fileBytes[i + 2]; //Determina la longitud del próximo array de bytes o longitud de la siguiente entrada en la lista listabyte
                }
            }

            List<string[]> listahex = new List<string[]>(); //Nueva lista de arrays de strings. listabyte en formato hex

            for (int x = 0; x < listabyte.Count; x++) //Bucle para convertir cada entrada de la listabyte en un valor hex
            {
                byte[] buffer = listabyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    arrayhex[y] = buffer[y].ToString("X");
                }
                listahex.Add(arrayhex);
            }


            for (int q = 0; q < listahex.Count; q++) //Iterar sobre toda la lista de bytes en hex
            {
                List<string> arraystring = new List<string>(listahex[q].Length); //Cada linea en hex
                for(int k = 0; k < listahex[q].Length; k++)
                {
                    arraystring.Add(listahex[q][k]);
                }
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber); //Convertir cada par de valores hex a un decimal

                //Filtrar por valor decimal en distintas categorias ordenadas por listas 10, 20 y 21
                if (CAT == 48)
                {
                    CAT48 newcat10 = new CAT48(arraystring);

                    string Mode3 = newcat10.itemContainer.GetDataItem3().TYP;

                    if (Mode3 == "Single ModeS All-Call" || Mode3 == "Single ModeS Roll-Call" || Mode3 == "ModeS All-Call + PSR" || Mode3 == "ModeS Roll-Call + PSR") { 
                        listaCAT48.Add(newcat10); //Solo agregar si es Mode S Call
                    }
                    
                    //Console.WriteLine("Hecha una categoría");
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
