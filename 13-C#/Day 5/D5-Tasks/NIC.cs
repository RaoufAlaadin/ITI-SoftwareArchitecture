using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Tasks
{
    class NIC
    {
        
        string manufacture;
        string macAddress;
        NICType nicType;


        public string Manufacture { get { return manufacture; } }
        public string MacAddress { get { return macAddress; } }
        public NICType NicType { get { return nicType; } }

        private NIC( string _manufacture, string _macAddress, NICType _nicType)
        {
            
            manufacture = _manufacture;
            macAddress = _macAddress;
            nicType = _nicType;
          
        }

        //public static NIC SingleTonObj { get; } = new(134679);

        // 1- static variable to remember the value 
        static NIC Obj;

        // 2- static constructor to run only once. 


        // note that ==> both the variable and constructor are private !! 
        static NIC() { Obj = new NIC( "Intel", "00:11:22:33:44:55", NICType.ETHERNET); }

        // 3- static property to get the object
        public static NIC SingleTonObj
        {
            get
            {
                return Obj;
            }
        }

    }


    enum NICType
    {
        ETHERNET,
        tokenRing
    }
}
