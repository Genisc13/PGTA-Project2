﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MultiCAT6.Utils;
using VisioForge.Libs.MediaFoundation.OPM;
using System.Security.Cryptography;

namespace ProyectoPGTA_P2
{

    public class DataItem
    {
        public DataItem1 item1;
        public DataItem2 item2;
        public DataItem3 item3;
        public DataItem4 item4;
        public DataItem5 item5;
        public DataItem6 item6;
        public DataItem7 item7;
        public DataItem8 item8;
        public DataItem9 item9;
        public DataItem10 item10;
        public DataItem11 item11;
        public DataItem12 item12;
        public DataItem13 item13;
        public DataItem14 item14;
        public DataItem15 item15;
        public DataItem16 item16;
        public DataItem17 item17;
        public DataItem18 item18;
        public DataItem19 item19;
        public DataItem20 item20;
        public DataItem21 item21;
        public DataItem22 item22;
        public DataItem23 item23;
        public DataItem24 item24;
        public DataItem25 item25;
        public DataItem26 item26;
        public DataItem27 item27;
        public DataItem28 item28;
        public DataItem()
        {
            this.item1 = null;
            this.item2 = null;
            this.item3 = null;
            this.item4 = null;
            this.item5 = null;
            this.item6 = null;
            this.item7 = null;
            this.item8 = null;
            this.item9 = null;
            this.item10 = null;
            this.item11 = null;
            this.item12 = null;
            this.item13 = null;
            this.item14 = null;
            this.item15 = null;
            this.item16 = null;
            this.item17 = null;
            this.item18 = null;
            this.item19 = null;
            this.item20 = null;
            this.item21 = null;
            this.item22 = null;
            this.item23 = null;
            this.item24 = null;
            this.item25 = null;
            this.item26 = null;
            this.item27 = null;
            this.item28 = null;
        }
        public void SetDataItem1(DataItem1 item1)
        {
            this.item1 = item1;
        }
        public DataItem1 GetDataItem1()
        {
            return item1;
        }
        public void SetDataItem2(DataItem2 item2)
        {
            this.item2 = item2;
        }
        public DataItem2 GetDataItem2()
        {
            return item2;
        }
        public void SetDataItem3(DataItem3 item3)
        {
            this.item3 = item3;
        }
        public DataItem3 GetDataItem3()
        {
            return item3;
        }
        public void SetDataItem4(DataItem4 item4)
        {
            this.item4 = item4;
        }
        public DataItem4 GetDataItem4()
        {
            return item4;
        }
        public void SetDataItem5(DataItem5 item5)
        {
            this.item5 = item5;
        }
        public DataItem5 GetDataItem5()
        {
            return item5;
        }
        public void SetDataItem6(DataItem6 item6)
        {
            this.item6 = item6;
        }
        public DataItem6 GetDataItem6()
        {
            return item6;
        }
        public void SetDataItem7(DataItem7 item7)
        {
            this.item7 = item7;
        }
        public DataItem7 GetDataItem7()
        {
            return item7;
        }
        public void SetDataItem8(DataItem8 item8)
        {
            this.item8 = item8;
        }
        public DataItem8 GetDataItem8()
        {
            return item8;
        }
        public void SetDataItem9(DataItem9 item9)
        {
            this.item9 = item9;
        }
        public DataItem9 GetDataItem9()
        {
            return item9;
        }
        public void SetDataItem10(DataItem10 item10)
        {
            this.item10 = item10;
        }
        public DataItem10 GetDataItem10()
        {
            return item10;
        }
        public void SetDataItem11(DataItem11 item11)
        {
            this.item11 = item11;
        }
        public DataItem11 GetDataItem11()
        {
            return item11;
        }
        public void SetDataItem12(DataItem12 item12)
        {
            this.item12 = item12;
        }
        public DataItem12 GetDataItem12()
        {
            return item12;
        }
        public void SetDataItem13(DataItem13 item13)
        {
            this.item13 = item13;

        }
        public DataItem13 GetDataItem13()
        {
            return item13;
        }
        public void SetDataItem14(DataItem14 item14)
        {
            this.item14 = item14;
        }
        public DataItem14 GetDataItem14()
        {
            return item14;
        }
        public void SetDataItem15(DataItem15 item15)
        {
            this.item15 = item15;
        }
        public DataItem15 GetDataItem15()
        {
            return item15;
        }
        public void SetDataItem16(DataItem16 item16)
        {
            this.item16 = item16;
        }
        public DataItem16 GetDataItem16()
        {
            return item16;
        }
        public void SetDataItem17(DataItem17 item17)
        {
            this.item17 = item17;
        }
        public DataItem17 GetDataItem17()
        {
            return item17;
        }
        public void SetDataItem18(DataItem18 item18)
        {
            this.item18 = item18;
        }
        public DataItem18 GetDataItem18()
        {
            return item18;
        }
        public void SetDataItem19(DataItem19 item19)
        {
            this.item19 = item19;
        }
        public DataItem19 GetDataItem19()
        {
            return item19;
        }
        public void SetDataItem20(DataItem20 item20)
        {
            this.item20 = item20;
        }
        public DataItem20 GetDataItem20()
        {
            return item20;
        }
        public void SetDataItem21(DataItem21 item21)
        {
            this.item21 = item21;
        }
        public DataItem21 GetDataItem21()
        {
            return item21;
        }
        public void SetDataItem22(DataItem22 item22)
        {
            this.item22 = item22;
        }
        public DataItem22 GetDataItem22()
        {
            return item22;
        }
        public void SetDataItem23(DataItem23 item23)
        {
            this.item23 = item23;
        }
        public DataItem23 GetDataItem23()
        {
            return item23;
        }
        public void SetDataItem24(DataItem24 item24)
        {
            this.item24 = item24;
        }
        public DataItem24 GetDataItem24()
        {
            return item24;
        }
        public void SetDataItem25(DataItem25 item25)
        {
            this.item25 = item25;
        }
        public DataItem25 GetDataItem25()
        {
            return item25;
        }
        public void SetDataItem26(DataItem26 item26)
        {
            this.item26 = item26;
        }
        public DataItem26 GetDataItem26()
        {
            return item26;
        }
        public void SetDataItem27(DataItem27 item27)
        {
            this.item27 = item27;
        }
        public DataItem27 GetDataItem27()
        {
            return item27;
        }
        public void SetDataItem28(DataItem28 item28)
        {
            this.item28 = item28;
        }
        public DataItem28 GetDataItem28()
        {
            return item28;
        }
    }
    
