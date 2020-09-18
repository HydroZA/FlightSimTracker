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
