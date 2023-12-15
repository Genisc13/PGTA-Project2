using MultiCAT6.Utils;
using System;
using System.Collections.Generic;

namespace ProyectoPGTA_P2
{
    public class CAT48
    {
        //DataItem 2:
        public float time;
        //DataItem 3:
        public string TYP;
        //DataItem 4:
        public float RHO, THETA;
        //DataItem 6:
        public float FL;
        //DataItem 8:
        public string AircraftAddress;
        //DataItem 9:
        public string completeArraystring="";
        public string[] AAmatrix = new string[8];
        public string AircraftIdentification;
        //DataItem 10:
        //Param BDS4.0
        public string MCPSelectedAlt = "N/D";
        public int intMCPSelectedAlt;
        public string FMSSelectedAlt = "N/D";
        public int intFMSSelectedAlt;
        public string BarPressure = "N/D";
        public float floatBarPressure;
        public string StatusMCP = "N/D";
        public string VNAV = "N/D";
        public string ALTHoldMode = "N/D";
        public string APPMode = "N/D";
        public string StatusTargetAltSource = "N/D";
        public string TargetAltSource = "N/D";
        //Param BDS5.0
        public string RollAngle = "N/D";
        public string TrueTrackAngle = "N/D";
        public string GS = "N/D";
        public string TrackAngleRate = "N/D";
        public string TAS = "N/D";
        //Param BDS6.0
        public string MagneticHeading = "N/D";
        public string IAS = "N/D";
        public string MACH = "N/D";
        public string BarometricAlt = "N/D";
        public string InertialVerticalVel = "N/D";

        //DataItem12:
        public double Xcord, Ycord, Zcord;

        //DataItem13:
        public float GS13, HEAD;

        //DataItem21:
        public int statINT;
        //List of strings that contains the values of the Binary code on Hex
        public List<string> arrayHex;
        public List<string> data;
        //Category number
        public int CAT;
        //Number of the bytes of the Packet
        public int Length;
        //A matrix of booleans saying if a dataItem is there or not
        public bool[] items;
        //This is de dictionary of all the dataItems decoded and its data
        public Dictionary<int, List<string>> decodedDataPerItem;
        /// <summary>
        /// This is the CAT48 class, this class decodes every packet with 
        /// the correspondant dataItems on it listed on a dictionary
        /// </summary>
        /// <param name="arrayhex"></param>
        public CAT48(List<string> arrayhex)
        {
            //We create an instance of GeoUtils for the coordiantes transformation
            GeoUtils geoUtils = new GeoUtils();
            //initialization of the parameters
            this.arrayHex = arrayhex;
            this.CAT = int.Parse(arrayHex[0], System.Globalization.NumberStyles.HexNumber);
            this.Length = int.Parse(arrayHex[1] + arrayHex[2], System.Globalization.NumberStyles.HexNumber);
            this.items = new bool[28];
            //These are DataItems that were done appart
            List<string> arrayItem3 = new List<string>();
            List<string> arrayItem14 = new List<string>();
            //Initalization of the itemContainer and the dictionary of dataItems
            decodedDataPerItem = new Dictionary<int, List<string>>();
            int i = 3;
            //Console.WriteLine("Creando paquete CAT48...");
            bool finishFSPEC = false;
            //Console.WriteLine("Editando Byte");
            List<string> arrayItem;
            int n;
            //This while uses the FSPEC to know exactly what dataItems are on the CAT48 packet
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
                        if (n >= 0 && n <= 6)
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
                int SACint = Convert.ToInt32(arrayItem[0], 16);
                int SICint = Convert.ToInt32(arrayItem[1], 16);
                data = new List<string> { SACint.ToString(), SICint.ToString() };
                i += 2;
                items[0] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D" };
            }
            SetDataOnDictionary(1, data);
            //Item 2
            if (items[1] == true)
            {
                arrayItem = new List<string>(3)
                {
                    arrayHex[i],
                    arrayHex[i + 1],
                    arrayHex[i + 2]
                };
                

                time = Convert.ToInt32(arrayItem[0].PadLeft(2, '0') + arrayItem[1].PadLeft(2, '0') + arrayItem[2].PadLeft(2, '0'), 16) / 128f; //hora actual en segundos

                float hours = time / 3600f;
                int trunchours = (int)Math.Truncate(hours);
                float minutes = (hours - trunchours) * 60;
                int truncminutes = (int)Math.Truncate(minutes);
                float seconds = (minutes - truncminutes) * 60;
                int truncseconds = (int)Math.Truncate(seconds);
                float milsec = (seconds - truncseconds) * 1000;
                int truncmilsec = (int)Math.Truncate(milsec);

                //time = Convert.ToInt32(timestr, 2) / 128;

                //data = new List<string> { "Time", trunchours.ToString().PadLeft(2, '0') + ":" + truncminutes.ToString().PadLeft(2, '0') + ":" + truncseconds.ToString().PadLeft(2, '0') + ":" + truncmilsec.ToString().PadLeft(3, '0') };
                data = new List<string> { trunchours.ToString().PadLeft(2, '0') + ":" + truncminutes.ToString().PadLeft(2, '0') + ":" + truncseconds.ToString().PadLeft(2, '0') + ":" + truncmilsec.ToString().PadLeft(3, '0'), time.ToString() };
                i += 3;
                items[1] = false;
            }
            else
            {
                data = new List<string> { "N/D" };
            }
            SetDataOnDictionary(2, data);

