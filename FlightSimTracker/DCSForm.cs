using Microsoft.FlightSimulator.SimConnect;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
    public partial class DCSForm : Form
    {
        private WebServer ws;
        private readonly Graphics webServerCircle;
        private readonly Graphics flightSimCircle;
        private Game g;
        private bool continueTracking;

        //DCS Export.lua socket connection
        TcpListener dcsConnection;

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

        public DCSForm(Game g)
        {
            InitializeComponent();
            aircraftPosition = new AircraftPosition();
            this.g = g;
            Text = "Flight Sim Tracker (" + g.ToString() + ")";
            dcsConnection = new TcpListener(IPAddress.Parse("127.0.0.1"), 31950);
            webServerCircle = onOffPanel.CreateGraphics();
            flightSimCircle = flightSimConnectionCircle.CreateGraphics();
        }

        private void btnToggleWebServer_Click(object sender, EventArgs e)
        {
            if (ws != null)
            {
                ws.Stop();
                ws = null;

                btnToggleWebServer.Text = "Start Web Server";
                DrawWebServerCircle(Color.Red);
            }
            else
            {
                try
                {
                    ws = new WebServer(6969);

                    btnToggleWebServer.Text = "Stop Web Server";
                    DrawWebServerCircle(Color.Green);
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to start webserver");
                    ws = null;
                }
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
            Console.WriteLine("Waiting for DCS connection...");
            TcpClient client = dcsConnection.AcceptTcpClient();
            Console.WriteLine("DCS connected :-)");

            StreamReader reader = new StreamReader(client.GetStream());

            while (continueTracking)
            {
                string s = reader.ReadLine();
                Console.WriteLine(s);

                if (s == "exit") break;
                
                aircraftPosition = new AircraftPosition().DeserializeJSON(s);
                aircraftPosition.SerializeToJSON(@"c:\posData.json");

                UpdateAllLabels();
                Thread.Sleep(300);
            }

            reader.Close();
            client.Close();      
        }


        private void btnStartTracking_Click(object sender, EventArgs e)
        {
            if (trackingThread != null)
            {
                continueTracking = true;
                dcsConnection.Start();
                trackingThread = new Thread(new ThreadStart(GetTrackingData));

                btnStartTracking.Text = "Stop Tracking";
            }
            else
            {
                continueTracking = false;
                trackingThread.Join();
                trackingThread = null;
                dcsConnection.Stop();

                btnStartTracking.Text = "Start Tracking";
            }
        }
    }
}