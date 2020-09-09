/*
 * Adapted from https://github.com/Steve887/MotionSimulator
 */


using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimTracker.Tracker
{
    public class MSFSTracker : Tracker
    {
        public SimConnect simConnect;
        const int WM_USER_SIMCONNECT = 0x0402;
        IntPtr handle = new IntPtr(0);

        enum DATA_REQUESTS
        {
            DataRequest,
        }
        enum DEFINITIONS
        {
            DataStructure,
        }

        public MSFSTracker() : base()
        {
        }
        public void SetHandle(IntPtr ip)
        {
            this.handle = ip;
        }
        public  void CloseConnection()
        {
            if (simConnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close()
                simConnect.Dispose();
                simConnect = null;
                //displayText("Connection closed");
            }
        }

        public void GetData()
        {
            
            simConnect.RequestDataOnSimObjectType(DATA_REQUESTS.DataRequest, DEFINITIONS.DataStructure, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        public void Initialise()
        {
            try
            {
                simConnect = new SimConnect("FlightSimTracker", handle, WM_USER_SIMCONNECT, null, 0);
                SetupEvents();
            }
            catch (COMException)
            {
                Console.WriteLine("Error");
               // displayText("Unable to connect to FSX " + ex.Message);
            }
        }

        private void SetupEvents()
        {
            try
            {
                simConnect.OnRecvOpen += simConnect_OnRecvOpen;
                simConnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simConnect_OnRecvQuit);
                simConnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simConnect_OnRecvException);

               // simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "PLANE LONGITUDE", "degrees longitude", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
              //  simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "PLANE LATITUDE", "degrees latitude", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "AIRSPEED TRUE", "knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
           //     simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "Plane Heading Degrees Magnetic", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "PLANE ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                // IMPORTANT: register it with the simconnect managed wrapper marshaller
                // if you skip this step, you will only receive a uint in the .dwData field.
                simConnect.RegisterDataDefineStruct<DataStructure>(DEFINITIONS.DataStructure);

                // catch a simobject data request
                simConnect.OnRecvSimobjectDataBytype += simConnect_OnRecvSimobjectDataBytype;
            }
            catch (COMException)
            {
                Console.WriteLine("Error 2");
            }
        }

        void simConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            Console.WriteLine("Error 3");
        }

        void simConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Console.WriteLine("Connected to MSFS");
        }

        // The case where the user closes FSX
        void simConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            CloseConnection();
            Console.WriteLine("Disconnected from MSFS");
        }


        void simConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            Console.WriteLine("Got Sim Object");
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.DataRequest:
                    DataStructure s1 = (DataStructure)data.dwData[0];

                    Console.WriteLine(s1.altitude.ToString());
                    Altitude = s1.altitude.ToString();
                    AirSpeed = s1.tas.ToString();
                    break;

                default:
                    Console.WriteLine("Error 4");
                    break;
            }
            //return simData;
        }


        // this is how you declare a data structure so that
        // simconnect knows how to fill it/read it.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct DataStructure
        {
            // this is how you declare a fixed size string
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public double tas;
        //    public double heading;
            public double altitude;
        }
    }
}
  