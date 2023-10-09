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
        public bool Item1 = false;
        public bool Item2 = false;
        public bool Item3 = false;
        public bool Item4 = false;
        public bool Item5 = false;
        public bool Item6 = false;
        public bool Item7 = false;
        public bool Item8 = false;
        public bool Item9 = false;
        public bool Item10 = false;
        public bool Item11 = false;
        public bool Item12 = false;
        public bool Item13 = false;
        public bool Item14 = false;
        public bool Item15 = false;
        public bool Item16 = false;
        public bool Item17 = false;
        public bool Item18 = false;
        public bool Item19 = false;
        public bool Item20 = false;
        public bool Item21 = false;
        public bool Item22 = false;
        public bool Item23 = false;
        public bool Item24 = false;
        public bool Item25 = false;
        public bool Item26 = false;
        public bool Item27 = false;
        public bool Item28 = false;

        
        public CAT48(string[] arrayhex)
        {
            this.arrayHex = arrayhex;
            this.CAT = int.Parse(arrayHex[0], System.Globalization.NumberStyles.HexNumber);
            this.Length = int.Parse(arrayHex[1]+arrayHex[2], System.Globalization.NumberStyles.HexNumber);
            int i = 3;
            bool finishFSPEC = false;
            while (i < arrayHex.Length)
            {
                string hexByte = arrayHex[i];
                string binaryByte = Convert.ToString(Convert.ToInt32(hexByte, 16), 2).PadLeft(8, '0');
                
                if (i==3 && finishFSPEC == false)
                {
                    int n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n == 0)
                            {
                                this.Item1 = true;
                            }else if (n == 1)
                            {
                                this.Item2 = true;
                            }
                            else if (n == 2)
                            {
                                this.Item3 = true;
                            }
                            else if (n == 3)
                            {
                                this.Item4 = true;
                            }
                            else if (n == 4)
                            {
                                this.Item5 = true;
                            }
                            else if (n == 5)
                            {
                                this.Item6 = true;
                            }
                            else if (n == 6)
                            {
                                this.Item7 = true;
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
                if (i == 4 && finishFSPEC == false)
                {
                    int n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n == 0)
                            {
                                this.Item8 = true;
                            }
                            else if (n == 1)
                            {
                                this.Item9 = true;
                            }
                            else if (n == 2)
                            {
                                this.Item10 = true;
                            }
                            else if (n == 3)
                            {
                                this.Item11 = true;
                            }
                            else if (n == 4)
                            {
                                this.Item12 = true;
                            }
                            else if (n == 5)
                            {
                                this.Item13 = true;
                            }
                            else if (n == 6)
                            {
                                this.Item14 = true;
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
                if (i == 5 && finishFSPEC == false)
                {
                    int n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n == 0)
                            {
                                this.Item15 = true;
                            }
                            else if (n == 1)
                            {
                                this.Item16 = true;
                            }
                            else if (n == 2)
                            {
                                this.Item17 = true;
                            }
                            else if (n == 3)
                            {
                                this.Item18 = true;
                            }
                            else if (n == 4)
                            {
                                this.Item19 = true;
                            }
                            else if (n == 5)
                            {
                                this.Item20 = true;
                            }
                            else if (n == 6)
                            {
                                this.Item21 = true;
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
                if (i == 6 && finishFSPEC == false)
                {
                    int n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n == 0)
                            {
                                this.Item22 = true;
                            }
                            else if (n == 1)
                            {
                                this.Item23 = true;
                            }
                            else if (n == 2)
                            {
                                this.Item24 = true;
                            }
                            else if (n == 3)
                            {
                                this.Item25 = true;
                            }
                            else if (n == 4)
                            {
                                this.Item26 = true;
                            }
                            else if (n == 5)
                            {
                                this.Item27 = true;
                            }
                            else if (n == 6)
                            {
                                this.Item28 = true;
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
