using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Importer;
using DatabaseCommunicator;
using Exporter;

namespace GUI
{
    /// <summary>Class <c>RouteCreatorForm</c> creates the form that you can search
    ///  after airports and create and delete routes. </summary>
    public partial class RouteCreatorForm : Form
    {
        private Importer.LfvImporter importer;
        private DatabaseCommunicator.DatabaseCommunicator dbCommunicator;
        private Exporter.XmlExporter xmlExporter;
        private static readonly int RADIUS = 80;
        private HashSet<Importer.Point> waypointSet;
        private HashSet<string> existingWaypointNames;
        private string airportCode;

        /// <summary> This constructor create new XmlExporter, SqliteDatabaseCommunicator,
        /// HashSet of Importer points and HashSet for waypoints. </summary>
        public RouteCreatorForm()
        {
            InitializeComponent();
            importer = new LfvImporter(RADIUS);
            dbCommunicator = new SqliteDatabaseCommunicator();
            xmlExporter = new XmlExporter();
            waypointSet = new HashSet<Importer.Point>();
            existingWaypointNames = new HashSet<string>();
            airportCode = "";
        }

        /// <summary> Sets searchField's text and fore color </summary>
        private void SetSearchField(object sender, EventArgs e)
        {
            searchField.Text = "Enter an airport code";
            searchField.ForeColor = Color.SlateGray;
        }

        /// <summary> This method gets waypoints from Importer and put them a list in RouteCreatorForm </summary>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            waypointsList.Items.Clear();
            routeWaypoints.Items.Clear();
            waypointSet.Clear();

