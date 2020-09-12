﻿using System;
using System.Windows.Forms;

namespace FlightSimTracker
{
    public partial class SimSelection : Form
    {
        private Game g;

        public SimSelection()
        {
            InitializeComponent();
        }

        private void DCS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
            //    g = Game.DCS;
            //   new MainForm(g).Show();
            //   Hide();
        }

        private void MSFS_Click(object sender, EventArgs e)
        {
            g = Game.MSFS;
            new MainForm(g).Show();
            Hide();
        }

        private void Xplane_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
            //g = Game.XPLANE;
            //new MainForm(g).Show();
            //Hide();
        }

        public Game GetGame()
        {
            return g;
        }
    }
}