    //Data Item I048/010, Data Source Identifier
    public class DataItem1
    {
        public int number;
        public List<string> arrayHex;

        //DATA ITEM 1
        public string SAC, SIC;
        public List<string> data;

        public DataItem1() {
            data = new List<string> { "N/D", "N/D" };
        }

        public DataItem1(List<string> arrayhex)
        {
            this.number = 1;
            this.arrayHex = arrayhex;

            SAC = arrayhex[0];
            SIC = arrayhex[1];
            int SACint = Convert.ToInt32(SAC, 16);
            int SICint = Convert.ToInt32(SIC, 16);

            data = new List<string> { SACint.ToString(), SICint.ToString() };
        }

        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item 2: Data Item I048/140, Time of Day
    public class DataItem2
    {
        public int number;
        public List<string> arrayHex;
        public string[] arrayString;

        //DATA ITEM 2
        public string timestr = "";
        public float time;

        public List<string> data;

        public DataItem2()
        {
            //data = new List<string> { "Time", "N/D" };
            data = new List<string> { "N/D" };
        }

        public DataItem2(List<string> arrayhex)
        {
            this.number = 2;
            this.arrayHex = arrayhex;

           arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
                this.timestr += arrayString[i];
            }

            this.time = Convert.ToInt32(timestr,2) / 128f; //hora actual en segundos

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
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/020, Target Report Descriptor
    public class DataItem3
    {
        public int number;
        public List<string> arrayHex;

        public List<string> arrayString;
        public string TYP = "N/A";
        public string SIM = "N/A";
        public string RDP = "N/A";
        public string SPI = "N/A";
        public string RAB = "N/A";
        public string FX1 = "N/A";
        public string TST = "N/A";
        public string ERR = "N/A";
        public string XPP = "N/A", ME = "N/A", MI = "N/A", FOE_FRI = "N/A";
        public string FX2 = "N/A";
        public string ADSB_EP = "N/A", ADSB_VAL = "N/A", SCN_EP = "N/A", SCN_VAL = "N/A", PAI_EP = "N/A", PAI_VAL = "N/A";

