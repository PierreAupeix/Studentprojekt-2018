using System.Collections.Generic;

namespace Importer{
    /// <summary>Class <c>Importer</c> This class dictates how the importer to import from a server should work</summary>
    public abstract class Importer
    {
        /// <summary>method <c>QueryData</c> Queries data from a remote server</summary>
        /// <param name="query">What to query, this is general as different implementations could ask for different identifiers, usually this will be an airport name</param>  
        /// <returns>A list of points queried from the database</returns>
        public abstract List<Point> QueryData(string query);
    }
}
