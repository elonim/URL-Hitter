using System;
using System.Windows.Forms;

namespace URL_Hitter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            panelContainer.Controls.Clear();
            Hitter frm = new Hitter() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();
        }
        private void Hitter_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            Hitter frm = new Hitter() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            Settings frm = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();
        }



        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
