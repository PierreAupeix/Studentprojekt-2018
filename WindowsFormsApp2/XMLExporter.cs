using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Importer;

namespace Exporter
{
    /// <summary>Class <c>Exporter</c> export XML files.
    /// </summary>
    class XmlExporter : Exporter
    {
        /// <summary> This method create XML files from database and export to a folder.
        /// <param name="db"> The database db contains informations which the created files need to have. </param>
        /// <returns> Returns true if the new files are created. </returns>
        /// </summary>
        public override bool ExportFiles(DatabaseCommunicator.DatabaseCommunicator db)
        {
            string folderName = @"ExportFolder";

            // Delete the folder if exist
            if (System.IO.Directory.Exists(folderName))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(folderName);
                foreach(FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }
                foreach(DirectoryInfo dir in di.EnumerateDirectories())
                {
                    dir.Delete(true);
                }
            }
            
            List<string> allAirports = db.GetAirports();
            foreach(string airport in allAirports)
            {
                List<string> routes = db.GetAirportRoutes(airport);

                try
                {
                    // Create a folder for an airport
                    string pathString = System.IO.Path.Combine(folderName, airport);
                    System.IO.Directory.CreateDirectory(pathString);

                    for (int i = 0; i < routes.Count; i++)
                    {
                        string route = routes[i];
                        List<Point> points = db.GetRoute(route);

                        // Create XML-file for a route
                        string routeXML = @"" + folderName + "/" + airport + "/" + route + ".xml";
                        CreateXMLFile(routeXML, points);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("The Export Failed!");
                } 
            }
            return true;
        }

        private static void CreateXMLFile(string filename, List<Point> points)
        {
            XmlSerializer serialer = new XmlSerializer(typeof(routeData));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlTextWriter writer = new XmlTextWriter(filename, null);
            routeData routeData = new routeData();
            breakpoint[] bp = new breakpoint[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                breakpoint breakpoint = new breakpoint();
                breakpoint.lat = p.getLat().ToString().Replace(',', '.') ;
                breakpoint.lon = p.getLon().ToString().Replace(',', '.');
                breakpoint.section = i.ToString();
                bp[i] = breakpoint;
            }

            routeData.startEvents = "";
            routeData.breakpoints = bp;

            serialer.Serialize(writer, routeData, ns);
            writer.Close();
        }
    }

    /// <summary>Class <c>routeData</c> have attributs startEvents and breakpoints.
    /// </summary>
    [XmlRootAttribute("routeData")]
    public class routeData
    {
        public string startEvents;
        public breakpoint[] breakpoints;
    }

    /// <summary>Class <c>breakpoint</c> have attributs type, section, angle, distance, 
    /// lon, lat, fix and events
    /// </summary>
    public class breakpoint
    {
        [XmlAttribute]
        public string type = "0", section, angle = "0", distance = "0", lon, lat, fix = "";
        public string events = "";
    }
}
