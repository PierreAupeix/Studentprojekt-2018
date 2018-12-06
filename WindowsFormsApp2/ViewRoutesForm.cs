using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>Class <c>ViewRoutesForm</c> creates the form that you can
    /// view all routes and deleted the selected one. </summary>
    public partial class ViewRoutesForm : Form
    {
        private DatabaseCommunicator.DatabaseCommunicator dbCommunicator;

        /// <summary> This constructor saves dbCommunicator and list all routes. </summary>
        public ViewRoutesForm(DatabaseCommunicator.DatabaseCommunicator dbCommunicator)
        {
            InitializeComponent();
            this.dbCommunicator = dbCommunicator;
            this.SetUpRoutes();
        }

        /// <summary> This method list all routes </summary>
        private void SetUpRoutes()
        {
            routeList.Items.Clear();
            waypointsList.Items.Clear();
            List<string> routes = dbCommunicator.GetRoutes();

            foreach (string route in routes)
            {
                routeList.Items.Add(route);
            }
        }

        /// <summary> This method update the waypoint's list </summary>
        private void UpdateWaypointsList(object sender, EventArgs e)
        {
            if (routeList.SelectedItem != null)
            {
                waypointsList.Items.Clear();
                List<Importer.Point> waypoints = dbCommunicator.GetRoute(routeList.SelectedItem.ToString());

                foreach (Importer.Point waypoint in waypoints)
                {
                    waypointsList.Items.Add(waypoint.getName());
                }
            }
        }

        /// <summary> This method delete a route </summary>
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (routeList.SelectedItem == null)
            {
                MessageBox.Show("A route must be selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String selectedRoute = routeList.SelectedItem.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete '" + selectedRoute + "'?", "TITEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dbCommunicator.DeleteRoute(selectedRoute);
                    MessageBox.Show("'" + selectedRoute + "' has been successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    routeList.Items.Remove(selectedRoute);
                    waypointsList.Items.Clear();
                }
            }
        }
    }
}