            //Item 3
            if (items[2] == true)
            {
                string binaryByte;
                bool found = true;
                
                string SIM;
                string RDP;
                string SPI;
                string RAB;
                string FX1;
                string TST = "N/A";
                string ERR = "N/A";
                string XPP = "N/A", ME = "N/A", MI = "N/A", FOE_FRI = "N/A";
                string FX2;
                string ADSB_EP = "N/A", ADSB_VAL = "N/A", SCN_EP = "N/A", SCN_VAL = "N/A", PAI_EP = "N/A", PAI_VAL = "N/A";
                
                arrayItem3.Add(arrayHex[i]);
                while (found)
                {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');

                    if (binaryByte[7] == '1')
                    {
                        i++;
                        arrayItem3.Add(arrayHex[i]);
                    }
                    else
                    {
                        i++;
                        found = false;
                        items[2] = false;
                    }
                }
                //First part decode

                string a = Convert.ToString(Convert.ToInt32(arrayItem3[0], 16), 2).PadLeft(8, '0');
                TYP = String.Concat(a[0], a[1], a[2]);
                switch (TYP)
                {
                    case "000":
                        TYP = "No detection";
                        break;
                    case "001":
                        TYP = "Single PSR detection";
                        break;
                    case "010":
                        TYP = "Single SSR detection";
                        break;
                    case "011":
                        TYP = "SSR + PSR detection";
                        break;
                    case "100":
                        TYP = "Single ModeS All-Call";
                        break;
                    case "101":
                        TYP = "Single ModeS Roll-Call";
                        break;
                    case "110":
                        TYP = "ModeS All-Call + PSR";
                        break;
                    case "111":
                        TYP = "ModeS Roll-Call + PSR";
                        break;
                    default:
                        TYP = "N/A";
                        break;
                }

                SIM = a[3].ToString();
                switch (SIM)
                {
                    case "0":
                        SIM = "Actual target report";
                        break;
                    case "1":
                        SIM = "Simulated target report";
                        break;
                    default:
                        SIM = "N/A";
                        break;
                }

                RDP = a[4].ToString();
                switch (RDP)
                {
                    case "0":
                        RDP = "Report from RPD Chain 1";
                        break;
                    case "1":
                        RDP = "Report from RPD Chain 2";
                        break;
                    default:
                        RDP = "N/A";
                        break;
                }

                SPI = a[5].ToString();
                switch (SPI)
                {
                    case "0":
                        SPI = "Absence of SPI";
                        break;
                    case "1":
                        SPI = "Special Position Identification";
                        break;
                    default:
                        SPI = "N/A";
                        break;
                }

                RAB = a[6].ToString();
                switch (RAB)
                {
                    case "0":
                        RAB = "Report from aircraft transponder";
                        break;
                    case "1":
                        RAB = "Report from field monitor (Fixed transponder)";
                        break;
                    default:
                        RAB = "N/A";
                        break;
                }

                FX1 = a[7].ToString();
                if (FX1 == "1")
                {
                    //Decode first extension
                    string b = Convert.ToString(Convert.ToInt32(arrayItem3[1], 16), 2).PadLeft(8, '0');

                    TST = b[0].ToString();
                    switch (TST)
                    {
                        case "0":
                            TST = "Real target report";
                            break;
                        case "1":
                            TST = "Test target report";
                            break;
                        default:
                            TST = "N/A";
                            break;
                    }

                    ERR = b[1].ToString();
                    switch (ERR)
                    {
                        case "0":
                            ERR = "No Extended Range";
                            break;
                        case "1":
                            ERR = "Extended Range present";
                            break;
                        default:
                            ERR = "N/A";
                            break;
                    }

                    XPP = b[2].ToString();
                    switch (XPP)
                    {
                        case "0":
                            XPP = "No X-Pulse present";
                            break;
                        case "1":
                            XPP = "X-Pulse present";
                            break;
                        default:
                            XPP = "N/A";
                            break;
                    }

                    ME = b[3].ToString();
                    switch (ME)
                    {
                        case "0":
                            ME = "No military emergency";
                            break;
                        case "1":
                            ME = "Military emergency";
                            break;
                        default:
                            ME = "N/A";
                            break;
                    }

                    MI = b[4].ToString();
                    switch (MI)
                    {
                        case "0":
                            MI = "No military identification";
                            break;
                        case "1":
                            MI = "Military identification";
                            break;
                        default:
                            MI = "N/A";
                            break;
                    }

                    FOE_FRI = String.Concat(b[5], b[6]);
                    switch (FOE_FRI)
                    {
                        case "00":
                            FOE_FRI = "No mode 4 interrogation";
                            break;
                        case "01":
                            FOE_FRI = "Friendly target";
                            break;
                        case "10":
                            FOE_FRI = "Unknown target";
                            break;
                        case "11":
                            FOE_FRI = "No reply";
                            break;
                        default:
                            FOE_FRI = "N/A";
                            break;
                    }

                    FX2 = b[7].ToString();
                    if (FX2 == "1")
                    {
                        //Decode second extension
                        string c = Convert.ToString(Convert.ToInt32(arrayItem3[2], 16), 2).PadLeft(8, '0');

                        ADSB_EP = c[0].ToString();
                        switch (ADSB_EP)
                        {
                            case "0":
                                ADSB_EP = "On-site ADS-B Information not populated";
                                break;
                            case "1":
                                ADSB_EP = "On-site ADS-B Information populated";
                                break;
                            default:
                                ADSB_EP = "N/A";
                                break;
                        }

                        ADSB_VAL = c[1].ToString();
                        switch (ADSB_VAL)
                        {
                            case "0":
                                ADSB_VAL = "ADSB information not available";
                                break;
                            case "1":
                                ADSB_VAL = "ADSB information available";
                                break;
                            default:
                                ADSB_VAL = "N/A";
                                break;
                        }

                        SCN_EP = c[2].ToString();
                        switch (SCN_EP)
                        {
                            case "0":
                                SCN_EP = "Surveillance Cluster Network Information not populated";
                                break;
                            case "1":
                                SCN_EP = "Surveillance Cluster Network Information populated";
                                break;
                            default:
                                SCN_EP = "N/A";
                                break;
                        }

                        SCN_VAL = c[3].ToString();
                        switch (SCN_VAL)
                        {
                            case "0":
                                SCN_VAL = "SCN information not available";
                                break;
                            case "1":
                                SCN_VAL = "SCN information available";
                                break;
                            default:
                                SCN_VAL = "N/A";
                                break;
                        }

                        PAI_EP = c[4].ToString();
                        switch (PAI_EP)
                        {
                            case "0":
                                PAI_EP = "Passive Element Interface not populated";
                                break;
                            case "1":
                                PAI_EP = "Passive Element Interface populated";
                                break;
                            default:
                                PAI_EP = "N/A";
                                break;
                        }

                        PAI_VAL = c[5].ToString();
                        switch (PAI_VAL)
                        {
                            case "0":
                                PAI_VAL = "PAI information not available";
                                break;
                            case "1":
                                PAI_VAL = "PAI information available";
                                break;
                            default:
                                PAI_VAL = "N/A";
                                break;
                        }

                    }
                }
                //data = new List<string> { "TYP", TYP, "SIM", SIM, "RDP", RDP, "SPI", SPI, "RAB", RAB, "TST", TST, "ERR", ERR, "XPP", XPP, "ME", ME, "MI", MI, "FOE/FRI", FOE_FRI, "ADSB_EP", ADSB_EP, "ADSB_VAL", ADSB_VAL, "SCN_EP", SCN_EP, "SCN_VAL", SCN_VAL, "PAI_EP", PAI_EP, "PAI_VAL", PAI_VAL };
                data = new List<string> { TYP, SIM, RDP, SPI, RAB, TST, ERR, XPP, ME, MI, FOE_FRI, ADSB_EP, ADSB_VAL, SCN_EP, SCN_VAL, PAI_EP, PAI_VAL };
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(3, data);

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
                i += 4;
                items[3] = false;

                string RHD_16 = String.Concat(arrayItem[0].PadLeft(2, '0'), arrayItem[1].PadLeft(2, '0'));
                string THETA_16 = String.Concat(arrayItem[2].PadLeft(2, '0'), arrayItem[3].PadLeft(2, '0'));

                RHO = (float)Math.Round(Convert.ToInt32(RHD_16, 16) / 256d, 4);

                THETA = (float)Math.Round(Convert.ToInt32(THETA_16, 16) * 45 / 8192f, 4);

                //data = new List<string> { "RHO", RHD.ToString() + " NM", "THETA", THETA.ToString() + " º"};
                data = new List<string> { RHO.ToString() + " NM", THETA.ToString() + " º" };
            }
            else
            {
                data = new List<string> { "N/D", "N/D" };
            }
            SetDataOnDictionary(4, data);

