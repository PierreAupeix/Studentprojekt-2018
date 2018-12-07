namespace GUI
{
    partial class RouteSaverForm
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
            this.routeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.starButton = new System.Windows.Forms.RadioButton();
            this.sidButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // routeName
            // 
            this.routeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeName.Location = new System.Drawing.Point(65, 72);
            this.routeName.Name = "routeName";
            this.routeName.Size = new System.Drawing.Size(313, 32);
            this.routeName.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 26);
            this.label1.TabIndex = 102;
            this.label1.Text = "Enter a name for the route";
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(65, 166);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(127, 45);
            this.confirmButton.TabIndex = 104;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(251, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 45);
            this.cancelButton.TabIndex = 105;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // starButton
            // 
            this.starButton.AutoSize = true;
            this.starButton.Location = new System.Drawing.Point(66, 124);
            this.starButton.Name = "starButton";
            this.starButton.Size = new System.Drawing.Size(77, 24);
            this.starButton.TabIndex = 107;
            this.starButton.TabStop = true;
            this.starButton.Text = "STAR";
            this.starButton.UseVisualStyleBackColor = true;
            this.starButton.CheckedChanged += new System.EventHandler(this.StarButtonChanged);
            // 
            // sidButton
            // 
            this.sidButton.AutoSize = true;
            this.sidButton.Location = new System.Drawing.Point(251, 124);
            this.sidButton.Name = "sidButton";
            this.sidButton.Size = new System.Drawing.Size(62, 24);
            this.sidButton.TabIndex = 108;
            this.sidButton.TabStop = true;
            this.sidButton.Text = "SID";
            this.sidButton.UseVisualStyleBackColor = true;
            this.sidButton.CheckedChanged += new System.EventHandler(this.SidButtonChanged);
            // 
            // RouteSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 245);
            this.Controls.Add(this.sidButton);
            this.Controls.Add(this.starButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.routeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RouteSaverForm";
            this.Text = "Route Saver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox routeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton starButton;
        private System.Windows.Forms.RadioButton sidButton;
    }
}