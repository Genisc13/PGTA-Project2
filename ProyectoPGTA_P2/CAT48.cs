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
        public DataItem itemContainer;
        Dictionary<int, List<string>> decodedDataPerItem;

        public CAT48(List<string> arrayhex)
        {   
            this.arrayHex = arrayhex;
            this.CAT = int.Parse(arrayHex[0], System.Globalization.NumberStyles.HexNumber);
            this.Length = int.Parse(arrayHex[1]+arrayHex[2], System.Globalization.NumberStyles.HexNumber);
            this.items = new bool[28];
            List<string> arrayItem3 = new List<string>();
            List<string> arrayItem14 = new List<string>();
            decodedDataPerItem = new Dictionary<int, List<string>>();
            itemContainer = new DataItem();
            int i = 3;
            //Console.WriteLine("Creando paquete CAT48...");
            bool finishFSPEC = false;
            while (i < arrayHex.Count)
            {
                //Console.WriteLine("Editando Byte");
                List<string> arrayItem;
                int n;
                string hexByte = arrayHex[i];
                string binaryByte = Convert.ToString(Convert.ToInt32(hexByte, 16), 2).PadLeft(8, '0');
                
                if (i>=3 && i<=6 && finishFSPEC == false)
                {
                    n = 0;
                    while (n < binaryByte.Length)
                    {
                        if (binaryByte[n]=='1')
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
                        }else if (n == 7)
                        {
                            finishFSPEC = true;
                        }
                        n++;                        
                    }
                    i++;
                    continue;
                }

                //Item 1
                if (items[0] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem1(new DataItem1(arrayItem));
                    i+=2;
                    items[0] = false;
                    continue;
                }
                //Item 2
                else if (items[1] == true)
                {
                    arrayItem = new List<string>(3)
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2]
                    };
                    itemContainer.SetDataItem2(new DataItem2(arrayItem));
                    i += 3;
                    items[1] = false;
                    continue;
                }
                //Item 3
                else if (items[2] == true)
                {
                    arrayItem3.Add(arrayHex[i]);
                    if (binaryByte[7]=='1')
                    {                        
                        i++;
                        continue;
                    }
                    else
                    {                       
                        i++;
                        itemContainer.SetDataItem3(new DataItem3(arrayItem3));
                        items[2] = false;
                        continue;
                    }
                }
                //Item 4
                else if (items[3] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2],
                        arrayHex[i + 3]
                    };
                    itemContainer.SetDataItem4(new DataItem4(arrayItem));
                    i += 4;
                    items[3] = false;
                    continue;
                }
                //Item 5
                else if (items[4] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem5(new DataItem5(arrayItem));
                    i += 2;
                    items[4] = false;
                    continue;

                }
                /*
                else
                {
                    itemContainer.SetDataItem5(new DataItem5());
                }
                */
                //Item 6
                else if (items[5] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem6(new DataItem6(arrayItem));
                    i += 2;
                    items[5] = false;
                    continue;

                }
                //Item 7
                else if (items[6] == true)
                {
                    arrayItem = new List<string>();
                    n = 0;
                    int count = 0;
                    int next = 0;
                    while (n < binaryByte.Length)
                    {
                        binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i+next], 16), 2).PadLeft(8, '0');
                        if (binaryByte[n] == '1')
                        {
                            if (n == 7)
                            {
                                //FX
                                next++;
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
                    n = 0 + next;
                    while (n <= count+next)
                    {
                        arrayItem.Add(arrayHex[i+n]);
                        n++;
                    }
                    i+=n;
                    itemContainer.SetDataItem7(new DataItem7(arrayItem));
                    items[6] = false;
                    continue;
                    
                }
                //Item 8
                else if (items[7] == true)
                {
                    arrayItem = new List<string>(3)
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2]
                    };
                    itemContainer.SetDataItem8(new DataItem8(arrayItem));
                    i += 3;
                    items[7] = false;
                    continue;

                }
                //Item 9
                else if (items[8] == true)
                {
                    arrayItem = new List<string>(3)
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2],
                        arrayHex[i + 3],
                        arrayHex[i + 4],
                        arrayHex[i + 5],                        
                    };
                    itemContainer.SetDataItem9(new DataItem9(arrayItem));
                    i += 6;
                    items[8] = false;
                    continue;
                }
                //Item 10
                else if (items[9] == true)
                {
                    arrayItem = new List<string>();
                    int REP = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);                    
                    n = 0;
                    while (n <= REP*8)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                        n++;
                    }
                    itemContainer.SetDataItem10(new DataItem10(arrayItem));
                    i += REP * 8;
                    items[9] = false;
                    continue;
                }
                //Item 11
                else if (items[10] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem11(new DataItem11(arrayItem));
                    i += 2;
                    items[10] = false;
                    continue;
                }
                //Item 12
                else if (items[11] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2],
                        arrayHex[i + 3]
                    };
                    itemContainer.SetDataItem12(new DataItem12(arrayItem));
                    i += 4;
                    items[11] = false;
                    continue;
                }
                //Item 13
                else if (items[12] == true)
                {
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1],
                        arrayHex[i + 2],
                        arrayHex[i + 3]
                    };
                    itemContainer.SetDataItem13(new DataItem13(arrayItem));
                    i += 4;
                    items[12] = false;
                    continue;
                }
                //Item 14
                else if (items[13] == true)
                {
                    arrayItem14.Add(arrayHex[i]);
                    if (binaryByte[7] == '1')
                    {                        
                        i++;
                        continue;
                    }
                    else
                    {                        
                        i++;
                        itemContainer.SetDataItem14(new DataItem14(arrayItem14));
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
                    if (binaryByte[7] == '1')
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
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem19(new DataItem19(arrayItem));
                    i += 2;
                    items[18] = false;
                    continue;
                }
                //Item 20
                else if (items[19] == true)
                {
                    if (binaryByte[7] == '1')
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
                    arrayItem = new List<string>
                    {
                        arrayHex[i],
                        arrayHex[i + 1]
                    };
                    itemContainer.SetDataItem21(new DataItem21(arrayItem));
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
                    arrayItem = new List<string>();
                    int length = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                    n = 0;
                    while (n < length)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                        n++;
                    }
                    i += n;
                    itemContainer.SetDataItem27(new DataItem27(arrayItem));
                    items[26] = false;
                    continue;
                }
                //Item 28
                else if (items[27] == true)
                {
                    arrayItem = new List<string>();
                    int length = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                    n = 0;
                    while (n < length)
                    {
                        arrayItem.Add(arrayHex[i + n]);
                        n++;
                    }
                    i += n;
                    itemContainer.SetDataItem28(new DataItem28(arrayItem));
                    items[27] = false;
                    continue;
                }
                i++;
            }
            //Una vez tenemos todos los DataItems decodificados hemos de hacer algo con ellos.
            if (itemContainer.GetDataItem1()!=null)
            {
                decodedDataPerItem.Add(1,itemContainer.GetDataItem1().GetData());
            }
            if (itemContainer.GetDataItem2() != null)
            {
                decodedDataPerItem.Add(2, itemContainer.GetDataItem2().GetData());
            }
            if (itemContainer.GetDataItem3() != null)
            {
                decodedDataPerItem.Add(3, itemContainer.GetDataItem3().GetData());
            }
            if (itemContainer.GetDataItem4() != null)
            {
                decodedDataPerItem.Add(4, itemContainer.GetDataItem4().GetData());
            }
            if (itemContainer.GetDataItem5() != null)
            {
                decodedDataPerItem.Add(5, itemContainer.GetDataItem5().GetData());
            }
            if (itemContainer.GetDataItem6() != null)
            {
                decodedDataPerItem.Add(6, itemContainer.GetDataItem6().GetData());
            }
            if (itemContainer.GetDataItem7() != null)
            {
                decodedDataPerItem.Add(7, itemContainer.GetDataItem7().GetData());
            }
            if (itemContainer.GetDataItem8() != null)
            {
                decodedDataPerItem.Add(8, itemContainer.GetDataItem8().GetData());
            }
            if (itemContainer.GetDataItem9() != null)
            {
                decodedDataPerItem.Add(9, itemContainer.GetDataItem9().GetData());
            }
            if (itemContainer.GetDataItem10() != null)
            {
                decodedDataPerItem.Add(10, itemContainer.GetDataItem10().GetData());
            }
            if (itemContainer.GetDataItem11() != null)
            {
                decodedDataPerItem.Add(11, itemContainer.GetDataItem11().GetData());
            }
            if (itemContainer.GetDataItem12() != null)
            {
                decodedDataPerItem.Add(12, itemContainer.GetDataItem12().GetData());
            }
            if (itemContainer.GetDataItem13() != null)
            {
                decodedDataPerItem.Add(13, itemContainer.GetDataItem13().GetData());
            }
            if (itemContainer.GetDataItem14() != null)
            {
                decodedDataPerItem.Add(14, itemContainer.GetDataItem14().GetData());
            }
            if (itemContainer.GetDataItem15() != null)
            {
                decodedDataPerItem.Add(15, itemContainer.GetDataItem15().GetData());
            }
            if (itemContainer.GetDataItem16() != null)
            {
                decodedDataPerItem.Add(16, itemContainer.GetDataItem16().GetData());
            }
            if (itemContainer.GetDataItem17() != null)
            {
                decodedDataPerItem.Add(17, itemContainer.GetDataItem17().GetData());
            }
            if (itemContainer.GetDataItem18() != null)
            {
                decodedDataPerItem.Add(18, itemContainer.GetDataItem18().GetData());
            }
            if (itemContainer.GetDataItem19() != null)
            {
                decodedDataPerItem.Add(19, itemContainer.GetDataItem19().GetData());
            }
            if (itemContainer.GetDataItem20() != null)
            {
                decodedDataPerItem.Add(20, itemContainer.GetDataItem20().GetData());
            }
            if (itemContainer.GetDataItem21() != null)
            {
                decodedDataPerItem.Add(21, itemContainer.GetDataItem21().GetData());
            }
            if (itemContainer.GetDataItem22() != null)
            {
                decodedDataPerItem.Add(22, itemContainer.GetDataItem22().GetData());
            }
            if (itemContainer.GetDataItem23() != null)
            {
                decodedDataPerItem.Add(23, itemContainer.GetDataItem23().GetData());
            }
            if (itemContainer.GetDataItem24() != null)
            {
                decodedDataPerItem.Add(24, itemContainer.GetDataItem24().GetData());
            }
            if (itemContainer.GetDataItem25() != null)
            {
                decodedDataPerItem.Add(25, itemContainer.GetDataItem25().GetData());
            }
            if (itemContainer.GetDataItem26() != null)
            {
                decodedDataPerItem.Add(26, itemContainer.GetDataItem26().GetData());
            }
            if (itemContainer.GetDataItem27() != null)
            {
                decodedDataPerItem.Add(27, itemContainer.GetDataItem27().GetData());
            }
            if (itemContainer.GetDataItem28() != null)
            {
                decodedDataPerItem.Add(28, itemContainer.GetDataItem28().GetData());
            }
            
        }
        public Dictionary<int,List<string>> GetDataDecodedPerItem()
        {
            return decodedDataPerItem;
        }
    }
}
