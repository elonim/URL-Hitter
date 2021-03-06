using System;
using System.IO;
using System.Threading;
using System.Timers;
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
                    Run(a.url);
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Interval = 3600000 * a.time; // in miliseconds
                    timer.Start();
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
            HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
            if (File.Exists(FILEPATH))
            {

                Run(a.url);
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = 3600000 * a.time; // in miliseconds
                timer.Start();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
            Run(a.url);
        }

        public void Run(string url)
        {
            output.Text = HitClass.Hit(url);
         
            
            

        }
    }
}
