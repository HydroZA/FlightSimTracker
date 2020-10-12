using Newtonsoft.Json;
using System.IO;

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

        /* 
         * We use JSON to communicate with the webserver and to receive data from
         * DCS export.lua
        */

        public AircraftPosition DeserializeJSON(string s)
        {
            return JsonConvert.DeserializeObject<AircraftPosition>(s);
        }

        public void SerializeToJSON(string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer s = new JsonSerializer();
                s.Serialize(file, this);
            }
        }
    }
}
