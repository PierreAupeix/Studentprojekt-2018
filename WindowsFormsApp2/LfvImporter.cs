using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace Importer
{
    /// <summary>Class <c>LFVImporter</c> A spechialization of the importer for the LFV WFS server</summary>
    class LfvImporter : Importer
    {
        private int radius;
        private List<Point> result;
        private string fixpoints = "";
        private string designated = "";
        private string dme = "";

        /// <summary>method <c>LfvImporter</c> Creates a new LFV importer, this will also buffer data from the server to make searching faster</summary>
        /// <param name="raduis">Since not all points can be retrieved with the airport name, a raduis for a distance around an airport is needed that is used for searching for points</param>  
        public LfvImporter(int radius)
        {
            this.radius = radius;
            var points = new Dictionary<string, Waypoint>();
            result = new List<Point>();
            using (WebClient wc = new WebClient())
            {
                fixpoints = wc.DownloadString("http://daim.lfv.se/geoserver/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais%3AWPT&outputFormat=json&name=test");
                designated = wc.DownloadString("https://daim.lfv.se/geoserver/mais/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais:DNPT&outputFormat=application%2Fjson");
                dme = wc.DownloadString("https://daim.lfv.se/geoserver/mais/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais:DME&outputFormat=application%2Fjson");
            }
        }

        /// <summary>method <c>QueryData</c> Queries data from a remote server</summary>
        /// <param name="query">In this specialization, the query will be an airport code for the ariport that the points should be retrieved from</returns>
        public override List<Point> QueryData(string query)
        {
            if (query.Length < 4)
            {
                throw new Exception("Invalid Airport Code");
            }
            string airportCode = query.Substring(2, 2).ToUpper();
            Decimal[] coordinates = null;
            result = new List<Point>();
            
            var dmeDes = new JavaScriptSerializer().Deserialize<Feature>(dme);
            var fixpointsDes = new JavaScriptSerializer().Deserialize<Feature>(fixpoints);
            var designatedDes = new JavaScriptSerializer().Deserialize<Feature>(designated);

            foreach (Waypoint i in dmeDes.features)
            {
                if (i.properties.POSITIONINDICATOR.Contains(query.ToUpper()))
                {
                    coordinates = i.geometry.coordinates;
                    break;
                }
            }

            if (coordinates == null)
            {
                //QueryData will throw an exception if no airport is found 
                throw new Exception("Airport not found!");
            }

            //we have to put the points within a certain radius into the return list
            foreach (Waypoint j in designatedDes.features)
            {
                Decimal[] jPos = j.geometry.coordinates;
                double distance = GetDistanceFromLatLonInKm(coordinates, j.geometry.coordinates);
                if (distance < radius)
                {
                    result.Add(new Point(j.properties.NAMEOFPOINT, query.ToUpper(), DegToRad(Decimal.ToDouble(j.geometry.coordinates[1])), DegToRad(Decimal.ToDouble(j.geometry.coordinates[0]))));
                }
            }

            foreach (Waypoint w in fixpointsDes.features)
            {
                string pointName = w.properties.NAMEOFPOINT;
                if (pointName.StartsWith(airportCode))
                {
                    result.Add(new Point(w.properties.NAMEOFPOINT, query.ToUpper(), DegToRad(Decimal.ToDouble(w.geometry.coordinates[1])), DegToRad(Decimal.ToDouble(w.geometry.coordinates[0]))));
                }
            }
            return result;
        }

        /// <summary>method <c>GetDistanceFromLatLonInKm</c> gets the distance between two points in KM</summary>
        /// <param name="decPos1">an array with size 2 containing the coordinates in degrees</param>
        /// <param name="decPos2">an array with size 2 containing the coordinates in degrees</param>
        /// <returns>the distance between the points in KM</returns>
        public static double GetDistanceFromLatLonInKm(Decimal[] decPos1, Decimal[] decPos2)
        {
            double lat1 = Decimal.ToDouble(decPos1[0]);
            double lon1 = Decimal.ToDouble(decPos1[1]);
            double lat2 = Decimal.ToDouble(decPos2[0]);
            double lon2 = Decimal.ToDouble(decPos2[1]);

            //Math uses the Haverisne formula
            //https://en.wikipedia.org/wiki/Haversine_formula
            //variable names are explained by 
            //https://upload.wikimedia.org/wikipedia/commons/3/38/Law-of-haversines.svg

            const double R = 6371; // Radius of the earth in km
            var dLat = DegToRad(lat2 - lat1);  // DegToRad below
            var dLon = DegToRad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d;
        }

        /// <summary>method <c>DegToRad</c> Converts degrees to radians</summary>
        /// <param name="dec">The degrees to convert to radians</param>
        /// <returns>The specified degrees in radians</returns>
        private static double DegToRad(double deg)
        {
            return (deg * (Math.PI / 180));
        }

        // Classes that have the same structure as the JSON object to allow deserialisation
        class Feature
        {
            public string type { get; set; }
            public int totalFeatures { get; set; }
            public List<Waypoint> features { get; set; }
        }

        class Waypoint
        {
            public string type { get; set; }
            public string id { get; set; }
            public Geometry geometry { get; set; }
            public Properties properties { get; set; }
        }

        class Geometry
        {
            public string type { get; set; }
            public Decimal[] coordinates { get; set; }
        }

        class Properties
        {
            public string POSITIONINDICATOR { get; set; }
            public string NAMEOFPOINT { get; set; }
            public string QUALITY { get; set; }
            public string MSID { get; set; }
        }
    }
}