            //Item 5
            if (items[4] == true)
            {
                string V, G, L, Mode3;
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };               
                i += 2;
                items[4] = false;
                string a = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                V = a[0].ToString();
                switch (V)
                {
                    case "0":
                        V = "Codigo validado";
                        break;
                    case "1":
                        V = "Codigo no validado";
                        break;
                    default:
                        V = "N/A";
                        break;

                }

                G = a[1].ToString();
                switch (G)
                {
                    case "0":
                        G = "Codigo default";
                        break;
                    case "1":
                        G = "Codigo distorsionado";
                        break;
                    default:
                        G = "N/A";
                        break;

                }

                L = a[2].ToString();
                switch (L)
                {
                    case "0":
                        L = "Codigo Mode-3/A derivado de la respuesta XPDR";
                        break;
                    case "1":
                        L = "Codigo Mode-3/A no se ha extraido en el ultimo escaneo";
                        break;
                    default:
                        L = "N/A";
                        break;

                }

                Mode3 = string.Concat(a[4], a[5], a[6], a[7], Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0'));
                if (L == "Codigo Mode-3/A no se ha extraído en el último escaneo")
                {
                    Mode3 = "N/A";
                }
                else
                {
                    Mode3 = Convert.ToString(Convert.ToInt32(Mode3, 2), 8);
                }
                //data = new List<string> { "V", V, "G", G, "L", L, "Mode3", Mode3 };
                data = new List<string> { V, G, L, Mode3 };
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(5, data);

            //Item 6
            if (items[5] == true)
            {
                string V, G;                              
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                string a = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                V = a[0].ToString();
                switch (V)
                {
                    case "0":
                        V = "Codigo validado";
                        break;
                    case "1":
                        V = "Codigo no validado";
                        break;
                    default:
                        V = "N/A";
                        break;

                }

                G = a[1].ToString();
                switch (G)
                {
                    case "0":
                        G = "Default";
                        break;
                    case "1":
                        G = "Codigo distorsionado";
                        break;
                    default:
                        G = "N/A";
                        break;

                }

                string FL_BIN = String.Concat(a[2], a[3], a[4], a[5], a[6], a[7], Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0'));
                string FL_BIN1 = String.Concat(a[2], a[3], a[4], a[5], a[6], a[7]);
                string FL_BIN2 = String.Concat(Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0'));

                if (FL_BIN1[0].ToString() == "1") //2s comp
                {
                    byte b1 = Convert.ToByte(FL_BIN1, 2);
                    byte complement1 = (byte)~b1;
                    //byte twosComplement1 = (byte)(complement1 + 1);
                    FL_BIN1 = Convert.ToString(complement1, 2).PadLeft(6, '0');

                    byte b2 = Convert.ToByte(FL_BIN2, 2);
                    byte complement2 = (byte)~b2;
                    byte twosComplement2 = (byte)(complement2 + 1);
                    FL_BIN2 = Convert.ToString(twosComplement2, 2).PadLeft(8, '0');

                    FL_BIN = string.Concat(FL_BIN1, FL_BIN2);
                    FL_BIN = String.Concat(FL_BIN1[2], FL_BIN1[3], FL_BIN1[4], FL_BIN1[5], FL_BIN1[6], FL_BIN1[7], FL_BIN2[0], FL_BIN2[1], FL_BIN2[2], FL_BIN2[3], FL_BIN2[4], FL_BIN2[5], FL_BIN2[6], FL_BIN2[7]);

                    FL = -Convert.ToInt32(FL_BIN, 2) / 4f;
                }
                else
                {
                    FL = Convert.ToInt32(FL_BIN, 2) / 4f;
                }

                //data = new List<string> { "V", V, "G", G, "FL", FL.ToString() };
                data = new List<string> { V, G, FL.ToString() };
                i += 2;
                items[5] = false;

            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D" };
                FL = -9999;
            }
            SetDataOnDictionary(6, data);

            //Item 7
            if (items[6] == true)
            {
                string SRL, SRR, SAM, PRL, PAM, RPD, APD;
                string FX1;
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');
                arrayItem = new List<string>();
                n = 0;
                int count = 0;
                int next = 0;
                while (n < binaryByte.Length)
                {
                    binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i + next], 16), 2).PadLeft(8, '0');
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
                while (n <= count + next)
                {
                    arrayItem.Add(arrayHex[i + n]);
                    n++;
                }
                i += n;

                int index = 1;
                string a = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                SRL = a[0].ToString();
                if (SRL == "1")
                {
                    SRL = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    SRL = (Convert.ToInt32(SRL, 2) * 45 / 1024f).ToString() + " dg";

                    index++;
                }
                else
                {
                    SRL = "N/A";
                }

                SRR = a[1].ToString();
                if (SRR == "1")
                {
                    SRR = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    SRR = (Convert.ToInt32(SRR, 2)).ToString();

                    index++;

                }
                else
                {
                    SRR = "N/A";
                }

                SAM = a[2].ToString();

                if (SAM == "1")
                {
                    SAM = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');

                    //2s complement

                    byte b = Convert.ToByte(SAM, 2);
                    byte complement = (byte)~b;
                    byte twosComplement = (byte)(complement + 1);
                    SAM = Convert.ToString(twosComplement, 2).PadLeft(8, '0');
                    SAM = "-" + Convert.ToInt32(SAM, 2).ToString() + " dbm";

                    index++;

                }
                else
                {
                    SAM = "N/A";
                }

                PRL = a[3].ToString();
                if (PRL == "1")
                {
                    PRL = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    PRL = (Convert.ToInt32(PRL, 2) * 45 / 1024f).ToString() + " dg";

                    index++;

                }
                else
                {
                    PRL = "N/A";
                }

                PAM = a[4].ToString();
                if (PAM == "1")
                {
                    PAM = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    PAM = (Convert.ToInt32(PAM, 2)).ToString() + " dbm";

                    index++;

                }
                else
                {
                    PAM = "N/A";
                }

                RPD = a[5].ToString();
                if (RPD == "1")
                {
                    RPD = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    RPD = (Convert.ToInt32(RPD, 2) / 256f).ToString() + " NM";

                    index++;

                }
                else
                {
                    RPD = "N/A";
                }

                APD = a[6].ToString();
                if (APD == "1")
                {
                    APD = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                    APD = (Convert.ToInt32(APD, 2) * 45 / 2048f).ToString() + " dg";

                    index++;
                }
                else
                {
                    APD = "N/A";
                }

                //data = new List<string> { "SRL", SRL, "SRR", SRR, "SAM", SAM, "PRL", PRL, "PAM", PAM, "RPD", RPD, "APD", APD };
                data = new List<string> { SRL, SRR, SAM, PRL, PAM, RPD, APD };
                items[6] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(7, data);

            //Item 8
            if (items[7] == true)
            {
                string[] arrayString = new string[3];
                arrayItem = new List<string>(3)
                {
                    arrayHex[i],
                    arrayHex[i + 1],
                    arrayHex[i + 2]
                };
                for (int index = 0; index < arrayItem.Count; index++)
                {
                    arrayString[index] = arrayItem[index].PadLeft(2, '0');
                }
                AircraftAddress = String.Concat(arrayString[0], arrayString[1], arrayString[2]);
                //data = new List<string> { "Aircraft Address", AircraftAddress };
                data = new List<string> { AircraftAddress };
                i += 3;
                items[7] = false;
            }
            else
            {
                data = new List<string> { "N/D" };
            }
            SetDataOnDictionary(8, data);

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
                for (int index = 0; index < arrayItem.Count; index++)
                {
                    completeArraystring = completeArraystring.ToString() + Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                }
                string[] AA = new string[8];

                for (int index = 0; index < AA.Length; index++)
                {
                    AA[index] = String.Concat(completeArraystring[index * 6].ToString(), completeArraystring[index * 6 + 1].ToString(), completeArraystring[index * 6 + 2].ToString(), completeArraystring[index * 6 + 3].ToString(), completeArraystring[index * 6 + 4].ToString(), completeArraystring[index * 6 + 5].ToString());

                    AAmatrix[index] = Decode6bit(AA[index]);
                }

                AircraftIdentification = String.Join("", AAmatrix);

                //data = new List<string> { "Aircraft Identification", AircraftIdentification};
                data = new List<string> { AircraftIdentification };
                i += 6;
                items[8] = false;
            }
            else
            {
                data = new List<string> { "N/D" };
            }
            SetDataOnDictionary(9, data);

            //Item 10
            if (items[9] == true)
            {
                //Param BDS4.0
                MCPSelectedAlt = "N/A";
                intMCPSelectedAlt = 0;
                FMSSelectedAlt = "N/A";
                intFMSSelectedAlt = 0;
                BarPressure = "N/A";
                floatBarPressure = 0;
                StatusMCP = "N/A";
                VNAV = "N/A";
                ALTHoldMode = "N/A";
                APPMode = "N/A";
                StatusTargetAltSource = "N/A";
                TargetAltSource = "N/A";
                //Param BDS5.0
                RollAngle = "N/A";
                TrueTrackAngle = "N/A";
                GS = "N/A";
                TrackAngleRate = "N/A";
                TAS = "N/A";
                //Param BDS6.0
                MagneticHeading = "N/A";
                IAS = "N/A";
                MACH = "N/A";
                BarometricAlt = "N/A";
                InertialVerticalVel = "N/A";

                string BDSDATA = "N/A", BDSver = "";
                string BDS1 = "N/A", BDS2 = "N/A";

                string[] arrayString;
                arrayString = new string[arrayhex.Count];
                arrayItem = new List<string>();
                int REP = int.Parse(arrayHex[i], System.Globalization.NumberStyles.HexNumber);
                n = 0;
                while (n <= REP * 8)
                {
                    arrayItem.Add(arrayHex[i + n]);
                    n++;
                }
                for (int index = 0; index < arrayItem.Count; index++)
                {
                    arrayString[index] = Convert.ToString(Convert.ToInt32(arrayItem[index], 16), 2).PadLeft(8, '0');
                }
                for (int index = 0; index < REP; index++)
                {
                    int shift = index * 8;
                    BDSDATA = String.Concat(arrayString[shift + 1], arrayString[shift + 2], arrayString[shift + 3], arrayString[shift + 4], arrayString[shift + 5], arrayString[shift + 6], arrayString[shift + 7]);

                    //string dataBDSstr;
                    string actual_BDSver;
                    BDS1 = Convert.ToInt32(String.Concat(arrayString[shift + 8][0], arrayString[shift + 8][1], arrayString[shift + 8][2], arrayString[shift + 8][3]), 2).ToString();
                    BDS2 = Convert.ToInt32(String.Concat(arrayString[shift + 8][4], arrayString[shift + 8][5], arrayString[shift + 8][6], arrayString[shift + 8][7]), 2).ToString();

                    if (BDSver == "")
                    {
                        BDSver = BDS1 + "." + BDS2;
                    }
                    else
                    {
                        BDSver = BDSver + ":" + BDS1 + "." + BDS2;
                    }

                    actual_BDSver = BDS1 + "." + BDS2;
                    switch (actual_BDSver)
                    {
                        case "4.0":
                            MCPSelectedAlt = (Convert.ToInt32(String.Concat(BDSDATA[1], BDSDATA[2], BDSDATA[3], BDSDATA[4], BDSDATA[5], BDSDATA[6], BDSDATA[7], BDSDATA[8], BDSDATA[9], BDSDATA[10], BDSDATA[11], BDSDATA[12]), 2) * 16).ToString() + " ft";
                            intMCPSelectedAlt = Convert.ToInt32(String.Concat(BDSDATA[1], BDSDATA[2], BDSDATA[3], BDSDATA[4], BDSDATA[5], BDSDATA[6], BDSDATA[7], BDSDATA[8], BDSDATA[9], BDSDATA[10], BDSDATA[11], BDSDATA[12]), 2) * 16;
                            FMSSelectedAlt = (Convert.ToInt32(String.Concat(BDSDATA[14], BDSDATA[15], BDSDATA[16], BDSDATA[17], BDSDATA[18], BDSDATA[19], BDSDATA[20], BDSDATA[21], BDSDATA[22], BDSDATA[23], BDSDATA[24], BDSDATA[25]), 2) * 16).ToString() + " ft";
                            intFMSSelectedAlt = Convert.ToInt32(String.Concat(BDSDATA[14], BDSDATA[15], BDSDATA[16], BDSDATA[17], BDSDATA[18], BDSDATA[19], BDSDATA[20], BDSDATA[21], BDSDATA[22], BDSDATA[23], BDSDATA[24], BDSDATA[25]), 2) * 16;
                            BarPressure = (Convert.ToInt32(String.Concat(BDSDATA[27], BDSDATA[28], BDSDATA[29], BDSDATA[30], BDSDATA[31], BDSDATA[32], BDSDATA[33], BDSDATA[34], BDSDATA[35], BDSDATA[36], BDSDATA[37], BDSDATA[38]), 2) * 0.1f + 800).ToString() + " mb";
                            floatBarPressure = Convert.ToInt32(String.Concat(BDSDATA[27], BDSDATA[28], BDSDATA[29], BDSDATA[30], BDSDATA[31], BDSDATA[32], BDSDATA[33], BDSDATA[34], BDSDATA[35], BDSDATA[36], BDSDATA[37], BDSDATA[38]), 2) * 0.1f + 800;
                            StatusMCP = BDSDATA[47].ToString();
                            switch (StatusMCP)
                            {
                                case "0":
                                    StatusMCP = "No mode information provided";
                                    break;
                                case "1":
                                    StatusMCP = "Mode information deliberately provided";
                                    break;
                            }
                            VNAV = BDSDATA[48].ToString();
                            switch (VNAV)
                            {
                                case "0":
                                    VNAV = "Not active";
                                    break;
                                case "1":
                                    VNAV = "Active";
                                    break;
                            }
                            ALTHoldMode = BDSDATA[49].ToString();
                            switch (ALTHoldMode)
                            {
                                case "0":
                                    ALTHoldMode = "Not active";
                                    break;
                                case "1":
                                    ALTHoldMode = "Active";
                                    break;
                            }
                            APPMode = BDSDATA[50].ToString();
                            switch (APPMode)
                            {
                                case "0":
                                    APPMode = "Not active";
                                    break;
                                case "1":
                                    ALTHoldMode = "Active";
                                    break;
                            }
                            StatusTargetAltSource = BDSDATA[53].ToString();
                            switch (StatusTargetAltSource)
                            {
                                case "0":
                                    StatusTargetAltSource = "No source informatiuon provided";
                                    break;
                                case "1":
                                    StatusTargetAltSource = "Mode information deliberately provided";
                                    break;
                            }

                            TargetAltSource = String.Concat(BDSDATA[54], BDSDATA[55]).ToString();
                            switch (TargetAltSource)
                            {
                                case "00":
                                    TargetAltSource = "Unkown";
                                    break;
                                case "01":
                                    TargetAltSource = "Aircraft altitude";
                                    break;
                                case "10":
                                    TargetAltSource = "FCU/MCP selected altitude";
                                    break;
                                case "11":
                                    TargetAltSource = "FMS selected altitude";
                                    break;
                            }

                            break;
                        case "5.0":
                            RollAngle = (((-1) ^ Convert.ToInt32(BDSDATA[1])) * Convert.ToInt32(String.Concat(BDSDATA[2], BDSDATA[3], BDSDATA[4], BDSDATA[5], BDSDATA[6], BDSDATA[7], BDSDATA[8], BDSDATA[9], BDSDATA[10]), 2) * 45 / 256f).ToString() + " º";

                            float TTA = Convert.ToInt32(String.Concat(BDSDATA[13], BDSDATA[14], BDSDATA[15], BDSDATA[16], BDSDATA[17], BDSDATA[18], BDSDATA[19], BDSDATA[20], BDSDATA[21], BDSDATA[22]), 2) * 90 / 512f % 360;
                            if (((-1) ^ Convert.ToInt32(BDSDATA[12])) == 1 && TTA > 180)
                            {
                                TTA -= 180;
                            }
                            TrueTrackAngle = (TTA).ToString() + " º";
                            GS = (Convert.ToInt32(String.Concat(BDSDATA[24], BDSDATA[25], BDSDATA[26], BDSDATA[27], BDSDATA[28], BDSDATA[29], BDSDATA[30], BDSDATA[31], BDSDATA[32], BDSDATA[33]), 2) * 2f).ToString() + " kt";
                            TrackAngleRate = (((-1) ^ Convert.ToInt32(BDSDATA[35])) * Convert.ToInt32(String.Concat(BDSDATA[36], BDSDATA[37], BDSDATA[38], BDSDATA[39], BDSDATA[40], BDSDATA[41], BDSDATA[42], BDSDATA[43], BDSDATA[44]), 2) * 8 / 256f).ToString() + " º/s";
                            TAS = (Convert.ToInt32(String.Concat(BDSDATA[46], BDSDATA[47], BDSDATA[48], BDSDATA[49], BDSDATA[50], BDSDATA[51], BDSDATA[52], BDSDATA[53], BDSDATA[54], BDSDATA[55]), 2) * 2f).ToString() + " kt";

                            //dataBDSstr = "REP;" + REP.ToString() + ";BDS Version;" + BDSver + ";Roll Angle:;" + RollAngle.ToString() +";True Track Angle:;" +TrueTrackAngle.ToString()+ ";Ground Speed;"+GS.ToString()+";Track Angle Rate:;"+TrackAngleRate.ToString()+";True Air Speed:;" + TAS.ToString();

                            break;
                        case "6.0":
                            MagneticHeading = (Convert.ToInt32(String.Concat(BDSDATA[2], BDSDATA[3], BDSDATA[4], BDSDATA[5], BDSDATA[6], BDSDATA[7], BDSDATA[8], BDSDATA[9], BDSDATA[10], BDSDATA[11]), 2) * 90 / 512f).ToString() + " º";
                            IAS = (Convert.ToInt32(String.Concat(BDSDATA[13], BDSDATA[14], BDSDATA[15], BDSDATA[16], BDSDATA[17], BDSDATA[18], BDSDATA[19], BDSDATA[20], BDSDATA[21], BDSDATA[22]), 2)).ToString() + " kt";
                            MACH = (Convert.ToInt32(String.Concat(BDSDATA[24], BDSDATA[25], BDSDATA[26], BDSDATA[27], BDSDATA[28], BDSDATA[29], BDSDATA[30], BDSDATA[31], BDSDATA[32], BDSDATA[33]), 2) * 4f).ToString();
                            BarometricAlt = (((-1) ^ Convert.ToInt32(BDSDATA[35])) * Convert.ToInt32(String.Concat(BDSDATA[36], BDSDATA[37], BDSDATA[38], BDSDATA[39], BDSDATA[40], BDSDATA[41], BDSDATA[42], BDSDATA[43], BDSDATA[44]), 2) * 32f).ToString() + " ft/min";

                            InertialVerticalVel = (((-1) ^ Convert.ToInt32(BDSDATA[46])) * Convert.ToInt32(String.Concat(BDSDATA[47], BDSDATA[48], BDSDATA[49], BDSDATA[50], BDSDATA[51], BDSDATA[52], BDSDATA[53], BDSDATA[54], BDSDATA[55]), 2) * 32f).ToString() + " ft/min";

                            //dataBDSstr = "Magnetic Heading:;" + MagneticHeading.ToString()+";Indicated Air Speed:;" +IAS.ToString() + ";MACH Number: ;"+MACH.ToString()+ ";Barometric Altitude:;"+ BarometricAlt.ToString()+";Inertial Vertical Velocity;" +InertialVerticalVel.ToString();

                            break;
                        default:
                            //dataBDSstr = "Null";
                            break;
                    }

                    //data.Add(dataBDSstr);

                }

                //data = new List<string> { "BDS version: ", BDSver, "Repetitions", REP.ToString(), "MCP/FCU Selected Altitude: ", MCPSelectedAlt, "FMS Selected Altitude: ", FMSSelectedAlt, "Barometric Pressure Setting: ", BarPressure, "Status of MCP/FCU MODE: ", StatusMCP, "VNAV Mode: ", VNAV, "Alt Hold Mode: ", ALTHoldMode, "Approach Mode: ", APPMode, "Status of target Altitude Source: ", StatusTargetAltSource, "Target Altitude Source: ", TargetAltSource, "Roll Angle: ", RollAngle, "True Track Angle: ", TrueTrackAngle, "GS: ", GS, "Track Angle Rate: ", TrackAngleRate, "TAS: ", TAS, "Magnetic heading: ", MagneticHeading, "IAS: ", IAS, "MACH: ", MACH, "Barometric Altitude Rate: ", BarometricAlt, "Inertial Vertical Velocity", InertialVerticalVel };
                data = new List<string> { BDSver, REP.ToString(), MCPSelectedAlt, FMSSelectedAlt, BarPressure, StatusMCP, VNAV, ALTHoldMode, APPMode, StatusTargetAltSource, TargetAltSource, RollAngle, TrueTrackAngle, GS, TrackAngleRate, TAS, MagneticHeading, IAS, MACH, BarometricAlt, InertialVerticalVel };

                i += REP * 8 + 1;
                items[9] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", 
                    "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(10, data);
            //Item 11
            if (items[10] == true)
            {
                int TrackNumber;
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                string a = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                TrackNumber = Convert.ToInt32(String.Concat(a[4], a[5], a[6], a[7], Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0')), 2);
                data = new List<string> { TrackNumber.ToString() };
                i += 2;
                items[10] = false;
            }
            else
            {
                data = new List<string> { "N/D" };
            }
            SetDataOnDictionary(11, data);

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
                Xcord = Convert.ToInt32(String.Concat(arrayItem[0], arrayItem[1]), 16) / 128f;
                Ycord = Convert.ToInt32(String.Concat(arrayItem[2], arrayItem[3]), 16) / 128f;

                //data = new List<string> { "X", Xcord.ToString() + " NM", "Y", Ycord.ToString() + " NM" };
                data = new List<string> { Xcord.ToString(), Ycord.ToString(), Zcord.ToString() };
                i += 4;
                items[11] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(12, data);

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
                string GSstr = String.Concat(arrayItem[0], arrayItem[1]);

                GS13 = Convert.ToInt32(GSstr, 16);
                GS13 = GS13 * 0.22f;
                HEAD = Convert.ToInt32(String.Concat(arrayItem[2], arrayItem[3]), 16) * 45 / 8192f;

                //data = new List<string> { "Ground Speed", GS.ToString() + " kt", "Heading", HEAD.ToString() + " º"};
                data = new List<string> { GS13.ToString() + " kt", HEAD.ToString() + " º" };
                i += 4;
                items[12] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D" };
            }
            SetDataOnDictionary(13, data);

            //Item 14
            if (items[13] == true)
            {
                string CNF, RAD, DOU, MAH, CDM;
                int FX1;
                string TRE = "N/A", GHO = "N/A", SUP = "N/A", TCC = "N/A";
                int FX2;
                bool found = true;
                arrayItem14.Add(arrayHex[i]);
                while (found)
                {
                    string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[i], 16), 2).PadLeft(8, '0');

                    if (binaryByte[7] == '1')
                    {
                        i++;
                        arrayItem14.Add(arrayHex[i]);
                    }
                    else
                    {
                        i++;
                        found = false;
                        items[13] = false;
                    }
                }
                string a = Convert.ToString(Convert.ToInt32(arrayItem14[0], 16), 2).PadLeft(8, '0');
                CNF = Convert.ToString(a[0]);
                switch (CNF)
                {
                    case "0":
                        CNF = "Confirmed Track";
                        break;
                    case "1":
                        CNF = "Tentative Track";
                        break;
                    default:
                        break;
                }

                RAD = Convert.ToString(String.Concat(a[1], a[2]));
                switch (RAD)
                {
                    case "00":
                        RAD = "Combined Track";
                        break;
                    case "01":
                        RAD = "PSR Track";
                        break;
                    case "10":
                        RAD = "SSR/Mode S Track";
                        break;
                    case "11":
                        RAD = "Invalid";
                        break;
                    default:
                        break;
                }

                DOU = Convert.ToString(a[3]);
                switch (DOU)
                {
                    case "0":
                        DOU = "Normal confidence";
                        break;
                    case "1":
                        DOU = "Low confidence in pilot to track association";
                        break;
                    default:
                        break;
                }

                MAH = Convert.ToString(a[4]);
                switch (MAH)
                {
                    case "0":
                        MAH = "No horizontal manoeuvre sensed";
                        break;
                    case "1":
                        MAH = "Horizontal manoeuvre sensed";
                        break;
                    default:
                        break;
                }

                CDM = Convert.ToString(String.Concat(a[5], a[6]));
                switch (CDM)
                {
                    case "00":
                        CDM = "Maintaining";
                        break;
                    case "01":
                        CDM = "Climbing";
                        break;
                    case "10":
                        CDM = "Descending";
                        break;
                    case "11":
                        CDM = "Unknown";
                        break;
                    default:
                        break;
                }

                FX1 = Convert.ToInt32(a[7]);

                if (FX1 == 1)
                {
                    string b = Convert.ToString(Convert.ToInt32(arrayItem14[1], 16), 2).PadLeft(8, '0');
                    TRE = Convert.ToString(b[0]);
                    switch (TRE)
                    {
                        case "0":
                            TRE = "Track still alive";
                            break;
                        case "1":
                            TRE = "End of track lifetime";
                            break;
                        default:
                            break;
                    }

                    GHO = Convert.ToString(b[1]);
                    switch (GHO)
                    {
                        case "0":
                            GHO = "True target track";
                            break;
                        case "1":
                            GHO = "Ghost target track";
                            break;
                        default:
                            break;
                    }

                    SUP = Convert.ToString(b[2]);
                    switch (SUP)
                    {
                        case "0":
                            SUP = "No";
                            break;
                        case "1":
                            SUP = "Yes";
                            break;
                        default:
                            break;
                    }

                    TCC = Convert.ToString(b[3]);
                    switch (TCC)
                    {
                        case "0":
                            TCC = "Tracking in Radar-Plane mode";
                            break;
                        case "1":
                            TCC = "Slant range correction";
                            break;
                        default:
                            break;
                    }

                    FX2 = Convert.ToInt32(b[7]);
                }

                //data = new List<string>{ "CNF", CNF, "RAD", RAD, "DOU", DOU, "MAH", MAH, "CDM", CDM, "TRE", TRE, "GHO", GHO, "SUP", SUP, "TCC", TCC};
                data = new List<string> { CNF, RAD, DOU, MAH, CDM, TRE, GHO, SUP, TCC };
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(14, data);

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
                int Height3D;
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                string a = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                Height3D = Convert.ToInt32(String.Concat(a[2], a[3], a[4], a[5], a[6], a[7], Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0')), 2) * 25;

                //data = new List<string> { "3D Height", Height3D.ToString() + " ft" };
                data = new List<string> { Height3D.ToString() + " ft" };
                i += 2;
                items[18] = false;
            }
            else
            {
                data = new List<string> { "N/D" };
            }
            SetDataOnDictionary(19, data);
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
                        found = false;
                    }
                }
            }
            //Item 21
            if (items[20] == true)
            {
                string COM, STAT, SI, MSSC, ARC, AIC, B1A, B1B;
                
                arrayItem = new List<string>
                {
                    arrayHex[i],
                    arrayHex[i + 1]
                };
                string binaryByte = Convert.ToString(Convert.ToInt32(arrayItem[0], 16), 2).PadLeft(8, '0');
                string comVector = Convert.ToString(binaryByte[0]) + Convert.ToString(binaryByte[1]) + Convert.ToString(binaryByte[2]);
                string statVector = Convert.ToString(binaryByte[3]) + Convert.ToString(binaryByte[4]) + Convert.ToString(binaryByte[5]);
                string si = Convert.ToString(binaryByte[6]);
                string com = Convert.ToString(Convert.ToInt32(comVector, 2));
                string stat = Convert.ToString(Convert.ToInt32(statVector, 2));
                statINT = Convert.ToInt32(stat);

                string binaryByte2 = Convert.ToString(Convert.ToInt32(arrayItem[1], 16), 2).PadLeft(8, '0');
                string mssc = Convert.ToString(binaryByte2[0]);
                string arc = Convert.ToString(binaryByte2[1]);
                string aic = Convert.ToString(binaryByte2[2]);
                string b1a = Convert.ToString(binaryByte2[3]);
                string b1b = Convert.ToString(binaryByte2[4]) + Convert.ToString(binaryByte2[5]) + Convert.ToString(binaryByte2[6]) + Convert.ToString(binaryByte2[7]);
                B1A = b1a;
                B1B = b1b;
                if (Convert.ToInt32(com) == 0)
                {
                    COM = "No communications capability (surveillance only)";
                }
                else if (Convert.ToInt32(com) == 1)
                {
                    COM = "Comm. A and Comm. B capability";
                }
                else if (Convert.ToInt32(com) == 2)
                {
                    COM = "Comm. A, Comm. B and Uplink ELM";
                }
                else if (Convert.ToInt32(com) == 3)
                {
                    COM = "Comm. A, Comm. B, Uplink ELM and Downlink";
                }
                else if (Convert.ToInt32(com) == 4)
                {
                    COM = "Level 5 Transponder capability";
                }
                else
                {
                    COM = "Not assigned";
                }

                if (Convert.ToInt32(stat) == 0)
                {
                    STAT = "No alert, no SPI, aircraft airborne";
                }
                else if (Convert.ToInt32(stat) == 1)
                {
                    STAT = "No alert, no SPI, aircraft on ground";
                }
                else if (Convert.ToInt32(stat) == 2)
                {
                    STAT = "Alert, no SPI, aircraft airborne";
                }
                else if (Convert.ToInt32(stat) == 3)
                {
                    STAT = "Alert, no SPI, aircraft on ground";
                }
                else if (Convert.ToInt32(stat) == 4)
                {
                    STAT = "Alert,SPI, aircraft airborne or on ground";
                }
                else if (Convert.ToInt32(stat) == 5)
                {
                    STAT = "No alert,SPI, aircraft airborne or on ground";
                }
                else if (Convert.ToInt32(stat) == 6)
                {
                    STAT = "Not assigned";
                }
                else if (Convert.ToInt32(stat) == 7)
                {
                    STAT = "Unknown";
                }
                else
                {
                    STAT = "Not assigned";
                }

                if (Convert.ToInt32(si, 2) == 0)
                {
                    SI = "Transponder capable on SI";
                }
                else
                {
                    SI = "Transponder capable on II";
                }
                if (Convert.ToInt32(mssc, 2) == 0)
                {
                    MSSC = "Not Capability of the specific service of the Mode-S";
                }
                else
                {
                    MSSC = "Capability of the specific service of the Mode-S";
                }
                if (Convert.ToInt32(arc, 2) == 0)
                {
                    ARC = "100ft of resolution";
                }
                else
                {
                    ARC = "25ft of resolution";
                }
                if (Convert.ToInt32(aic, 2) == 0)
                {
                    AIC = "Not capable of identify itself";
                }
                else
                {
                    AIC = "Capable of identifying itself";
                }

                //data = new List<string> { "COM", COM.ToString(),"STAT",STAT.ToString(), "SI", SI.ToString(), "MSSC", MSSC, "ARC",ARC.ToString(), "AIC",AIC.ToString(), "B1A",B1A.ToString(), "B1B",B1B.ToString() };
                data = new List<string> { COM.ToString(), STAT.ToString(), SI.ToString(), MSSC, ARC.ToString(), AIC.ToString(), B1A.ToString(), B1B.ToString().PadLeft(4, '0') };
                i += 2;
                items[20] = false;
            }
            else
            {
                data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
            }
            SetDataOnDictionary(21, data);
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

