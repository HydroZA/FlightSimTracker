namespace FlightSimTracker
{
    partial class SimSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimSelection));
            this.DCS = new System.Windows.Forms.PictureBox();
            this.MSFS = new System.Windows.Forms.PictureBox();
            this.Xplane = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSFS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xplane)).BeginInit();
            this.SuspendLayout();
            // 
            // DCS
            // 
            this.DCS.Image = ((System.Drawing.Image)(resources.GetObject("DCS.Image")));
            this.DCS.Location = new System.Drawing.Point(12, 12);
            this.DCS.Name = "DCS";
            this.DCS.Size = new System.Drawing.Size(131, 177);
            this.DCS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DCS.TabIndex = 0;
            this.DCS.TabStop = false;
            this.DCS.Click += new System.EventHandler(this.DCS_Click);
            // 
            // MSFS
            // 
            this.MSFS.Image = ((System.Drawing.Image)(resources.GetObject("MSFS.Image")));
            this.MSFS.Location = new System.Drawing.Point(149, 12);
            this.MSFS.Name = "MSFS";
            this.MSFS.Size = new System.Drawing.Size(131, 177);
            this.MSFS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MSFS.TabIndex = 1;
            this.MSFS.TabStop = false;
            this.MSFS.Click += new System.EventHandler(this.MSFS_Click);
            // 
            // Xplane
            // 
            this.Xplane.Image = ((System.Drawing.Image)(resources.GetObject("Xplane.Image")));
            this.Xplane.Location = new System.Drawing.Point(286, 12);
            this.Xplane.Name = "Xplane";
            this.Xplane.Size = new System.Drawing.Size(131, 177);
            this.Xplane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xplane.TabIndex = 2;
            this.Xplane.TabStop = false;
            this.Xplane.Click += new System.EventHandler(this.Xplane_Click);
            // 
            // SimSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 202);
            this.Controls.Add(this.Xplane);
            this.Controls.Add(this.MSFS);
            this.Controls.Add(this.DCS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(446, 241);
            this.MinimumSize = new System.Drawing.Size(446, 241);
            this.Name = "SimSelection";
            this.Text = "Select Simulator";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSFS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xplane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DCS;
        private System.Windows.Forms.PictureBox MSFS;
        private System.Windows.Forms.PictureBox Xplane;
    }
}