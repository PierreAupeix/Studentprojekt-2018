using System;
using System.Collections.Generic;
using Importer;
using System.Data.SQLite;
using System.Data;

namespace DatabaseCommunicator
{
    /// <summary>Class <c>SqliteDatabaseCommunicator</c> A class to communicate with an SQLite database</summary>
    public class SqliteDatabaseCommunicator : DatabaseCommunicator
    {
        private SQLiteConnection connection;


        /// <summary>method <c>SqliteDatabaseCommunicator</c> Creates a new SqliteDatabaseCommunicator to communicate with a SQLite database</summary>
        public SqliteDatabaseCommunicator()
        {
            connection = new SQLiteConnection("Data Source="+"../../Database/database.db");
        }

        /// <summary>method <c>DeleteRoute</c> Deletes a given route from the Database</summary>
        /// <param name="routeName">name of the route to delete</param>  
        public override void DeleteRoute(string routeName)
        {
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "DELETE FROM PointProperties WHERE routeName=@RN;" +
                "DELETE FROM Route WHERE name = @RN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@RN", routeName);
            connection.Open();
            comm.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>method <c>GetAirportRoutes</c> Retrieves all the routes connected to a given airports from the database</summary>
        /// <param name="airportName">Name of the airport that the routes are connected to</param>  
        /// <returns>A list of all names for the routes connected to the airports in the database</returns>
        public override List<string> GetAirportRoutes(string airportName)
        {
            List<string> returnList = new List<string>();
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT name from Route WHERE airportName = @AN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@AN",airportName.ToUpper());
            DataTable result = SendQuery(comm);
            foreach (DataRow row in result.Rows)
            {
                returnList.Add((string)row[0]);
            }
            return returnList;
        }

        /// <summary>method <c>GetAirports</c> Retrieves all the airports from the database</summary>
        ///     <returns>A list of all names for the airports in the database</returns>
        public override List<string> GetAirports()
        {
            List<String> resultList = new List<string>();
            SQLiteCommand commm = connection.CreateCommand();
            commm.CommandText="SELECT DISTINCT airportName FROM Route";
            DataTable data = SendQuery(commm);
            foreach (DataRow row in data.Rows)
            {
                resultList.Add((string)row[0]);
            }
            return resultList;
        }

        /// <summary>method <c>GetPoints</c> Gets all the points from the database connected to a given airport</summary>
        ///     <param name="airportName">Name of the airport where the points are located</param>  
        ///     <returns>Returns a lis of all the points connected to the airport</returns>
        public override List<Point> GetPoints(string airportName)
        {
            List<Point> result = new List<Point>();
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "Select * from Point where airportName = @AN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@AN", airportName.ToUpper());
            DataTable data = SendQuery(comm);

            foreach(DataRow row in data.Rows)
            {
                result.Add(new Point((string)row[0], (string)row[1], Decimal.ToDouble((decimal)row[2]), Decimal.ToDouble((decimal)row[3])));
            }

            return result;
        }

        /// <summary>method <c>GetRoute</c> Retrieves a route from the database</summary>
        ///     <param name="routeName">Name of the route to get</param>  
        ///     <returns>A list of points in the route, otherwise an empty list</returns>
        public override List<Point> GetRoute(string routeName)
        {
            List<Point> returnList = new List<Point>();
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT name, airportName, lat, long FROM PointProperties JOIN Point ON Point.name = pointName WHERE routeName = @RN ORDER BY position ASC";
            comm.Prepare();
            comm.Parameters.AddWithValue("@RN", routeName.ToUpper());
            DataTable result = SendQuery(comm);
            foreach (DataRow row in result.Rows)
            {
                returnList.Add(new Point((string)row[0], (string)row[1], Decimal.ToDouble((decimal)row[2]), Decimal.ToDouble((decimal)row[3])));
            }
            return returnList;

        }

        /// <summary>method <c>GetRoutes</c> Retrieves all routes from the database</summary>
        ///     <returns>A list of all names for the routes in the database</returns>
        public override List<string> GetRoutes()
        {
            List<string> returnList = new List<string>();
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT name from Route";
            DataTable result = SendQuery(comm);
            foreach (DataRow row in result.Rows)
            {
                returnList.Add((string)row[0]);
            }
            return returnList;
        }

