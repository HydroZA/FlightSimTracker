using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FlightSimTracker
{
    public partial class MainForm : Form
    {
        private bool serverOn;
        private WebServer ws;
        private readonly Graphics webServerCircle;
        private readonly Graphics flightSimCircle;
        private Game g;

        // Sim Connect Vars
        private SimConnect simConnect;
        const int WM_USER_SIMCONNECT = 0x0402;
        private IntPtr handle;
        bool continueTracking = false;

        AircraftPosition aircraftPosition;

        // Thread to poll the position of the aircraft
        Thread trackingThread;

        enum DATA_REQUESTS
        {
            DataRequest,
        }
        enum DEFINITIONS
        {
            DataStructure,
        }

        public MainForm(Game g)
        {
            InitializeComponent();
            aircraftPosition = new AircraftPosition();
            this.g = g;
            Text = "Flight Sim Tracker (" + g.ToString() + ")";
            serverOn = false;
            webServerCircle = onOffPanel.CreateGraphics();
            flightSimCircle = flightSimConnectionCircle.CreateGraphics();
        }

        private void CloseConnection()
        {
            if (simConnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close()
                simConnect.Dispose();
                simConnect = null;
                DrawFlightSimConnectionCircle(Color.Red);
                //displayText("Connection closed");
            }
        }

        private void GetData()
        {
            simConnect.RequestDataOnSimObjectType(DATA_REQUESTS.DataRequest, DEFINITIONS.DataStructure, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        private void Initialise()
        {
            try
            {
                simConnect = new SimConnect("FlightSimTracker", handle, WM_USER_SIMCONNECT, null, 0);
                SetupEvents();
            }
            catch (COMException ex)
            {
                MessageBox.Show("Unable to connect to MSFS");
                Console.WriteLine(ex.Message);
            }
        }

        private void SetupEvents()
        {
            try
            {
                simConnect.OnRecvOpen += simConnect_OnRecvOpen;
                simConnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simConnect_OnRecvQuit);
                simConnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simConnect_OnRecvException);

                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "AIRSPEED TRUE", "knots", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "PLANE ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "GPS POSITION LAT", "degrees latitude", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "GPS POSITION LON", "degrees longitude", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simConnect.AddToDataDefinition(DEFINITIONS.DataStructure, "PLANE HEADING DEGREES MAGNETIC", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                

                // IMPORTANT: register it with the simconnect managed wrapper marshaller
                // if you skip this step, you will only receive a uint in the .dwData field.
                simConnect.RegisterDataDefineStruct<DataStructure>(DEFINITIONS.DataStructure);

                // catch a simobject data request
                simConnect.OnRecvSimobjectDataBytype += simConnect_OnRecvSimobjectDataBytype;
            }
            catch (COMException)
            {
                 Console.WriteLine("Encountered an Exception whilst connecting to sim");
            }
        }

        void simConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            Console.WriteLine("Encountered an Exception whilst connecting to sim");
            DrawFlightSimConnectionCircle(Color.Red);
        }

        void simConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Console.WriteLine("Connected to MSFS");
            DrawFlightSimConnectionCircle(Color.Green);
        }

        // The case where the user closes FSX
        void simConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            CloseConnection();
            Console.WriteLine("Disconnected from MSFS");
            DrawFlightSimConnectionCircle(Color.Red);
        }

        void simConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.DataRequest:
                    DataStructure s1 = (DataStructure)data.dwData[0];

                    aircraftPosition.Altitude = Math.Round(s1.altitude).ToString();
                    aircraftPosition.Heading = Math.Round(s1.heading).ToString();
                    aircraftPosition.AirSpeed = Math.Round(s1.tas).ToString();
                    aircraftPosition.coords.latitude = s1.latitude;
                    aircraftPosition.coords.longitude = s1.longitude;
                    
                    break;

                default:
                    Console.WriteLine("Error receiving data from sim");
                    break;
            }
            UpdateAllLabels();
        }

        // this is how you declare a data structure so that
        // simconnect knows how to fill it/read it.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct DataStructure
        {
            public double tas;
            public double altitude;
            public double latitude;
            public double longitude;
            public double heading;
        }


        private void btnToggleWebServer_Click(object sender, EventArgs e)
        {
            if (serverOn)
            {
                ws.Stop();
                serverOn = false;
            }
            else
            {
                try
                {
                    ws = new WebServer(6969);
                    serverOn = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to start webserver");
                    serverOn = false;
                }
            }
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            if (serverOn)
            {
                btnToggleWebServer.Text = "Stop Web Server";
                DrawWebServerCircle(Color.Green);
            }
            else
            {
                btnToggleWebServer.Text = "Start Web Server";
                DrawWebServerCircle(Color.Red);
            }
        }

        private void onOffPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawWebServerCircle(Color.Red);
        }

        private void flightSimConnectionCircle_Paint(object sender, PaintEventArgs e)
        {
            DrawFlightSimConnectionCircle(Color.Red);
        }

        private void DrawWebServerCircle(Color c)
        {
            SolidBrush sb = new SolidBrush(c);
            webServerCircle.FillEllipse(sb, 0, 0, 20, 20);
        }

        private void DrawFlightSimConnectionCircle(Color c)
        {
            SolidBrush sb = new SolidBrush(c);
            flightSimCircle.FillEllipse(sb, 0, 0, 20, 20);
        }

        /*
         * The following method is responsible for handling incoming messages from the sim. 
         * I don't know how it works or what it does, but without it we can't communicate with Simconnect
         */
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simConnect != null)
                {
                    simConnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void UpdateAllLabels()
        {
            UpdateAltitudeLabelText();
            UpdateAirspeedLabelText();
            UpdateLatitudeLabelText();
            UpdateLongitudeLabelText();
            UpdateHeadingLabelText();
        }

        private void UpdateAltitudeLabelText()
        {
            altitudeLabel.Text = "Altitude: " + aircraftPosition.Altitude + "ft";
        }
        private void UpdateAirspeedLabelText()
        {
            AirSpeedLabel.Text = "Airspeed: " + aircraftPosition.AirSpeed + "knots";
        }
        private void UpdateLatitudeLabelText()
        {
            latitudeLabel.Text = "Latitude: " + aircraftPosition.coords.latitude.ToString();
        }
        private void UpdateLongitudeLabelText()
        {
             longitudeLabel.Text = "Longitude: " + aircraftPosition.coords.longitude.ToString();
        }
        private void UpdateHeadingLabelText()
        {
            headingLabel.Text = "Heading: " + aircraftPosition.Heading + "°";
        }

        private void GetTrackingData()
        {
            while (continueTracking)
            {
                GetData();
                Thread.Sleep(300);
            }
        }


        private void btnStartTracking_Click(object sender, EventArgs e)
        {
            if (trackingThread != null)
            {
                // This will terminate the trackingThread
                continueTracking = false;

                // Block main thread until trackingThread ends
                trackingThread.Join();

                trackingThread = null;
                CloseConnection();
                btnStartTracking.Text = "Start Tracking";
            }
            else
            {
                try
                {
                    this.handle = Handle;
                    Initialise();

                    continueTracking = true;
                    trackingThread = new Thread(new ThreadStart(GetTrackingData));
                    trackingThread.Start();
                    btnStartTracking.Text = "Stop Tracking";
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Connecting to Sim");
                }
            }
        }
    }
}