        public List<string> data;
        
        public DataItem3()
        {
            //data = new List<string> { "TYP", "N/D", "SIM", "N/D", "RDP", "N/D", "SPI", "N/D", "RAB", "N/D", "TST", "N/D", "ERR", "N/D", "XPP", "N/D", "ME", "N/D", "MI", "N/D", "FOE/FRI", "N/D", "ADSB_EP", "N/D", "ADSB_VAL", "N/D", "SCN_EP", "N/D", "SCN_VAL", "N/D", "PAI_EP", "N/D", "PAI_VAL", "N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };

        }

        public DataItem3(List<string> arrayhex)
        {
            this.number = 3;
            this.arrayHex = arrayhex;
            this.arrayString = new List<string>(arrayhex.Count);

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString.Add(Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0'));
            }

            //First part decode
            string a = arrayString[0];

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
                string b = arrayString[1];

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
                    string c = arrayString[2];

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
        public List<string> GetData()
        {
            return this.data;
        }
    }
    //Measured position of an aircraft in local polar co-ordinates
    public class DataItem4
    {
        public int number;
        public List<string> arrayHex;

        public float RHO, THETA;
        public List<string> data;

        public DataItem4()
        {
            //data = new List<string> { "RHO", "N/D", "THETA", "N/D" };
            data = new List<string> { "N/D", "N/D" };
        }

