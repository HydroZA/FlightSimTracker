using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimTracker
{
    public class Coordinates
    {
        private float latDecimal, longDecimal;

        public Coordinates(float latDecimal, float longDecimal)
        {
            this.latDecimal = latDecimal;
            this.longDecimal = longDecimal;
        }

        public void SetLatDecimal(float latDecimal)
        {
            this.latDecimal = latDecimal;
        }

        public void SetLongDecimal(float longDecimal)
        {
            this.longDecimal = longDecimal;
        }

        public float[] GetDecimalCoordinates()
        {
            return new float[]
            {
            latDecimal, longDecimal
            };
        }
    }
}
