using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPGTA_P2
{

    //Data Item I048/010, Data Source Identifier
    public class DataItem1
    {
        public int number;
        public string[] arrayHex;

        //DATA ITEM 1
        public string SAC, SIC;

        public DataItem1(string[] arrayhex)
        {
            this.number = 1;
            this.arrayHex = arrayhex;

            SAC = arrayhex[0];
            SIC = arrayhex[1];

            Console.WriteLine("SAC: " + SAC);
            Console.WriteLine("SIC: " + SIC);

        }
    }

    //Data Item 2: Data Item I048/140, Time of Day
    public class DataItem2
    {
        public int number;
        public string[] arrayHex;
        //public string[] arrayString;

        //DATA ITEM 2
        public string timestr = "";
        public int time;

        public DataItem2(string[] arrayhex)
        {
            this.number = 2;
            this.arrayHex = arrayhex;

            //this.arrayString = new string[arrayhex.Length];

            for (int i = 0; i < arrayhex.Length; i++)
            {
                //arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
                this.timestr += arrayhex[i];
            }

            this.time = Convert.ToInt32(timestr) / 128; //hora actual en segundos

            float hours = time / 3600;
            float minutes = time % 3600 / 60;
            float seconds = time - hours * 3600 - minutes * 60;
            Console.WriteLine("Horas: " + hours);
            Console.WriteLine("Minutos: " + minutes);
            Console.WriteLine("Segundos: " + seconds);
        }
    }

    //Data Item I048/020, Target Report Descriptor
    public class DataItem3
    {
        public int number;
        public string[] arrayHex;

        public string[] arrayString;
        public string TYP, SIM, RPD, SPI, RAB;
        public string FX1;
        public string TST, ERR, XPP, ME, MI, FOE_FRI;
        public string FX2;
        public string ADSB_EP, ADSB_VAL, SCN_EP, SCN_VAL, PAI_EP, PAI_VAL;

        public DataItem3(string[] arrayhex)
        {
            this.number = 3;
            this.arrayHex = arrayhex;
            this.arrayString = new string[arrayhex.Length];

            for (int i = 0; i < arrayhex.Length; i++)
            {
                arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
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

            RPD = a[4].ToString();
            switch (RPD)
            {
                case "0":
                    RPD = "Report from RDP Chain 1";
                    break;
                case "1":
                    RPD = "Report from RDP Chain 2";
                    break;
                default:
                    RPD = "N/A";
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
                if (FX1 == "1")
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
        }

        //Measured position of an aircraft in local polar co-ordinates
        public class DataItem4
        {
            public int number;
            public string[] arrayHex;

            public float RHD, THETA;

            public DataItem4(string[] arrayhex)
            {
                this.number = 4;
                this.arrayHex = arrayhex;

                string RHD_16 = String.Concat(arrayhex[0], arrayhex[1]);
                string THETA_16 = String.Concat(arrayhex[2], arrayhex[3]);

                RHD = Convert.ToInt32(RHD_16, 16) / 256;
                THETA = Convert.ToInt32(THETA_16, 16) * 45 / 8192;

            }
        }

        // Data Item I048/070, Mode-3/A Code in Octal Representation
        public class DataItem5
        {
            public int number;
            public string[] arrayHex;
            public string[] arrayString;

            public string V, G, L, Mode3;

            public DataItem5(string[] arrayhex)
            {
                this.number = 5;
                this.arrayHex = arrayhex;

                this.arrayString = new string[arrayhex.Length];

                for (int i = 0; i < arrayhex.Length; i++)
                {
                    arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
                }

                V = arrayString[0][0].ToString();
                switch (V)
                {
                    case "0":
                        V = "Código validado";
                        break;
                    case "1":
                        V = "Código no validado";
                        break;
                    default:
                        V = "N/A";
                        break;

                }

                G = arrayString[0][1].ToString();
                switch (G)
                {
                    case "0":
                        G = "Código default";
                        break;
                    case "1":
                        G = "Código distorsionado";
                        break;
                    default:
                        G = "N/A";
                        break;

                }

                L = arrayString[0][2].ToString();
                switch (L)
                {
                    case "0":
                        L = "Código Mode-3/A derivado de la respuesta XPDR";
                        break;
                    case "1":
                        L = "Código Mode-3/A no se ha extraído en el último escaneo";
                        break;
                    default:
                        L = "N/A";
                        break;

                }

                Mode3 = String.Concat(arrayhex[0][4], arrayhex[0][5], arrayhex[0][6], arrayhex[0][7], arrayhex[1]);
                if (L == "Código Mode-3/A no se ha extraído en el último escaneo")
                {
                    Mode3 = "N/A";
                }
                else
                {
                    Mode3 = Convert.ToString(Convert.ToInt32(Mode3, 2), 8);
                }

            }
        }

        //Flight Level converted into binary representation
        public class DataItem6
        {
            public int number;
            public string[] arrayHex;
            public string[] arrayString;

            public string V, G;
            public int FL;

            public DataItem6(string[] arrayhex)
            {
                this.number = 6;
                this.arrayHex = arrayhex;

                this.arrayString = new string[arrayhex.Length];

                for (int i = 0; i < arrayhex.Length; i++)
                {
                    arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
                }

                V = arrayString[0][0].ToString();
                switch (V)
                {
                    case "0":
                        V = "Código validado";
                        break;
                    case "1":
                        V = "Código no validado";
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
                        G = "Código distorsionado";
                        break;
                    default:
                        G = "N/A";
                        break;

                }

                string FL_BIN = String.Concat(arrayString[0][2], arrayString[0][3], arrayString[0][4], arrayString[0][5], arrayString[0][6], arrayString[0][7], arrayString[1]);
                FL = Convert.ToInt32(FL_BIN, 2) / 4;
            }
        }

        //Radar plot characteristics
        public class DataItem7
        {
            public int number;
            public string[] arrayHex;
            public string[] arrayString;

            public float SRL, SRR, SAM, PRL, PAM, RPD, APD;
            public string FX1;


            public DataItem7(string[] arrayhex)
            {
                this.number = 7;
                this.arrayHex = arrayhex;

                for (int i = 0; i < arrayhex.Length; i++)
                {
                    arrayString[i] = Convert.ToString(Convert.ToInt32(arrayhex[i], 16), 2).PadLeft(8, '0');
                }
                int index = 1;

                string SRL_str = arrayString[0][0].ToString();
                if (SRL_str == "1")
                {
                    SRL_str = arrayString[index];
                    SRL = Convert.ToInt32(SRL_str, 2) * 45 / 1024;

                    index++;

                }
                else
                {
                    SRL_str = "N/A";
                    SRL = -1;
                }

                string SRR_str = arrayString[0][1].ToString();
                if (SRR_str == "1")
                {
                    SRR_str = arrayString[index];
                    SRR = Convert.ToInt32(SRR_str, 2);

                    index++;

                }
                else
                {
                    SRR_str = "N/A";
                    SRR = -1;
                }

                string SAM_str = arrayString[0][2].ToString();
                if (SAM_str == "1")
                {
                    SAM_str = arrayString[index];
                    SAM = Convert.ToInt32(SAM_str, 2);

                    index++;

                }
                else
                {
                    SAM_str = "N/A";
                    SAM = -1;
                }

                string PRL_str = arrayString[0][3].ToString();
                if (PRL_str == "1")
                {
                    PRL_str = arrayString[index];
                    PRL = Convert.ToInt32(PRL_str, 2)*45/1024;

                    index++;

                }
                else
                {
                    PRL_str = "N/A";
                    PRL = -1;
                }

                string PAM_str = arrayString[0][4].ToString();
                if (PAM_str == "1")
                {
                    PAM_str = arrayString[index];
                    PAM = Convert.ToInt32(PAM_str, 2);

                    index++;

                }
                else
                {
                    PAM_str = "N/A";
                    PAM = -1;
                }

                string RPD_str = arrayString[0][5].ToString();
                if (RPD_str == "1")
                {
                    RPD_str = arrayString[index];
                    RPD = Convert.ToInt32(RPD_str, 2)/256;

                    index++;

                }
                else
                {
                    RPD_str = "N/A";
                    RPD = -1;
                }

                string APD_str = arrayString[0][6].ToString();
                if (APD_str == "1")
                {
                    APD_str = arrayString[index];
                    APD = Convert.ToInt32(APD_str, 2) *45/2048;

                    index++;

                }
                else
                {
                    APD_str = "N/A";
                    APD = -1;
                }
            }
        }

        //Data Item I048/220, Aircraft Address
        public class DataItem8
        {
            public int number;
            public string[] arrayHex;
            public DataItem8(string[] arrayhex)
            {
                this.number = 8;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/240, Aircraft Identification
        public class DataItem9
        {
            public int number;
            public string[] arrayHex;
            public DataItem9(string[] arrayhex)
            {
                this.number = 9;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I0458/250, BDS Register Data
        public class DataItem10
        {
            public int number;
            public string[] arrayHex;
            public DataItem10(string[] arrayhex)
            {
                this.number = 10;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item 11: Data Item I048/161, Track Number
        public class DataItem11
        {
            public int number;
            public string[] arrayHex;
            public DataItem11(string[] arrayhex)
            {
                this.number = 11;
                this.arrayHex = arrayhex;
            }
        }

        //Calculated position in cartesian coordinates
        public class DataItem12
        {
            public int number;
            public string[] arrayHex;
            public DataItem12(string[] arrayhex)
            {
                this.number = 12;
                this.arrayHex = arrayhex;
            }
        }

        //Velocity calculated and expressed on polar coordinates
        public class DataItem13
        {
            public int number;
            public string[] arrayHex;
            public DataItem13(string[] arrayhex)
            {
                this.number = 13;
                this.arrayHex = arrayhex;
            }
        }

        //Track status
        public class DataItem14
        {
            public int number;
            public string[] arrayHex;
            public DataItem14(string[] arrayhex)
            {
                this.number = 14;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/210, Track Quality 
        public class DataItem15
        {
            public int number;
            public string[] arrayHex;
            public DataItem15(string[] arrayhex)
            {
                this.number = 15;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item 16: Data Item I048/030, Warning/Error Conditions and Target Classification
        public class DataItem16
        {
            public int number;
            public string[] arrayHex;
            public DataItem16(string[] arrayhex)
            {
                this.number = 16;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/080, Mode-3/A Code Confidence Indicator
        public class DataItem17
        {
            public int number;
            public string[] arrayHex;
            public DataItem17(string[] arrayhex)
            {
                this.number = 17;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/100, Mode-C Code and Code Confidence Indicator
        public class DataItem18
        {
            public int number;
            public string[] arrayHex;
            public DataItem18(string[] arrayhex)
            {
                this.number = 18;
                this.arrayHex = arrayhex;
            }
        }

        // Data Item I048/110, Height Measured by a 3D Radar
        public class DataItem19
        {
            public int number;
            public string[] arrayHex;
            public DataItem19(string[] arrayhex)
            {
                this.number = 19;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/120, Radial Doppler Speed.
        public class DataItem20
        {
            public int number;
            public string[] arrayHex;
            public DataItem20(string[] arrayhex)
            {
                this.number = 20;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/230, Communications/ACAS Capability and Flight Status
        public class DataItem21
        {
            public int number;
            public string[] arrayHex;
            public DataItem21(string[] arrayhex)
            {
                this.number = 21;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/260, ACAS Resolution Advisory Report.
        public class DataItem22
        {
            public int number;
            public string[] arrayHex;
            public DataItem22(string[] arrayhex)
            {
                this.number = 22;
                this.arrayHex = arrayhex;
            }
        }

        // Data Item I048/055, Mode-1 Code in Octal Representation
        public class DataItem23
        {
            public int number;
            public string[] arrayHex;
            public DataItem23(string[] arrayhex)
            {
                this.number = 23;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/050, Mode-2 Code in Octal Representation
        public class DataItem24
        {
            public int number;
            public string[] arrayHex;
            public DataItem24(string[] arrayhex)
            {
                this.number = 24;
                this.arrayHex = arrayhex;
            }
        }

        //Data Item I048/065, Mode-1 Code Confidence Indicator
        public class DataItem25
        {
            public int number;
            public string[] arrayHex;
            public DataItem25(string[] arrayhex)
            {
                this.number = 25;
                this.arrayHex = arrayhex;
            }
        }

        // Data Item I048/060, Mode-2 Code Confidence Indicator
        public class DataItem26
        {
            public int number;
            public string[] arrayHex;
            public DataItem26(string[] arrayhex)
            {
                this.number = 26;
                this.arrayHex = arrayhex;
            }
        }

        //Non-Standard Data Field
        public class DataItem27
        {
            public int number;
            public string[] arrayHex;
            public DataItem27(string[] arrayhex)
            {
                this.number = 27;
                this.arrayHex = arrayhex;
            }
        }

        //Reserved expansion Field
        public class DataItem28
        {
            public int number;
            public string[] arrayHex;
            public DataItem28(string[] arrayhex)
            {
                this.number = 28;
                this.arrayHex = arrayhex;
            }
        }
    }
}
