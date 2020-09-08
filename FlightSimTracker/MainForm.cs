using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainForm(Game g)
        {
            InitializeComponent();
            this.g = g;
            serverOn = false;
            webServerCircle = onOffPanel.CreateGraphics();
            flightSimCircle = flightSimConnectionCircle.CreateGraphics();

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
    }
}
