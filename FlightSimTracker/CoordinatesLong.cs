using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * CoordinatesLong is an extension of Coordinates. 
 * It is used to hold coordinates in the longer format than the purely decimal format in the Coordinates class.
 */

namespace FlightSimTracker
{
    public class CoordinatesLong : Coordinates
    {
        private int latDegrees,
            latMinutes,
            latSeconds,
            longDegrees,
            longMinutes,
            longSeconds;
        private char latDirection, longDirection;

        public CoordinatesLong(int latDegrees, int latMinutes, int latSeconds, int longDegrees, int longMinutes, int longSeconds, char latDirection, char longDirection, float latDecimal, float longDecimal) : base (latDecimal, longDecimal)
        {
            this.latDegrees = latDegrees;
            this.latMinutes = latMinutes;
            this.latSeconds = latSeconds;
            this.longDegrees = longDegrees;
            this.longMinutes = longMinutes;
            this.longSeconds = longSeconds;
            this.latDirection = latDirection;
            this.longDirection = longDirection;
        }

        public int GetLatDegrees()
        {
            return latDegrees;
        }

        public void SetLatDegrees(int latDegrees)
        {
            this.latDegrees = latDegrees;
        }

        public int GetLatMinutes()
        {
            return latMinutes;
        }

        public void SetLatMinutes(int latMinutes)
        {
            this.latMinutes = latMinutes;
        }

        public int GetLatSeconds()
        {
            return latSeconds;
        }

        public void SetLatSeconds(int latSeconds)
        {
            this.latSeconds = latSeconds;
        }

        public int GetLongDegrees()
        {
            return longDegrees;
        }

        public void SetLongDegrees(int longDegrees)
        {
            this.longDegrees = longDegrees;
        }

        public int GetLongMinutes()
        {
            return longMinutes;
        }

        public void SetLongMinutes(int longMinutes)
        {
            this.longMinutes = longMinutes;
        }

        public int GetLongSeconds()
        {
            return longSeconds;
        }

        public void SetLongSeconds(int longSeconds)
        {
            this.longSeconds = longSeconds;
        }

        public char GetLatDirection()
        {
            return latDirection;
        }

        public void SetLatDirection(char latDirection)
        {
            this.latDirection = latDirection;
        }

        public char GetLongDirection()
        {
            return longDirection;
        }

        public void SetLongDirection(char longDirection)
        {
            this.longDirection = longDirection;
        }

        public String GetLatitude()
        {
            return latDegrees.ToString() + "° " + latMinutes.ToString() + "' " + latSeconds.ToString() + "\" " + latDirection;
        }

        public String GetLongitude()
        {
            return longDegrees.ToString() + "° " + longMinutes.ToString() + "' " + longSeconds.ToString() + "\" " + longDirection;
        }

        public String[] getCoordinates()
        {
            return new String[]
            {
                GetLatitude(), GetLongitude()
            };
        }
    }
}
