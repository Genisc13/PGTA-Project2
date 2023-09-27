using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;


namespace LibreriaClases
{
    public class Fichero
    {
        string path;
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT20> listaCAT20 = new List<CAT20>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT20 = new DataTable();
        DataTable tablaCAT21 = new DataTable();


        public Fichero(string nombre)
        {
            this.path = nombre;
        }

        public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }
        public List<CAT20> getListCAT20()
        {
            return listaCAT20;
        }
        public List<CAT21> getListCAT21()
        {
            return listaCAT21;
        }

        public void leer()
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
                if (i + 2 < fileBytes.Length) //??
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
                string[] arraystring = listahex[q]; //Cada linea en hex
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber); //Convertir cada par de valores hex a un decimal

                //Filtrar por valor decimal en distintas categorias ordenadas por listas 10, 20 y 21
                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring);
                    listaCAT10.Add(newcat10);
                }
                else if (CAT == 20)
                {
                    CAT20 newcat20 = new CAT20(arraystring);
                    listaCAT20.Add(newcat20);
                }
                else if (CAT == 21)
                {
                    CAT21 newcat21 = new CAT21(arraystring);
                    listaCAT21.Add(newcat21);
                }
            }
            

        }

        public DataTable getTablaCAT10()
        {
            return tablaCAT10;
        }
        public DataTable getTablaCAT20()
        {
            return tablaCAT20;
        }
        public DataTable getTablaCAT21()
        {
            return tablaCAT21;
        }
    }
}
