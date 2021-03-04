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


        private void hitter_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            Hitter frm = new Hitter() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            Settings frm = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void start_Click(object sender, EventArgs e)
        {
            string start = "start";  //used to start manual if autostart is disabled
            panelContainer.Controls.Clear();
            Hitter frm = new Hitter(start) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelContainer.Controls.Add(frm);
            frm.Show();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
