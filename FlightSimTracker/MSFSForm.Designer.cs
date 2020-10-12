namespace FlightSimTracker
{
    partial class MSFSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSFSForm));
            this.btnToggleWebServer = new System.Windows.Forms.Button();
            this.onOffPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labl2 = new System.Windows.Forms.Label();
            this.flightSimConnectionCircle = new System.Windows.Forms.Panel();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.AirSpeedLabel = new System.Windows.Forms.Label();
            this.btnStartTracking = new System.Windows.Forms.Button();
            this.headingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnToggleWebServer
            // 
            this.btnToggleWebServer.Location = new System.Drawing.Point(12, 12);
            this.btnToggleWebServer.Name = "btnToggleWebServer";
            this.btnToggleWebServer.Size = new System.Drawing.Size(122, 50);
            this.btnToggleWebServer.TabIndex = 0;
            this.btnToggleWebServer.Text = "Start Web Server";
            this.btnToggleWebServer.UseVisualStyleBackColor = true;
            this.btnToggleWebServer.Click += new System.EventHandler(this.btnToggleWebServer_Click);
            // 
            // onOffPanel
            // 
            this.onOffPanel.Location = new System.Drawing.Point(304, 9);
            this.onOffPanel.Name = "onOffPanel";
            this.onOffPanel.Size = new System.Drawing.Size(20, 20);
            this.onOffPanel.TabIndex = 1;
            this.onOffPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.onOffPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(167, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Web Server Status:";
            // 
            // labl2
            // 
            this.labl2.AutoSize = true;
            this.labl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labl2.Location = new System.Drawing.Point(150, 43);
            this.labl2.Name = "labl2";
            this.labl2.Size = new System.Drawing.Size(148, 17);
            this.labl2.TabIndex = 4;
            this.labl2.Text = "Flight Sim Connection:";
            // 
            // flightSimConnectionCircle
            // 
            this.flightSimConnectionCircle.Location = new System.Drawing.Point(304, 40);
            this.flightSimConnectionCircle.Name = "flightSimConnectionCircle";
            this.flightSimConnectionCircle.Size = new System.Drawing.Size(20, 20);
            this.flightSimConnectionCircle.TabIndex = 3;
            this.flightSimConnectionCircle.Paint += new System.Windows.Forms.PaintEventHandler(this.flightSimConnectionCircle_Paint);
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.latitudeLabel.Location = new System.Drawing.Point(9, 133);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(63, 17);
            this.latitudeLabel.TabIndex = 5;
            this.latitudeLabel.Text = "Latitude:";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.longitudeLabel.Location = new System.Drawing.Point(9, 160);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(75, 17);
            this.longitudeLabel.TabIndex = 6;
            this.longitudeLabel.Text = "Longitude:";
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.altitudeLabel.Location = new System.Drawing.Point(9, 190);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(59, 17);
            this.altitudeLabel.TabIndex = 7;
            this.altitudeLabel.Text = "Altitude:";
            // 
            // AirSpeedLabel
            // 
            this.AirSpeedLabel.AutoSize = true;
            this.AirSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AirSpeedLabel.Location = new System.Drawing.Point(9, 219);
            this.AirSpeedLabel.Name = "AirSpeedLabel";
            this.AirSpeedLabel.Size = new System.Drawing.Size(78, 17);
            this.AirSpeedLabel.TabIndex = 8;
            this.AirSpeedLabel.Text = "Air Speed: ";
            // 
            // btnStartTracking
            // 
            this.btnStartTracking.Location = new System.Drawing.Point(12, 68);
            this.btnStartTracking.Name = "btnStartTracking";
            this.btnStartTracking.Size = new System.Drawing.Size(122, 50);
            this.btnStartTracking.TabIndex = 9;
            this.btnStartTracking.Text = "Start Tracking";
            this.btnStartTracking.UseVisualStyleBackColor = true;
            this.btnStartTracking.Click += new System.EventHandler(this.btnStartTracking_Click);
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.headingLabel.Location = new System.Drawing.Point(9, 245);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(134, 17);
            this.headingLabel.TabIndex = 10;
            this.headingLabel.Text = "Magnetic Heading:  ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 286);
            this.Controls.Add(this.headingLabel);
            this.Controls.Add(this.btnStartTracking);
            this.Controls.Add(this.AirSpeedLabel);
            this.Controls.Add(this.altitudeLabel);
            this.Controls.Add(this.longitudeLabel);
            this.Controls.Add(this.latitudeLabel);
            this.Controls.Add(this.labl2);
            this.Controls.Add(this.flightSimConnectionCircle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onOffPanel);
            this.Controls.Add(this.btnToggleWebServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 325);
            this.MinimumSize = new System.Drawing.Size(350, 325);
            this.Name = "MainForm";
            this.Text = "Flight Sim Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggleWebServer;
        private System.Windows.Forms.Panel onOffPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labl2;
        private System.Windows.Forms.Panel flightSimConnectionCircle;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.Label AirSpeedLabel;
        private System.Windows.Forms.Button btnStartTracking;
        private System.Windows.Forms.Label headingLabel;
    }
}

