using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPGTA_P2
{
    public class CAT48
    {
        public string[] arrayHex;
        public int CAT;
        public int Length;
        public bool[] items;

        
        public CAT48(string[] arrayhex)
        {
            this.arrayHex = arrayhex;
            this.CAT = int.Parse(arrayHex[0], System.Globalization.NumberStyles.HexNumber);
            this.Length = int.Parse(arrayHex[1]+arrayHex[2], System.Globalization.NumberStyles.HexNumber);
            this.items = new bool[28];
            int i = 3;
            bool finishFSPEC = false;
            while (i < arrayHex.Length)
            {
                string hexByte = arrayHex[i];
                string binaryByte = Convert.ToString(Convert.ToInt32(hexByte, 16), 2).PadLeft(8, '0');
                
                if (i>=3 && i<=6  && finishFSPEC == false)
                {
                    int n = 0;
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
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
