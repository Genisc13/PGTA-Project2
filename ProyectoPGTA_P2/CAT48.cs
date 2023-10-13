using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPGTA_P2
{
    public class CAT48
    {
        public List<string> arrayHex;
        public int CAT;
        public int Length;
        public bool[] items;

        
        public CAT48(List<string> arrayhex)
        {
            this.arrayHex = arrayhex;
            this.CAT = int.Parse(arrayHex[0], System.Globalization.NumberStyles.HexNumber);
            this.Length = int.Parse(arrayHex[1]+arrayHex[2], System.Globalization.NumberStyles.HexNumber);
            this.items = new bool[28];
            int i = 3;
            
            bool finishFSPEC = false;
            while (i < arrayHex.Count)
            {
                int n;
                string hexByte = arrayHex[i];
                string binaryByte = Convert.ToString(Convert.ToInt32(hexByte, 16), 2).PadLeft(8, '0');
                
                if (i>=3 && i<=6  && finishFSPEC == false)
                {
                    n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n >= 0 && n <= 6 )
                            {
                                if (i == 3)
                                {
                                    this.items[n] = true;
                                }else if (i == 4)
                                {
                                    this.items[n+7] = true;
                                }else if (i== 5)
                                {
                                    this.items[n + 14] = true;
                                }else if (i == 6)
                                {
                                    this.items[n + 21] = true;
                                }
                                
                            }
                            else if (n == 7)
                            {
                                finishFSPEC = true;
                            }     
                        }                        
                        i++;                        
                    }
                }
                //Item 1
                if (items[0] == true)
                {
                    List<string> arrayItem = new List<string>(); ;
                    arrayItem.Add(arrayHex[i]);
                    arrayItem.Add(arrayHex[i + 1]);
                    new DataItem1(arrayItem);
                    i+=2;
                    items[0] = false;
                    continue;
                }
                //Item 2
                else if (items[1] == true)
                {
                    List<string> arrayItem = new List<string>(3);
                    arrayItem[0] = arrayHex[i];
                    arrayItem[1] = arrayHex[i + 1];
                    arrayItem[2] = arrayHex[i + 2];
                    new DataItem2(arrayItem);
                    i += 3;
                    items[1] = false;
                    continue;
                }
                //Item 3
                else if (items[2] == true)
                {
                    List<string> arrayItem = new List<string>();
                    if (binaryByte[7].Equals("1"))
                    {
                        arrayItem.Add(arrayHex[i]);
                        i++;
                        continue;
                    }
                    else
                    {
                        arrayItem.Add(arrayHex[i]);
                        i++;
                        new DataItem3(arrayItem);
                        items[2] = false;
                        continue;
                    }
                }
                //Item 4
                else if (items[3] == true)
                {
                    List<string> arrayItem = new List<string>(); ;
                    arrayItem.Add(arrayHex[i]);
                    arrayItem.Add(arrayHex[i + 1]);
                    arrayItem.Add(arrayHex[i + 2]);
                    arrayItem.Add(arrayHex[i + 3]);
                    new DataItem4(arrayItem);
                    i += 4;
                    items[3] = false;
                    continue;
                }
                //Item 5
                else if (items[4] == true)
                {

                }
                //Item 6
                else if (items[5] == true)
                {

                }
                //Item 7
                else if (items[6] == true)
                {

                }
                //Item 8
                else if (items[7] == true)
                {

                }
                //Item 9
                else if (items[8] == true)
                {

                }
                //Item 10
                else if (items[9] == true)
                {

                }
                //Item 11
                else if (items[10] == true)
                {

                }
                //Item 12
                else if (items[11] == true)
                {

                }
                //Item 13
                else if (items[12] == true)
                {

                }
                //Item 14
                else if (items[13] == true)
                {

                }
                //Item 15
                else if (items[14] == true)
                {

                }
                //Item 16
                else if (items[15] == true)
                {

                }
                //Item 17
                else if (items[16] == true)
                {

                }
                //Item 18
                else if (items[17] == true)
                {

                }
                //Item 19
                else if (items[18] == true)
                {

                }
                //Item 20
                else if (items[19] == true)
                {

                }
                //Item 21
                else if (items[20] == true)
                {

                }
                //Item 22
                else if (items[21] == true)
                {

                }
                //Item 23
                else if (items[22] == true)
                {

                }
                //Item 24
                else if (items[23] == true)
                {

                }
                //Item 25
                else if (items[24] == true)
                {

                }
                //Item 26
                else if (items[25] == true)
                {

                }
                //Item 27
                else if (items[26] == true)
                {

                }
                //Item 28
                else if (items[27] == true)
                {

                }
            }
        }
    }
}
