using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimTracker
{
    class AircraftPosition
    {
        public AircraftPosition() 
        {
        }
        
        public struct Coordinates
        {
            public double latitude;
            public double longitude;
        }

        public Coordinates coords;

        public string Altitude
        {
            get;
            set;
        }
        public string AirSpeed
        {
            get;
            set;
        }
        public string Heading
        {
            get;
            set;
        }
    }
}
