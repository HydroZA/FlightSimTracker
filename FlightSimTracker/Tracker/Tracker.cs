using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimTracker.Tracker
{
    public class Tracker
    {
        public Tracker()
        {}

        public Coordinates Coords { get; set; }

        public string Altitude { get; set; }

        public string AirSpeed { get; set; }
    }
}
