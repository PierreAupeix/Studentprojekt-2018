using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Importer;
using DatabaseCommunicator;

namespace GUI
{
    public partial class AddWaypointForm : Form
    {
        private Form source;
        private DatabaseCommunicator.DatabaseCommunicator dbCommunicator;

        public Importer.Point returnWaypoint { get; set; }
        private HashSet<string> existingWaypointNames;

        public AddWaypointForm(Form source, DatabaseCommunicator.DatabaseCommunicator dbCommunicator, HashSet<string> existingWaypointNames)
        {
            this.source = source;
            InitializeComponent();
            this.dbCommunicator = dbCommunicator;
            returnWaypoint = null;
            errorLabel.Text = "";
            this.existingWaypointNames = existingWaypointNames;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            source.Show();
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            if (waypointName.Text== "" || airportName.Text == "" || longitude.Text == "" || latitude.Text == "")
            {
                errorLabel.Text = "You must fill in all of the fields.";
            } else
            {
                Boolean added = existingWaypointNames.Contains(waypointName.Text.ToUpper());
                if (!added)
                {
                    existingWaypointNames.Add(waypointName.Text.ToUpper());
                    Importer.Point newPoint = new Importer.Point(waypointName.Text.ToUpper(), airportName.Text.ToUpper(), Double.Parse(latitude.Text), Double.Parse(longitude.Text));
                    dbCommunicator.SavePoint(newPoint);
                    returnWaypoint = newPoint;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else
                {
                    errorLabel.Text = "Waypoint with name " + waypointName.Text.ToUpper() + " already exists!";
                }
            }
        }

        private void waypointName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void longitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void latitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void airportName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
