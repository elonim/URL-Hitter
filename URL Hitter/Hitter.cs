using System;
using System.IO;
using System.Windows.Forms;

namespace URL_Hitter
{
    public partial class Hitter : Form
    {
        static string FILEPATH = "Config.xml";
        public Hitter()
        {
            InitializeComponent();
            if (File.Exists(FILEPATH))
            {
                HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
                if (a.autoStart)
                {
                    output.Text = HitClass.Hit(a.url);
                }
            }
            else
            {
                panel1.Controls.Clear();//open settings if no Config.xml is found
                Settings frm = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
        }
        public Hitter(string start)
        {
            InitializeComponent();
           
            if (File.Exists(FILEPATH))
            {

                HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
                output.Text = HitClass.Hit(a.url);

            }
        }
    }
}