            //Calculate positioning of all the aircrafts (As dere is no dataItem 12, we will put the geolocation data there)
            CoordinatesPolar radarPolar;
            //If the .FL is negative we change it to 0;          
            double asin;

            if (FL < 60)
            {
                if (FMSSelectedAlt == "N/A" || FMSSelectedAlt == "N/D")
                {
                    double correctedAltitude1 = FL * 100 + (floatBarPressure - 1013.25) * 30;
                    if (correctedAltitude1 < 0)
                    {
                        asin = 0;
                    }
                    else
                    {

                        asin = (2 * 6371000 * ((correctedAltitude1 * 0.3048) - 2.007 - 25.25) + (correctedAltitude1 * 0.3048) * (correctedAltitude1 * 0.3048) - (2.007 + 25.25) * (2.007 + 25.25) - (RHO * 1852) * RHO * 1852) / ((2 * RHO * 1852) * (6371000 + 2.007 + 25.25));
                    }
                    radarPolar = new CoordinatesPolar(RHO * 1852, THETA * (Math.PI / 180), Math.Asin(asin));
                }
                else
                {
                    if (FL == -9999)
                    {
                        asin = 0;
                    }
                    else
                    {

                        double correctedAltitude1 = FL * 100 + (floatBarPressure - 1013.25) * 30; //MCP
                        //double correctedAltitude2 = intFMSSelectedAlt + (floatBarPressure - 1013.25) * 30; //FMS

                        if (correctedAltitude1 < 0)
                        {
                            correctedAltitude1 = 0;
                        }

                        asin = (2 * 6371000 * ((correctedAltitude1 * 0.3048) - 2.007 - 25.25) + (correctedAltitude1 * 0.3048) * 
                            (correctedAltitude1 * 0.3048) - (2.007 + 25.25) * (2.007 + 25.25) - 
                            (RHO * 1852) * RHO * 1852) / ((2 * RHO * 1852) * (6371000 + 2.007 + 25.25));
                        /*
                        if (asin > 1)
                        {
                            asin = (2 * 6371000 * ((correctedAltitude2 * 0.3048) - 2.007 - 25.25) + (correctedAltitude2 * 0.3048) * (correctedAltitude2 * 0.3048) - (2.007 + 25.25) * (2.007 + 25.25) - (RHO * 1852) * RHO * 1852) / ((2 * RHO * 1852) * (6371000 + 2.007 + 25.25));
                        }*/

                        if (asin > 1)
                        {
                            asin = 1;
                        }


                    }
                    radarPolar = new CoordinatesPolar(RHO * 1852, THETA * (Math.PI / 180), Math.Asin(asin));
                }
            }
            else
            {
                asin = (2 * 6371000 * ((FL * 100 * 0.3048) - 2.007 - 25.25) + 
                    (FL * 100 * 0.3048) * (FL * 100 * 0.3048) - (2.007 + 25.25) * (2.007 + 25.25) - 
                    (RHO * 1852) * RHO * 1852) / ((2 * RHO * 1852) * (6371000 + 2.007 + 25.25));
                radarPolar = new CoordinatesPolar(RHO * 1852, THETA * (Math.PI / 180), Math.Asin(asin));
            }
            //Here we change from spherical (rho,theta,elevation) to cartesian (X,Y,Z)        
            CoordinatesXYZ radarCartesian = GeoUtils.change_radar_spherical2radar_cartesian(radarPolar);

