﻿using System;
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
            List<string> arrayItem3 = new List<string>();
            List<string> arrayItem14 = new List<string>();
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
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem1(arrayItem);
                    i+=2;
                    items[0] = false;
                    continue;
                }
                //Item 2
                else if (items[1] == true)
                {
                    List<string> arrayItem = new List<string>(3)
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2]
                    };
                    new DataItem2(arrayItem);
                    i += 3;
                    items[1] = false;
                    continue;
                }
                //Item 3
                else if (items[2] == true)
                {
                    arrayItem3.Add(arrayHex[i]);
                    if (binaryByte[7].Equals("1"))
                    {                        
                        i++;
                        continue;
                    }
                    else
                    {                       
                        i++;
                        new DataItem3(arrayItem3);
                        items[2] = false;
                        continue;
                    }
                }
                //Item 4
                else if (items[3] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2],
                        [3] = arrayHex[i + 3]
                    };
                    new DataItem4(arrayItem);
                    i += 4;
                    items[3] = false;
                    continue;
                }
                //Item 5
                else if (items[4] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem5(arrayItem);
                    i += 2;
                    items[4] = false;
                    continue;

                }
                //Item 6
                else if (items[5] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem6(arrayItem);
                    i += 2;
                    items[5] = false;
                    continue;

                }
                //Item 7
                else if (items[6] == true)
                {
                    List<string> arrayItem = new List<string>();
                    n = 0;
                    int count = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n].Equals("1"))
                        {
                            if (n == 7)
                            {
                                //FX
                                arrayItem.Add(arrayHex[i]);
                                n = 0;
                                continue;
                            }
                            else
                            {
                                count++;
                            }                      
                        }                        
                        n++;
                    }
                    n = 1;
                    while (n <= count)
                    {
                        arrayItem.Add(arrayHex[i+n]);
                    }
                    i+=n;
                    new DataItem7(arrayItem);
                    items[6] = false;
                    continue;
                    
                }
                //Item 8
                else if (items[7] == true)
                {
                    List<string> arrayItem = new List<string>(3)
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2]
                    };
                    new DataItem8(arrayItem);
                    i += 3;
                    items[7] = false;
                    continue;

                }
                //Item 9
                else if (items[8] == true)
                {
                    List<string> arrayItem = new List<string>(3)
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2],
                        [3] = arrayHex[i + 3],
                        [4] = arrayHex[i + 4],
                        [5] = arrayHex[i + 5],                        
                    };
                    new DataItem8(arrayItem);
                    i += 6;
                    items[8] = false;
                    continue;
                }
                //Item 10
                else if (items[9] == true)
                {
                    List<string> arrayItem = new List<string>();
                    int REP = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);                    
                    n = 0;
                    while (n <= REP*8)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                    }
                    new DataItem10(arrayItem);
                    i += REP * 8;
                    items[9] = false;
                    continue;
                }
                //Item 11
                else if (items[10] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem11(arrayItem);
                    i += 2;
                    items[10] = false;
                    continue;
                }
                //Item 12
                else if (items[11] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2],
                        [3] = arrayHex[i + 3]
                    };
                    new DataItem12(arrayItem);
                    i += 4;
                    items[11] = false;
                    continue;
                }
                //Item 13
                else if (items[12] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        [0] = arrayHex[i],
                        [1] = arrayHex[i + 1],
                        [2] = arrayHex[i + 2],
                        [3] = arrayHex[i + 3]
                    };
                    new DataItem13(arrayItem);
                    i += 4;
                    items[12] = false;
                    continue;
                }
                //Item 14
                else if (items[13] == true)
                {
                    arrayItem14.Add(arrayHex[i]);
                    if (binaryByte[7].Equals("1"))
                    {                        
                        i++;
                        continue;
                    }
                    else
                    {                        
                        i++;
                        new DataItem14(arrayItem14);
                        items[13] = false;
                        continue;
                    }
                }
                //Item 15
                else if (items[14] == true)
                {
                    i += 4;
                    items[14] = false;
                    continue;
                }
                //Item 16
                else if (items[15] == true)
                {
                    if (binaryByte[7].Equals("1"))
                    {
                        i++;
                        continue;
                    }
                    else
                    {                      
                        i++;
                        items[13] = false;
                        continue;
                    }
                }
                //Item 17
                else if (items[16] == true)
                {
                    i += 2;
                    items[16] = false;
                    continue;
                }
                //Item 18
                else if (items[17] == true)
                {
                    i += 4;
                    items[17] = false;
                    continue;
                }
                //Item 19
                else if (items[18] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem19(arrayItem);
                    i += 2;
                    items[18] = false;
                    continue;
                }
                //Item 20
                else if (items[19] == true)
                {
                    if (binaryByte[7].Equals("1"))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        i++;
                        items[19] = false;
                        continue;
                    }
                }
                //Item 21
                else if (items[20] == true)
                {
                    List<string> arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    new DataItem21(arrayItem);
                    i += 2;
                    items[20] = false;
                    continue;
                }
                //Item 22
                else if (items[21] == true)
                {
                    i += 7;
                    items[21] = false;
                    continue;
                }
                //Item 23
                else if (items[22] == true)
                {
                    i += 1;
                    items[22] = false;
                    continue;
                }
                //Item 24
                else if (items[23] == true)
                {
                    i += 2;
                    items[23] = false;
                    continue;
                }
                //Item 25
                else if (items[24] == true)
                {
                    i += 1;
                    items[24] = false;
                    continue;
                }
                //Item 26
                else if (items[25] == true)
                {
                    i += 2;
                    items[25] = false;
                    continue;
                }
                //Item 27
                else if (items[26] == true)
                {
                    List<string> arrayItem = new List<string>();
                    int length = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                    n = 0;
                    while (n < length)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                    }
                    i += n;
                    new DataItem27(arrayItem);
                    items[26] = false;
                    continue;
                }
                //Item 28
                else if (items[27] == true)
                {
                    List<string> arrayItem = new List<string>();
                    int length = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                    n = 0;
                    while (n < length)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                    }
                    i += n;
                    new DataItem28(arrayItem);
                    items[27] = false;
                    continue;
                }
            }
        }
    }
}
