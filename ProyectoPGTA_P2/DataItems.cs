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
        public DataItem1(string[] arrayhex)
        {
            this.number = 1;
            this.arrayHex = arrayhex;
        }
    }

    //Data Item 2: Data Item I048/140, Time of Day
    public class DataItem2
    {
        public int number;
        public string[] arrayHex;
        public DataItem2(string[] arrayhex)
        {
            this.number = 2;
            this.arrayHex = arrayhex;
        }
    }

    //Data Item I048/020, Target Report Descriptor
    public class DataItem3
    {
        public int number;
        public string[] arrayHex;
        public DataItem3(string[] arrayhex)
        {
            this.number = 3;
            this.arrayHex = arrayhex;
        }
    }

    //Measured position of an aircraft in local polar co-ordinates
    public class DataItem4
    {
        public int number;
        public string[] arrayHex;
        public DataItem4(string[] arrayhex)
        {
            this.number = 4;
            this.arrayHex = arrayhex;
        }
    }

    // Data Item I048/070, Mode-3/A Code in Octal Representation
    public class DataItem5
    {
        public int number;
        public string[] arrayHex;
        public DataItem5(string[] arrayhex)
        {
            this.number = 5;
            this.arrayHex = arrayhex;
        }
    }

    //Flight Level converted into binary representation
    public class DataItem6
    {
        public int number;
        public string[] arrayHex;
        public DataItem6(string[] arrayhex)
        {
            this.number = 6;
            this.arrayHex = arrayhex;
        }
    }

    //Radar plot characteristics
    public class DataItem7
    {
        public int number;
        public string[] arrayHex;
        public DataItem7(string[] arrayhex)
        {
            this.number = 7;
            this.arrayHex = arrayhex;
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
