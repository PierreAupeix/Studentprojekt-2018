using System;
using System.Collections.Generic;
using Importer;

namespace DatabaseCommunicator
{
    /// <summary>Abstract Class <c>DatabaseCommunicator</c> Specifies the methods which
    /// a communication class to a database should have.</summary>
    public abstract class DatabaseCommunicator
    {
        /// <summary>method <c>SavePoint</c> Saves a point to the Database</summary>
        /// <param name="p">The point to save in the database</param>  
        /// <example>
        ///     <code>
        ///         Point p = new Point("GG201", "ESGG", 1.5, 3.5643);
        ///         databseComm.SavePoint(p);
        ///     </code>
        /// </example>
        public abstract void SavePoint(Point p);

        /// <summary>method <c>SaveRoute</c> Saves a route to the Database</summary>
        ///     <param name="routeName">name of the route</param>  
        ///     <param name="points">The points in the route, it is a list, so the order can be used to determine the direction of the route</param>  
        ///     <param name="type">Usually STAR or SID, this indicates which kind of route it is, it is a string to allow easy modification</param>  
        ///     <param name="airportName">The Airport that the route is connected to.</param>
        public abstract void SaveRoute(string routeName, List<Point> points, string type, string airportName);

        /// <summary>method <c>GetPoints</c> Gets all the points from the database connected to a given airport</summary>
        ///     <param name="airportName">name of the airport where the points are located</param>  
        ///     <returns>Returns a list of all the points connected to the airport</returns>
        public abstract List<Point> GetPoints(string airportName);

        /// <summary>method <c>RouteExists</c> Checks whether a given route exists in the database</summary>
        ///     <param name="routeName">name of the route to check for</param>  
        ///     <returns>true a route with routeName is in the database, else false</returns>
        public abstract Boolean RouteExists(string routeName);

        /// <summary>method <c>GetRoute</c> Retrieves a route from the database</summary>
        ///     <param name="routeName">name of the route to get</param>  
        ///     <returns>A list of points in the route, otherwise an empty list</returns>
        public abstract List<Point> GetRoute(string routeName);

        /// <summary>method <c>GetRoutes</c> Retrieves all routes from the database</summary>
        ///     <returns>A list of all names for the routes in the database</returns>
        public abstract List<string> GetRoutes();

        /// <summary>method <c>GetAirports</c> Retrieves all the airports from the database</summary>
        ///     <returns>A list of all names for the airports in the database</returns>
        public abstract List<string> GetAirports();

        /// <summary>method <c>GetAirportRoutes</c> Retrieves all the routes connected to a given airports from the database</summary>
        /// <param name="airportName">name of the airport that the routes are connected to</param>  
        /// <returns>A list of all names for the routes connected to the airports in the database</returns>
        public abstract List<string> GetAirportRoutes(string airportName);

        /// <summary>method <c>DeleteRoute</c> Deletes a given route from the Database</summary>
        /// <param name="routeName">name of the route to delete</param>  
        public abstract void DeleteRoute(string routeName);
    }
}
