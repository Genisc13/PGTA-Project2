using GLib;
using MultiCAT6.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Libs.MediaFoundation.OPM;

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
            GeoUtils geoUtils = new GeoUtils();
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
            //Console.WriteLine("Editando Byte");
            List<string> arrayItem;
            int n;
            
            while (i >= 3 && i <= 6 && finishFSPEC == false)
            {
                
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                n = 0;
                while (n < binaryByte.Length)
                {
                    if (binaryByte[n] == '1')
                    {
                        if (n >= 0 && n <= 6)
                        {
                            if (i == 3)
                            {
                                this.items[n] = true;
                            }
                            else if (i == 4)
                            {
                                this.items[n + 7] = true;
                            }
                            else if (i == 5)
                            {
                                this.items[n + 14] = true;
                            }
                            else if (i == 6)
                            {
                                this.items[n + 21] = true;
                            }
                        }
                    }
                    else
                    {
                        if(n >= 0 && n <= 6)
                        {

                            if (i == 3)
                            {
                                this.items[n] = false;
                            }
                            else if (i == 4)
                            {
                                this.items[n + 7] = false;
                            }
                            else if (i == 5)
                            {
                                this.items[n + 14] = false;
                            }
                            else if (i == 6)
                            {
                                this.items[n + 21] = false;
                            }
                        }
                        else
                        {
                            finishFSPEC = true;
                        }                       
                    }
                    n++;
                }
                i++;
                
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
                i += 2;
                items[0] = false;
            }
            else
            {
                itemContainer.SetDataItem1(new DataItem1());
            }
            //Item 2
            if (items[1] == true)
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
            }
            else
            {
                itemContainer.SetDataItem2(new DataItem2());
            }
            //Item 3
            if (items[2] == true)
            {
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                bool found = true;
                arrayItem3.Add(arrayHex[i]);
                while (found) {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                    
                    if (binaryByte[7] == '1')
                    {                                              
                        i++;
                        arrayItem3.Add(arrayHex[i]);
                    }
                    else
                    {
                        i++;
                        itemContainer.SetDataItem3(new DataItem3(arrayItem3));
                        found = false;
                        items[2] = false;
                    }
                }              
            }
            else
            {
                itemContainer.SetDataItem3(new DataItem3());
            }
            //Item 4
            if (items[3] == true)
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
            }
            else
            {
                itemContainer.SetDataItem4(new DataItem4());
            }
            //Item 5
            if (items[4] == true)
            {
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                itemContainer.SetDataItem5(new DataItem5(arrayItem));
                i += 2;
                items[4] = false;
            }            
            else
            {
                itemContainer.SetDataItem5(new DataItem5());
            }
            
            //Item 6
            if (items[5] == true)
            {
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                itemContainer.SetDataItem6(new DataItem6(arrayItem));
                i += 2;
                items[5] = false;

            }
            else
            {
                itemContainer.SetDataItem6(new DataItem6());
            }
            //Item 7
            if (items[6] == true)
            {
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
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
            }
            else
            {
                itemContainer.SetDataItem7(new DataItem7());
            }
            //Item 8
            if (items[7] == true)
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
            }
            else
            {
                itemContainer.SetDataItem8(new DataItem8());
            }
            //Item 9
            if (items[8] == true)
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
            }
            else
            {
                itemContainer.SetDataItem9(new DataItem9());
            }
            //Item 10
            if (items[9] == true)
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
                i += REP * 8+1;
                items[9] = false;
            }
            else
            {
                itemContainer.SetDataItem10(new DataItem10());
            }
            //Item 11
            if (items[10] == true)
            {
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                itemContainer.SetDataItem11(new DataItem11(arrayItem));
                i += 2;
                items[10] = false;
            }
            else
            {
                itemContainer.SetDataItem11(new DataItem11());
            }
            //Item 12
            if (items[11] == true)
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
            }
            else
            {
                itemContainer.SetDataItem12(new DataItem12());
            }
            //Item 13
            if (items[12] == true)
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
            }
            else
            {
                itemContainer.SetDataItem13(new DataItem13());
            }
            //Item 14
            if (items[13] == true)
            {
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                bool found = true;
                arrayItem14.Add(arrayHex[i]);
                while (found)
                {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                    
                    if (binaryByte[7] == '1')
                    {
                        i++;
                        arrayItem14.Add(arrayHex[i]);
                    }
                    else
                    {
                        i++;
                        itemContainer.SetDataItem14(new DataItem14(arrayItem14));
                        found = false;
                        items[13] = false;
                    }
                }                
            }
            else
            {
                itemContainer.SetDataItem14(new DataItem14());
            }
            //Item 15
            if (items[14] == true)
            {
                i += 4;
                items[14] = false;
            }
            //Item 16
            if (items[15] == true)
            {
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                bool found = true;
                while (found)
                {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                    if (binaryByte[7] == '1')
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        i++;
                        items[13] = false;
                        found = false;
                    }
                }              
            }
            //Item 17
            if (items[16] == true)
            {
                i += 2;
                items[16] = false;
            }
            //Item 18
            if (items[17] == true)
            {
                i += 4;
                items[17] = false;
            }
            //Item 19
            if (items[18] == true)
            {
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                itemContainer.SetDataItem19(new DataItem19(arrayItem));
                i += 2;
                items[18] = false;
            }
            else
            {
                itemContainer.SetDataItem19(new DataItem19());
            }
            //Item 20
            if (items[19] == true)
            {
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                bool found = true;
                while (found)
                {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                    if (binaryByte[7] == '1')
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                        items[19] = false;
                        found= false;
                    }
                }               
            }
            //Item 21
            if (items[20] == true)
            {
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                itemContainer.SetDataItem21(new DataItem21(arrayItem));
                i += 2;
                items[20] = false;
            }
            else
            {
                itemContainer.SetDataItem21(new DataItem21());
            }
            //Item 22
            if (items[21] == true)
            {
                i += 7;
                items[21] = false;
            }
            //Item 23
            if (items[22] == true)
            {
                i += 1;
                items[22] = false;
            }
            //Item 24
            if (items[23] == true)
            {
                i += 2;
                items[23] = false;
            }
            //Item 25
            if (items[24] == true)
            {
                i += 1;
                items[24] = false;
            }
            //Item 26
            if (items[25] == true)
            {
                i += 2;
                items[25] = false;
            }
            //Item 27
            if (items[26] == true)
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
                items[26] = false;
            }
            //Item 28
            if (items[27] == true)
            {
                arrayItem = new List<string>();
                int length = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                n = 0;
                while (n < length)
                {
                    arrayItem.Add(arrayHex[i + n]);
                    n++;
                }
                items[27] = false;
            }

            //Calcular posiciones

            //GMS
            //Latitud: 41º 18’ 02,5284’’ N
            //Longitud: 02º 06’ 07,4095’’ E

            //Geográficas
            //Lat 41.3007023
            //Long 2.1020581944444445

            //Elevación terreno: 2,007 m
            //Altura antena: 25,25 m
            CoordinatesPolar radarPolar;

            if (itemContainer.GetDataItem8().AircraftAddress == "346088")
            {
                int a = 1;
            }

            if (itemContainer.GetDataItem6().FL < 0)
            {
                radarPolar = new CoordinatesPolar(itemContainer.GetDataItem4().RHD * 1852, itemContainer.GetDataItem4().THETA * (Math.PI / 180), Math.Asin((0 * 100 * 0.3048) / (itemContainer.GetDataItem4().RHD * 1852)));
            }
            else
            {
                double asin = (2*6371000*((itemContainer.GetDataItem6().FL * 100 * 0.3048)- 2.007 + 25.25)+ (itemContainer.GetDataItem6().FL * 100 * 0.3048)* (itemContainer.GetDataItem6().FL * 100 * 0.3048)-(2.007 + 25.25) *(2.007 + 25.25)-(itemContainer.GetDataItem4().RHD * 1852)* itemContainer.GetDataItem4().RHD * 1852)/((2* itemContainer.GetDataItem4().RHD * 1852)*(6371000+ 2.007 + 25.25));

                if (asin > 1)
                {
                    int b = 2;
                    //asin = 1;
                }

                radarPolar = new CoordinatesPolar(itemContainer.GetDataItem4().RHD * 1852, itemContainer.GetDataItem4().THETA * (Math.PI / 180), Math.Asin(asin));
            }
            
            

            CoordinatesXYZ radarCartesian = GeoUtils.change_radar_spherical2radar_cartesian(radarPolar);

            CoordinatesWGS84 radarCoordinates = new CoordinatesWGS84(41.3007023 * (Math.PI / 180), 2.10205819444 * (Math.PI / 180), 2.007 + 25.25); //coordenadas del radar en geográficas en vez de GMS comentado por ahora
                                                                                                          //CoordinatesWGS84 radarCoordinates = new CoordinatesWGS84("41º 18’ 02,5284’’ N", "02º 06’ 07,4095’’ E", 2.007 + 25.25);


            //LINEAS DE ABAJO COMENTADAS PARA QUE NO DE ERROR
            CoordinatesXYZ geocentricSystem = geoUtils.change_radar_cartesian2geocentric(radarCoordinates, radarCartesian);

            CoordinatesWGS84 geodesic = geoUtils.change_geocentric2geodesic(geocentricSystem);           
            itemContainer.GetDataItem12().SetData((float)geodesic.Lat * (180/Math.PI), (float)geodesic.Lon * (180 / Math.PI), (float)geodesic.Height);            
            

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
