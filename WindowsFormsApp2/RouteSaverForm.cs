using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GUI
{
    /// <summary>Class <c>RouteSaverForm</c> creates the form that you can
    /// save a route
    /// </summary>
    public partial class RouteSaverForm : Form
    {
        private List<Importer.Point> route;
        private DatabaseCommunicator.DatabaseCommunicator dbCommunicator;
        private Form source;
        private string routeType, airportCode;

        /// <summary> This constructor saves the information it gets
        /// <param name="source"> Used for getting back </param>
        /// <param name="dbCommunicator"> Used to save routes </param>
        /// <param name="newRoute"> Used to create the new route </param>
        /// <param name="airportCode"> Used to know which route is linked to </param>
        /// </summary>
        public RouteSaverForm(Form source, DatabaseCommunicator.DatabaseCommunicator dbCommunicator, List<Importer.Point> newRoute, string airportCode)
        {
            this.source = source;
            InitializeComponent();
            route = newRoute;
            this.airportCode = airportCode;
            this.dbCommunicator = dbCommunicator;
            routeType = "";
            AcceptButton = confirmButton;
        }

        /// <summary> This method saves a route
        /// </summary>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
          DialogResult result = 0;
            if (routeName.Text == "")
            {
                MessageBox.Show("A name for the route is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (routeType == "")
            {
                MessageBox.Show("A radio button must be checked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!dbCommunicator.RouteExists(routeName.Text.ToUpper()))
            {
                result = MessageBox.Show("A route with the name " + routeName.Text.ToUpper() + " already exists. The old route will be overwritten. Do you wish to proceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    dbCommunicator.SaveRoute(routeName.Text.ToUpper(), route, routeType, airportCode);
                    MessageBox.Show("Route created!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    source.Show();
                    this.Close();
                }
            }
            else
            {
                dbCommunicator.SaveRoute(routeName.Text.ToUpper(), route, routeType, airportCode);
                MessageBox.Show("Route created!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                source.Show();
                this.Close();
            }
        }

        /// <summary> This method cancel and close the form
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            source.Show();
        }

        /// <summary> This method change routeType to STAR
        /// </summary>
        private void StarButtonChanged(object sender, EventArgs e)
        {
            routeType = "STAR";
        }

        /// <summary> This method change routeType to SID
        /// </summary>
        private void SidButtonChanged(object sender, EventArgs e)
        {
            routeType = "SID";
        }
    }
}
