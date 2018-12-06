using System;
using System.Collections.Generic;
using Importer;
using GUI;

namespace GUICommunicator
{
    class Communicator
    {
        private static readonly int radius = 80;
        private LfvImporter importer;
        private RouteCreatorForm gui;
        public Communicator()
        {
            importer = new LfvImporter(radius);
            gui = new RouteCreatorForm();
        }

        public List<Point> SearchForWaypoints(string airportCode)
        {
            return importer.QueryData(airportCode);
        }

    }
}