            if (searchField.Text.Length == 0)
            {
                MessageBox.Show("A valid airport code is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    airportCode = searchField.Text;
                    List<Importer.Point> importerPoints = importer.QueryData(searchField.Text.ToUpper());

                    foreach (Importer.Point p in importerPoints)
                    {
                        waypointSet.Add(p);
                        dbCommunicator.SavePoint(p);
                        existingWaypointNames.Add(p.getName().ToUpper());
                    }

                    List<Importer.Point> orderedList = waypointSet.ToList<Importer.Point>();
                    orderedList.Sort((p1, p2) => p1.getName().CompareTo(p2.getName()));

                    foreach (Importer.Point p in orderedList)
                    {
                        waypointsList.Items.Add(p.getName());
                    }

                    waypointsList.SelectionMode = SelectionMode.MultiExtended;
                    routeWaypoints.SelectionMode = SelectionMode.MultiExtended;
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary> This method moves the selected waypoint from the list Waypoints to the list Selected route </summary>
        private void RightArrowClick(object sender, EventArgs e)
        {
            if (waypointsList.Items.Count != 0 && waypointsList.SelectedItems != null)
            {
                HashSet<string> selectedPoints = new HashSet<string>();
                foreach (string point in waypointsList.SelectedItems)
                {
                    selectedPoints.Add(point);
                }
                foreach (string point in selectedPoints)
                {
                    routeWaypoints.Items.Add(point);
                    waypointsList.Items.Remove(point);
                }
                if (waypointsList.Items.Count != 0)
                {
                    waypointsList.SetSelected(0, true);
                }
            }
        }

        /// <summary> This method moves down the selected waypoint in the list Selected route
        /// in order to change the route's order. </summary>
        private void DownArrowClick(object sender, EventArgs e)
        {
            if (routeWaypoints.SelectedIndex != routeWaypoints.Items.Count-1 && routeWaypoints.Items.Count != 0 && routeWaypoints.SelectedItem != null && routeWaypoints.Items.Count != 1)
            {
                string saveItem = routeWaypoints.SelectedItem.ToString();
                int saveIndex = routeWaypoints.SelectedIndex;
                routeWaypoints.Items.Remove(routeWaypoints.SelectedItem);
                routeWaypoints.Items.Insert(saveIndex + 1, saveItem);
                routeWaypoints.SetSelected(saveIndex + 1, true);
            }
        }

        /// <summary> This method change fore color on the search field when user enters </summary>
        private void SearchFieldEnter(object sender, EventArgs e)
        {
            AcceptButton = searchButton;
            if (searchField.Text == "Enter an airport code")
             {
                TextBox box = sender as TextBox;
                box.ForeColor = Color.Black;
                box.Clear();
             }
        }

        /// <summary> This method change fore color on the search field when user leaves </summary>
        private void SearchFieldLeave(object sender, EventArgs e)
        {
            AcceptButton = null;
            if (searchField.Text == "")
            {
                searchField.ForeColor = Color.SlateGray;
                searchField.Text = "Enter an airport code";
            }
        }

        /// <summary> This method moves back the selected waypoint from the list Selected
        /// route to the list Waypoints. </summary>
        private void LeftArrowClick(object sender, EventArgs e)
        {
            if (routeWaypoints.Items.Count != 0 && routeWaypoints.SelectedItem != null)
            {
                HashSet<string> selectedPoints = new HashSet<string>();
                int saveIndex = 0;
                foreach (string point in routeWaypoints.SelectedItems)
                {
                    selectedPoints.Add(point);
                    saveIndex = routeWaypoints.SelectedIndex;
                }
                foreach (string point in selectedPoints)
                {
                    waypointsList.Items.Add(point);
                    routeWaypoints.Items.Remove(point);
                }

                if (saveIndex > 0 && this.routeWaypoints.Items.Count != 0)
                {
                    routeWaypoints.SetSelected(saveIndex - 1, true);
                }
                else if (saveIndex == 0 && this.routeWaypoints.Items.Count != 0)
                {
                    routeWaypoints.SetSelected(saveIndex, true);
                }
            }
        }

        /// <summary> This method moves up the selected waypoint in the list Selected route
        /// in order to change the route's order. </summary>
        private void UpArrowClick(object sender, EventArgs e)
        {
            if (routeWaypoints.SelectedIndex != routeWaypoints.TopIndex && routeWaypoints.Items.Count != 0 && routeWaypoints.SelectedItem != null && routeWaypoints.Items.Count != 1)
            {
                string saveItem = routeWaypoints.SelectedItem.ToString();
                int saveIndex = routeWaypoints.SelectedIndex;
                routeWaypoints.Items.Remove(routeWaypoints.SelectedItem);
                routeWaypoints.Items.Insert(saveIndex - 1, saveItem);
                routeWaypoints.SetSelected(saveIndex - 1, true);
            }
        }

        /// <summary> This method creates a route and save it in the database. </summary>
        private void SaveButtonClick(object sender, EventArgs e)
        {
            List<Importer.Point> route = new List<Importer.Point>();

            if (waypointSet != null)
            {
                for (int i = 0; i < routeWaypoints.Items.Count; i++)
                {
                    foreach (Importer.Point p in waypointSet)
                    {
                        if (p.getName().Equals(routeWaypoints.Items[i].ToString()))
                        {
                            route.Add(p);
                        }
                    }
                }
            }

            if (route.Count() == 0)
            {
                MessageBox.Show("Cannot save a route with no waypoints.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var routeSaverForm = new RouteSaverForm(this, dbCommunicator, route, airportCode);
                routeSaverForm.Show();
            }
        }

        /// <summary> This method creates and show the view form </summary>
        private void ViewButtonClick(object sender, EventArgs e)
        {
            var viewRoutesForm = new ViewRoutesForm(dbCommunicator);
            viewRoutesForm.Show();
        }

        /// <summary> This method exports files with help of XmlExporter </summary>
        private void ExportButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (xmlExporter.ExportFiles(dbCommunicator))
                {
                    MessageBox.Show("Routes have been exported!", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Routes could not be exported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary> This method change AcceptButton to right arrow </summary>
        private void AbleRightArrow(object sender, EventArgs e)
        {
            AcceptButton = rightArrow;
        }

        /// <summary> This method change AcceptButton to left arrow </summary>
        private void AbleLeftArrow(object sender, EventArgs e)
        {
            AcceptButton = leftArrow;
        }
    }
}