        /// <summary>method <c>RouteExists</c> Checks whether a given route exists in the database</summary>
        ///     <param name="routeName">Name of the route to check for</param>  
        ///     <returns>True a route with routeName is in the database, else false</returns>
        public override bool RouteExists(string routeName)
        {
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT name FROM Route WHERE name = @RN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@RN", routeName.ToUpper());
            DataTable res = SendQuery(comm);
            if(res.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>method <c>SavePoint</c> Saves a point to the Database</summary>
        /// <param name="p">The point to save in the database</param>  
        /// <example>
        ///     <code>
        ///         Point p = new Point("GG201", "ESGG", 1.5, 3.5643);
        ///         databaseComm.SavePoint(p);
        ///     </code>
        /// </example>
        public override void SavePoint(Point p)
        {
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "Select * from Point where name = @PN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@PN", p.getName());
            DataTable res = SendQuery(comm);
            comm = connection.CreateCommand();
            if (res.Rows.Count!=0)
            {
                comm.CommandText = "UPDATE Point SET airportName = @AN, lat = @LA, long = @LO WHERE name = @NA";
            }
            else
            {
                comm.CommandText = "Insert into Point values(@NA,@AN,@LA,@LO)";
            }
            comm.Prepare();
            comm.Parameters.AddWithValue("@AN", p.getAirportName().ToUpper());
            comm.Parameters.AddWithValue("@NA", p.getName());
            comm.Parameters.AddWithValue("@LA", p.getLat());
            comm.Parameters.AddWithValue("@LO", p.getLon());
            connection.Open();
            comm.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>method <c>SaveRoute</c> Saves a route to the Database</summary>
        ///     <param name="routeName">Name of the route</param>  
        ///     <param name="points">The points in the route, it is a list, so the order can be used to determine the direction of the route</param>  
        ///     <param name="type">Usually STAR or SID, this indicates which kind of route it is, it is a string to allow easy modification</param>  
        ///     <param name="airportName">The Airport that the route is connected to.</param>
        public override void SaveRoute(string routeName, List<Point> points, string type, string airportName)
        {
            //checking and updating route info
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "Select * from Route where name = @RN";
            comm.Prepare();
            comm.Parameters.AddWithValue("@RN", routeName);
            DataTable res = SendQuery(comm);
            if (res.Rows.Count != 0)
            {
                comm.CommandText = "UPDATE Route SET type = @TY, airportName = @AN WHERE name = @NA;";
                SQLiteCommand rem = connection.CreateCommand();
                rem.CommandText = "DELETE FROM PointProperties WHERE routeName = @RN";
                rem.Prepare();
                rem.Parameters.AddWithValue("@RN", routeName);
                connection.Open();
                rem.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                comm.CommandText = "Insert into Route values(@NA,@TY,@AN)";
            }
            comm.Prepare();
            comm.Parameters.AddWithValue("@NA", routeName);
            comm.Parameters.AddWithValue("@TY", type);
            comm.Parameters.AddWithValue("@AN", airportName.ToUpper());
            connection.Open();
            comm.ExecuteNonQuery();
            connection.Close();
            //Adding pointProperties
            int count = 0;
            foreach (Point point in points)
            {
                //Creating new point PointProperties
                comm = connection.CreateCommand();
                comm.CommandText = "Insert into PointProperties values(@PN,@RN,null,null,@PO)";
                comm.Prepare();
                comm.Parameters.AddWithValue("@PN", point.getName());
                comm.Parameters.AddWithValue("@RN", routeName);
                comm.Parameters.AddWithValue("@PO", count);
                connection.Open();
                comm.ExecuteNonQuery();
                connection.Close();
                count++;
            }
        }

        /// <summary>method <c>SendQuery</c> Sends a query to the database</summary>
        ///     <param name="command">Name of the route</param>  
        ///     <returns> A DataTable that corresponds to the table returned from the SQLite database</returns>
        private DataTable SendQuery(SQLiteCommand command)
        {
            SQLiteDataAdapter dataAdapter;
            DataTable result = new DataTable();
            try
            {
                connection.Open();
                dataAdapter = new SQLiteDataAdapter(command);
                dataAdapter.Fill(result);
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }

            connection.Close();
            return result;
        }
    }
}
