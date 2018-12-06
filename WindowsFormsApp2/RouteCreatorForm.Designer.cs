namespace GUI
{
    partial class RouteCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchField = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.rightArrow = new System.Windows.Forms.Button();
            this.leftArrow = new System.Windows.Forms.Button();
            this.upArrow = new System.Windows.Forms.Button();
            this.downArrow = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.waypointsList = new System.Windows.Forms.ListBox();
            this.routeWaypoints = new System.Windows.Forms.ListBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchField
            // 
            this.searchField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchField.Location = new System.Drawing.Point(50, 51);
            this.searchField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(668, 32);
            this.searchField.TabIndex = 101;
            this.searchField.Enter += new System.EventHandler(this.SearchFieldEnter);
            this.searchField.Leave += new System.EventHandler(this.SearchFieldLeave);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(723, 48);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(115, 46);
            this.searchButton.TabIndex = 102;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // rightArrow
            // 
            this.rightArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightArrow.Location = new System.Drawing.Point(407, 216);
            this.rightArrow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightArrow.Name = "rightArrow";
            this.rightArrow.Size = new System.Drawing.Size(75, 55);
            this.rightArrow.TabIndex = 104;
            this.rightArrow.Text = "→";
            this.rightArrow.UseVisualStyleBackColor = true;
            this.rightArrow.Click += new System.EventHandler(this.RightArrowClick);
            // 
            // leftArrow
            // 
            this.leftArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftArrow.Location = new System.Drawing.Point(407, 142);
            this.leftArrow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftArrow.Name = "leftArrow";
            this.leftArrow.Size = new System.Drawing.Size(75, 55);
            this.leftArrow.TabIndex = 106;
            this.leftArrow.Text = "←";
            this.leftArrow.UseVisualStyleBackColor = true;
            this.leftArrow.Click += new System.EventHandler(this.LeftArrowClick);
            // 
            // upArrow
            // 
            this.upArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upArrow.Location = new System.Drawing.Point(870, 142);
            this.upArrow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upArrow.Name = "upArrow";
            this.upArrow.Size = new System.Drawing.Size(52, 55);
            this.upArrow.TabIndex = 107;
            this.upArrow.Text = "↑";
            this.upArrow.UseVisualStyleBackColor = true;
            this.upArrow.Click += new System.EventHandler(this.UpArrowClick);
            // 
            // downArrow
            // 
            this.downArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downArrow.Location = new System.Drawing.Point(870, 216);
            this.downArrow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downArrow.Name = "downArrow";
            this.downArrow.Size = new System.Drawing.Size(52, 55);
            this.downArrow.TabIndex = 108;
            this.downArrow.Text = "↓";
            this.downArrow.UseVisualStyleBackColor = true;
            this.downArrow.Click += new System.EventHandler(this.DownArrowClick);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(503, 442);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 45);
            this.saveButton.TabIndex = 109;
            this.saveButton.Text = " Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 199;
            this.label1.Text = "Waypoints";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(498, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 200;
            this.label2.Text = "Selected route";
            // 
            // waypointsList
            // 
            this.waypointsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waypointsList.FormattingEnabled = true;
            this.waypointsList.ItemHeight = 26;
            this.waypointsList.Location = new System.Drawing.Point(52, 142);
            this.waypointsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.waypointsList.Name = "waypointsList";
            this.waypointsList.Size = new System.Drawing.Size(335, 238);
            this.waypointsList.TabIndex = 100;
            this.waypointsList.SelectedIndexChanged += new System.EventHandler(this.AbleRightArrow);
            // 
            // routeWaypoints
            // 
            this.routeWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeWaypoints.FormattingEnabled = true;
            this.routeWaypoints.ItemHeight = 26;
            this.routeWaypoints.Location = new System.Drawing.Point(503, 142);
            this.routeWaypoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.routeWaypoints.Name = "routeWaypoints";
            this.routeWaypoints.Size = new System.Drawing.Size(335, 238);
            this.routeWaypoints.TabIndex = 105;
            this.routeWaypoints.SelectedIndexChanged += new System.EventHandler(this.AbleLeftArrow);
            // 
            // viewButton
            // 
            this.viewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewButton.Location = new System.Drawing.Point(620, 442);
            this.viewButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(100, 45);
            this.viewButton.TabIndex = 110;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.ViewButtonClick);
            // 
            // exportButton
            // 
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(738, 442);
            this.exportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 45);
            this.exportButton.TabIndex = 111;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButtonClick);
            // 
            // RouteCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 528);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.routeWaypoints);
            this.Controls.Add(this.waypointsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.downArrow);
            this.Controls.Add(this.upArrow);
            this.Controls.Add(this.leftArrow);
            this.Controls.Add(this.rightArrow);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RouteCreatorForm";
            this.Text = "Route Creator";
            this.Load += new System.EventHandler(this.SetSearchField);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchField;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button rightArrow;
        private System.Windows.Forms.Button leftArrow;
        private System.Windows.Forms.Button upArrow;
        private System.Windows.Forms.Button downArrow;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox waypointsList;
        private System.Windows.Forms.ListBox routeWaypoints;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button exportButton;
    }
}