            //Here we take the LatLon WGS84 of the radar on a point to change from cartesian to geocentric
            CoordinatesWGS84 radarCoordinates = new CoordinatesWGS84(41.3007023 * (Math.PI / 180), 2.10205819444 * (Math.PI / 180), 2.007 + 25.25);
            //Coordinates of the radar on geographical are comented for now
            //CoordinatesWGS84 radarCoordinates = new CoordinatesWGS84("41º 18’ 02,5284’’ N", "02º 06’ 07,4095’’ E", 2.007 + 25.25);

            //Here we change from cartesian to geocentric
            CoordinatesXYZ geocentricSystem = geoUtils.change_radar_cartesian2geocentric(radarCoordinates, radarCartesian);

            //And finally here we change from geocentric to geodesic coordinates (Lat,Lon,Altitude)
            CoordinatesWGS84 geodesic = geoUtils.change_geocentric2geodesic(geocentricSystem);

            //And we set the Latitude,Longitude and altitude on the DataItem12 that we know that is empty
            SetData12((float)geodesic.Lat * (180 / Math.PI), (float)geodesic.Lon * (180 / Math.PI), (float)geodesic.Height);           

        }
        public void SetDataOnDictionary(int i, List<string> data)
        {
            decodedDataPerItem.Add(i, data);
        }
        public void EditDataOnDictionary(int i, List<string> data)
        {
            decodedDataPerItem[i] = data;
        }
        public Dictionary<int, List<string>> GetDataDecodedPerItem()
        {
            return decodedDataPerItem;
        }
        public string Decode6bit(string a)
        {
            string result;

            switch (a)
            {
                case "000001":
                    result = "A"; break;
                case "000010":
                    result = "B"; break;
                case "000011":
                    result = "C"; break;
                case "000100":
                    result = "D"; break;
                case "000101":
                    result = "E"; break;
                case "000110":
                    result = "F"; break;
                case "000111":
                    result = "G"; break;
                case "001000":
                    result = "H"; break;
                case "001001":
                    result = "I"; break;
                case "001010":
                    result = "J"; break;
                case "001011":
                    result = "K"; break;
                case "001100":
                    result = "L"; break;
                case "001101":
                    result = "M"; break;
                case "001110":
                    result = "N"; break;
                case "001111":
                    result = "O"; break;
                case "010000":
                    result = "P"; break;
                case "010001":
                    result = "Q"; break;
                case "010010":
                    result = "R"; break;
                case "010011":
                    result = "S"; break;
                case "010100":
                    result = "T"; break;
                case "010101":
                    result = "U"; break;
                case "010110":
                    result = "V"; break;
                case "010111":
                    result = "W"; break;
                case "011000":
                    result = "X"; break;
                case "011001":
                    result = "Y"; break;
                case "011010":
                    result = "Z"; break;
                case "110000":
                    result = "0"; break;
                case "110001":
                    result = "1"; break;
                case "110010":
                    result = "2"; break;
                case "110011":
                    result = "3"; break;
                case "110100":
                    result = "4"; break;
                case "110101":
                    result = "5"; break;
                case "110110":
                    result = "6"; break;
                case "110111":
                    result = "7"; break;
                case "111000":
                    result = "8"; break;
                case "111001":
                    result = "9"; break;
                case "100000":
                    result = " "; break; //espacio
                default:
                    result = "·"; break; //no coincide con ninguno
            }

            return result;
        }
        public void SetData12(double X, double Y, double Z)
        {
            Xcord = X;
            Ycord = Y;
            Zcord = Z;
            data = new List<string> { X.ToString() + "º", Y.ToString() + "º", Z.ToString() + "m" };
            EditDataOnDictionary(12, data);
        }
    }
}