        public DataItem4(List<string> arrayhex)
        {
            this.number = 4;
            this.arrayHex = arrayhex;

            int count = arrayhex.Count;

            string RHD_16 = String.Concat(arrayhex[0].PadLeft(2, '0'), arrayhex[1].PadLeft(2, '0'));
            string THETA_16 = String.Concat(arrayhex[2].PadLeft(2, '0'), arrayhex[3].PadLeft(2, '0'));

            RHO = (float)Math.Round(Convert.ToInt32(RHD_16, 16) / 256d, 4);

            THETA = (float)Math.Round(Convert.ToInt32(THETA_16, 16) * 45 / 8192f,4);

            //data = new List<string> { "RHO", RHD.ToString() + " NM", "THETA", THETA.ToString() + " º"};
            data = new List<string> { RHO.ToString() + " NM", THETA.ToString() + " º" };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    // Data Item I048/070, Mode-3/A Code in Octal Representation
    public class DataItem5
    {
        public int number;
        public List<string> arrayHex;
        public List<string> arrayString;

        public string V, G, L, Mode3;
        public List<string> data;

        public DataItem5()
        {
            //data = new List<string> { "V", "N/D", "G", "N/D", "L", "N/D", "Mode3", "N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D" };
        }
        public DataItem5(List<string> arrayhex)
        {
            this.number = 5;
            this.arrayHex = arrayhex;

            this.arrayString = new List<string>(arrayhex.Count);

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString.Add(Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0'));
            }

            V = arrayString[0][0].ToString();
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

            G = arrayString[0][1].ToString();
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

            L = arrayString[0][2].ToString();
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

            Mode3 = string.Concat(arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7], arrayString[1]);
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
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Flight Level converted into binary representation
    public class DataItem6
    {
        public int number;
        public List<string> arrayHex;
        public List<string> arrayString;

        public string V, G;
        public float FL;
        public List<string> data;

        public DataItem6()
        {
            //data = new List<string> { "V", "N/D", "G", "N/D", "FL", "N/D"};
            data = new List<string> { "N/D", "N/D", "N/D" };
            FL = -9999;
        }

        public DataItem6(List<string> arrayhex)
        {
            this.number = 6;
            this.arrayHex = arrayhex;

            this.arrayString = new List<string>(arrayhex.Count);

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString.Add(Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0'));
            }

            V = arrayString[0][0].ToString();
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

            G = arrayString[0][1].ToString();
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

            string FL_BIN = String.Concat(arrayString[0][2], arrayString[0][3], arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7], arrayString[1]);
            string FL_BIN1 = String.Concat(arrayString[0][2], arrayString[0][3], arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7]);
            string FL_BIN2 = String.Concat(arrayString[1]);

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
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Radar plot characteristics
    public class DataItem7
    {
        public int number;
        public List<string> arrayHex;
        public List<string> arrayString = new List<string>();

        public string SRL, SRR, SAM, PRL, PAM, RPD, APD;
        public string FX1;
        public List<string> data;

        public DataItem7()
        {
            //data = new List<string> { "SRL", "N/D", "SRR", "N/D", "SAM", "N/D", "PRL", "N/D", "PAM", "N/D", "RPD", "N/D", "APD","N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
        }

        public DataItem7(List<string> arrayhex)
        {
            this.number = 7;
            this.arrayHex = arrayhex;

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString.Add(Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0'));
            }
            int index = 1;

            SRL = arrayString[0][0].ToString();
            if (SRL == "1")
            {
                SRL = arrayString[index];
                SRL = (Convert.ToInt32(SRL, 2) * 45 / 1024f).ToString() + " dg";

                index++;
            }
            else
            {
                SRL = "N/A";
            }

            SRR = arrayString[0][1].ToString();
            if (SRR == "1")
            {
                SRR = arrayString[index];
                SRR = (Convert.ToInt32(SRR, 2)).ToString();

                index++;

            }
            else
            {
                SRR = "N/A";
            }

            SAM = arrayString[0][2].ToString();

            if (SAM == "1")
            {
                SAM = arrayString[index];
                
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

            PRL = arrayString[0][3].ToString();
            if (PRL == "1")
            {
                PRL = arrayString[index];
                PRL = (Convert.ToInt32(PRL, 2) * 45 / 1024f).ToString() + " dg";

                index++;

            }
            else
            {
                PRL = "N/A";
            }

            PAM = arrayString[0][4].ToString();
            if (PAM == "1")
            {
                PAM = arrayString[index];
                PAM = (Convert.ToInt32(PAM, 2)).ToString() + " dbm";

                index++;

            }
            else
            {
                PAM = "N/A";
            }

            RPD = arrayString[0][5].ToString();
            if (RPD == "1")
            {
                RPD = arrayString[index];
                RPD = (Convert.ToInt32(RPD, 2) / 256f).ToString() + " NM";

                index++;

            }
            else
            {
                RPD = "N/A";
            }

            APD = arrayString[0][6].ToString();
            if (APD == "1")
            {
                APD = arrayString[index];
                APD = (Convert.ToInt32(APD, 2) * 45 / 2048f).ToString() + " dg";

                index++;

            }
            else
            {
                APD = "N/A";
            }

            //data = new List<string> { "SRL", SRL, "SRR", SRR, "SAM", SAM, "PRL", PRL, "PAM", PAM, "RPD", RPD, "APD", APD };
            data = new List<string> { SRL, SRR, SAM, PRL, PAM, RPD, APD };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/220, Aircraft Address
    public class DataItem8
    {
        public int number;
        public List<string> arrayHex;
        public string AircraftAddress;

        public List<string> data;

        public DataItem8()
        {
            //data = new List<string>{ "Aircraft Address", "N/D" };
            data = new List<string> { "N/D" };
        }

        public DataItem8(List<string> arrayhex)
        {
            this.number = 8;
            this.arrayHex = arrayhex;

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayhex[i] = arrayhex[i].PadLeft(2, '0');
            }

            AircraftAddress = String.Concat(this.arrayHex[0], this.arrayHex[1], this.arrayHex[2]);
            //data = new List<string> { "Aircraft Address", AircraftAddress };
            data = new List<string> { AircraftAddress };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/240, Aircraft Identification
    public class DataItem9
    {
        public int number;
        public List<string> arrayHex;
        public List<string> arrayString;
        public string completeArraystring;
        public string[] AAmatrix = new string[8];
        public string AircraftIdentification;

        public List<string> data;

        public DataItem9()
        {
            //data = new List<string> { "Aircraft Identification", "N/D" };
            data = new List<string> { "N/D" };
        }

        public DataItem9(List<string> arrayhex)
        {
            this.number = 9;
            this.arrayHex = arrayhex;
            this.completeArraystring = "";
            this.arrayString = new List<string>(arrayhex.Count);

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString.Add(Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0'));
            }
            for (int i=0; i< arrayHex.Count; i++)
            {
                completeArraystring = completeArraystring.ToString() + arrayString[i].ToString();
            }           
            string[] AA = new string[8];

            for (int i = 0;i < AA.Length; i++)
            {
                AA[i] = String.Concat(completeArraystring[i*6].ToString(), completeArraystring[i*6+1].ToString(), completeArraystring[i*6+2].ToString(), completeArraystring[i*6+3].ToString(), completeArraystring[i*6+4].ToString(), completeArraystring[i*6+5].ToString());

                AAmatrix[i] = decode6bit(AA[i]);
            }

            AircraftIdentification = String.Join("", AAmatrix);

            //data = new List<string> { "Aircraft Identification", AircraftIdentification};
            data = new List<string> { AircraftIdentification };
        }

        public string decode6bit(string a)
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

        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I0458/250, BDS Register Data
    public class DataItem10
    {
        public int number;
        public List<string> arrayHex;
        public string[] arrayString;
        public int REP = -9999;
        public List<string> data = new List<string>();
        //Param BDS4.0
        public string MCPSelectedAlt="N/D";
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
        public DataItem10()
        {
            //data = new List<string> { "BDS version: ", "N/D", "Repetitions", "N/D", "MCP/FCU Selected Altitude: ", "N/D", "FMS Selected Altitude: ", "N/D", "Barometric Pressure Setting: ", "N/D", "Status of MCP/FCU MODE: ", "N/D", "VNAV Mode: ", "N/D", "Alt Hold Mode: ", "N/D", "Approach Mode: ", "N/D", "Status of target Altitude Source: ", "N/D", "Target Altitude Source: ", "N/D", "Roll Angle: ", "N/D" , "True Track Angle: ", "N/D", "GS: ", "N/D", "Track Angle Rate: ", "N/D", "TAS: ", "N/D",  "Magnetic heading: ", "N/D", "IAS: ", "N/D", "MACH: ", "N/D", "Barometric Altitude Rate: ", "N/D", "Inertial Vertical Velocity", "N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
        }
        public DataItem10(List<string> arrayhex)
        {
            this.number = 10;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Count];
            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }
            REP = Convert.ToInt32(arrayString[0], 2);

            string BDSDATA = "N/A", BDSver = "";
            string BDS1 = "N/A", BDS2 = "N/A";

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

            for (int i = 0; i < REP; i++)
            {
                int shift = i * 8;
                BDSDATA = String.Concat(arrayString[shift + 1], arrayString[shift + 2], arrayString[shift + 3], arrayString[shift + 4], arrayString[shift + 5], arrayString[shift + 6], arrayString[shift + 7]);

                //string dataBDSstr;
                string actual_BDSver;
                BDS1 = Convert.ToInt32(String.Concat(arrayString[shift + 8][0], arrayString[shift + 8][1], arrayString[shift + 8][2], arrayString[shift + 8][3]), 2).ToString();
                BDS2 = Convert.ToInt32(String.Concat(arrayString[shift + 8][4], arrayString[shift + 8][5], arrayString[shift + 8][6], arrayString[shift + 8][7]), 2).ToString();

                if(BDSver == "")
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
                        if(((-1) ^ Convert.ToInt32(BDSDATA[12])) == 1 && TTA > 180)
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
            data = new List<string> { BDSver, REP.ToString(), MCPSelectedAlt, FMSSelectedAlt, BarPressure, StatusMCP, VNAV, ALTHoldMode, APPMode, StatusTargetAltSource, TargetAltSource, RollAngle, TrueTrackAngle,  GS, TrackAngleRate, TAS, MagneticHeading, IAS, MACH, BarometricAlt, InertialVerticalVel };

        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item 11: Data Item I048/161, Track Number
    public class DataItem11
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public int TrackNumber;

        public string[] arrayString;

        public DataItem11()
        {
            //data = new List<string> { "Track Number", "N/D"};
            data = new List<string> { "N/D" };
        }

        public DataItem11(List<string> arrayhex)
        {
            this.number = 11;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }

            TrackNumber = Convert.ToInt32(String.Concat(arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7], arrayString[1]), 2);

            //data = new List<string> { "Track Number", TrackNumber.ToString()};
            data = new List<string> { TrackNumber.ToString() };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Calculated position in cartesian coordinates
    public class DataItem12
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public double Xcord, Ycord, Zcord;
        public string[] arrayString;

        public DataItem12()
        {
            //data = new List<string> { "X", "N/D", "Y", "N/D" };
            data = new List<string> { "N/D", "N/D" , "N/D"};
        }

        public DataItem12(List<string> arrayhex)
        {
            this.number = 12;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }

            Xcord = Convert.ToInt32(String.Concat(arrayString[0], arrayString[1]))/128f;
            Ycord = Convert.ToInt32(String.Concat(arrayString[2], arrayString[3]))/128f;

            //data = new List<string> { "X", Xcord.ToString() + " NM", "Y", Ycord.ToString() + " NM" };
            data = new List<string> { Xcord.ToString() , Ycord.ToString(), Zcord.ToString() };
        }
        public void SetData(double X, double Y, double Z)
        {
            Xcord = X;
            Ycord = Y;
            Zcord = Z;
            data = new List<string> { X.ToString() + "º", Y.ToString() + "º", Z.ToString() + "m" };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Velocity calculated and expressed on polar coordinates
    public class DataItem13
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public float GS, HEAD;
        public string[] arrayString;

        public DataItem13()
        {
            //data = new List<string> { "Ground Speed", "N/D", "Heading", "N/D" };
            data = new List<string> { "N/D", "N/D" };
        }
        
        public DataItem13(List<string> arrayhex)
        {
            this.number = 13;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }

            string GSstr = String.Concat(arrayString[0], arrayString[1]);

            GS = Convert.ToInt32(GSstr, 2);
            GS = GS * 0.22f;
            HEAD = Convert.ToInt32(String.Concat(arrayString[2], arrayString[3]), 2) * 45 / 8192f;

            //data = new List<string> { "Ground Speed", GS.ToString() + " kt", "Heading", HEAD.ToString() + " º"};
            data = new List<string> { GS.ToString() + " kt", HEAD.ToString() + " º" };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Track status
    public class DataItem14
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public string CNF = "N/A", RAD = "N/A", DOU = "N/A", MAH = "N/A", CDM = "N/A";
        public int FX1;
        public string TRE = "N/A", GHO = "N/A", SUP = "N/A", TCC = "N/A";
        public int FX2;

        public string[] arrayString;

        public DataItem14()
        {
            //data = new List<string> { "CNF", "N/D", "RAD", "N/D", "DOU", "N/D", "MAH", "N/D", "CDM", "N/D", "TRE", "N/D", "GHO", "N/D", "SUP", "N/D", "TCC", "N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
        }

        public DataItem14(List<string> arrayhex)
        {
            this.number = 14;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }
            CNF = Convert.ToString(arrayString[0][0]);
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

            RAD = Convert.ToString(String.Concat(arrayString[0][1], arrayString[0][2]));
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

            DOU = Convert.ToString(arrayString[0][3]);
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

            MAH = Convert.ToString(arrayString[0][4]);
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

            CDM = Convert.ToString(String.Concat(arrayString[0][5], arrayString[0][6]));
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

            FX1 = Convert.ToInt32(arrayString[0][7]);

            if (FX1 == 1 ){ 
                TRE = Convert.ToString(arrayString[1][0]);
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

                GHO = Convert.ToString(arrayString[1][1]);
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

                SUP = Convert.ToString(arrayString[1][2]);
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

                TCC = Convert.ToString(arrayString[1][3]);
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

                FX2 = Convert.ToInt32(arrayString[1][7]);
             }

            //data = new List<string>{ "CNF", CNF, "RAD", RAD, "DOU", DOU, "MAH", MAH, "CDM", CDM, "TRE", TRE, "GHO", GHO, "SUP", SUP, "TCC", TCC};
            data = new List<string> { CNF, RAD, DOU, MAH, CDM, TRE, GHO, SUP, TCC };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/210, Track Quality 
    public class DataItem15
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem15(List<string> arrayhex)
        {
            this.number = 15;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item 16: Data Item I048/030, Warning/Error Conditions and Target Classification
    public class DataItem16
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem16(List<string> arrayhex)
        {
            this.number = 16;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/080, Mode-3/A Code Confidence Indicator
    public class DataItem17
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem17(List<string> arrayhex)
        {
            this.number = 17;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/100, Mode-C Code and Code Confidence Indicator
    public class DataItem18
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem18(List<string> arrayhex)
        {
            this.number = 18;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    // Data Item I048/110, Height Measured by a 3D Radar
    public class DataItem19
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public int Height3D;

        public string[] arrayString;
        public DataItem19()
        {
            //data = new List<string> { "3D Height", "N/D" };
            data = new List<string> { "N/D" };
        }
        public DataItem19(List<string> arrayhex)
        {
            this.number = 19;
            this.arrayHex = arrayhex;

            this.arrayString = new string[arrayhex.Count];

            for (int i = 0; i < arrayhex.Count; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
            }

            Height3D = Convert.ToInt32(String.Concat(arrayString[0][2], arrayString[0][3], arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7], arrayString[1]), 2)*25;

            //data = new List<string> { "3D Height", Height3D.ToString() + " ft" };
            data = new List<string> { Height3D.ToString() + " ft" };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/120, Radial Doppler Speed.
    public class DataItem20
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem20(List<string> arrayhex)
        {
            this.number = 20;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/230, Communications/ACAS Capability and Flight Status
    public class DataItem21
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public string COM, STAT, SI, MSSC, ARC, AIC, B1A, B1B;
    
        public DataItem21()
        {
            //data = new List<string> { "COM", "N/D", "STAT", "N/D", "SI", "N/D", "MSSC", "N/D", "ARC", "N/D", "AIC", "N/D", "B1A", "N/D", "B1B", "N/D" };
            data = new List<string> { "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D", "N/D" };
        }
        
        public DataItem21(List<string> arrayhex)
        {
            this.number = 21;
            this.arrayHex = arrayhex;                
            string binaryByte = Convert.ToString(Convert.ToInt32(arrayHex[0], 16), 2).PadLeft(8, '0');
            string comVector = Convert.ToString(binaryByte[0])+ Convert.ToString(binaryByte[1])+ Convert.ToString(binaryByte[2]);
            string statVector = Convert.ToString(binaryByte[3]) + Convert.ToString(binaryByte[4]) + Convert.ToString(binaryByte[5]);
            string si = Convert.ToString(binaryByte[6]);
            string com =Convert.ToString( Convert.ToInt32(comVector,2));
            string stat = Convert.ToString(Convert.ToInt32(statVector, 2));
            
            string binaryByte2 = Convert.ToString(Convert.ToInt32(arrayHex[1], 16), 2).PadLeft(8, '0');
            string mssc = Convert.ToString(binaryByte2[0]);
            string arc = Convert.ToString(binaryByte2[1]);
            string aic = Convert.ToString(binaryByte2[2]);
            string b1a = Convert.ToString(binaryByte2[3]);
            string b1b = Convert.ToString(binaryByte2[4])+ Convert.ToString(binaryByte2[5])+ Convert.ToString(binaryByte2[6])+ Convert.ToString(binaryByte2[7]);
            B1A = b1a;
            B1B = b1b;
            if(Convert.ToInt32(com)==0)
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

            if (Convert.ToInt32(si,2) == 0)
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
            data = new List<string> { COM.ToString(), STAT.ToString(), SI.ToString(), MSSC, ARC.ToString(), AIC.ToString(), B1A.ToString(), B1B.ToString() };
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/260, ACAS Resolution Advisory Report.
    public class DataItem22
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem22(List<string> arrayhex)
        {
            this.number = 22;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    // Data Item I048/055, Mode-1 Code in Octal Representation
    public class DataItem23
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem23(List<string> arrayhex)
        {
            this.number = 23;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/050, Mode-2 Code in Octal Representation
    public class DataItem24
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem24(List<string> arrayhex)
        {
            this.number = 24;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Data Item I048/065, Mode-1 Code Confidence Indicator
    public class DataItem25
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem25(List<string> arrayhex)
        {
            this.number = 25;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    // Data Item I048/060, Mode-2 Code Confidence Indicator
    public class DataItem26
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem26(List<string> arrayhex)
        {
            this.number = 26;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Non-Standard Data Field
    public class DataItem27
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem27(List<string> arrayhex)
        {
            this.number = 27;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }

    //Reserved expansion Field
    public class DataItem28
    {
        public int number;
        public List<string> arrayHex;
        public List<string> data;
        public DataItem28(List<string> arrayhex)
        {
            this.number = 28;
            this.arrayHex = arrayhex;
        }
        public List<string> GetData()
        {
            return this.data;
        }
    }
}
