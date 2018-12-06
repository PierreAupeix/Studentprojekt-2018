using System;

namespace Importer
{
    /// <summary>Class <c>Point</c> A class to represent Waypoints</summary>
    public class Point
    {
        private string name;
        private double lat;
        private double lon;
        private String airportName;

        /// <summary>method <c>Point</c> Creates a new Point object to represent waypoints</summary>
        /// <param name="name">The name of the point</param>
        /// <param name="airportName">The name of the airport that the point is connected to</param>
        /// <param name="lat">The Latitude coordinade of the point of the point</param>
        /// <param name="lon">The Longitude coordinade of the point of the point</param>

        public Point(String name,String airportName, double lat, double lon)
        {
            this.name = name;
            this.lat = lat;
            this.lon = lon;
            this.airportName = airportName;
        }

        /// <summary>method <c>getName</c>Gets the name of the point</summary>
        public String getName()
        {
            return name;
        }

        /// <summary>method <c>getairportName</c> Gets the name of the airport that the point is connected to</summary>
        public String getAirportName()
        {
            return this.airportName;
        }

        /// <summary>method <c>getLat</c> Gets the Latitude coordinate of the point</summary>
        public double getLat()
        {
            return lat;
        }
        /// <summary>method <c>getName</c> Gets the Longitude coordinate of the point</summary>
        public double getLon()
        {
            return lon;
        }

    }
}
