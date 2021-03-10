using System;
using System.IO;
using System.Windows.Forms;


namespace URL_Hitter
{
    public partial class Hitter : Form
    {

        static readonly HitClass config = new HitClass();
        static readonly string FILEPATH = config.FILE;

        public Hitter()
        {
            InitializeComponent();
            if (File.Exists(FILEPATH))
            {
                HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
                Run(a.url, a.time, a.timeType, a.showOutput);
                Timer timer = new Timer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = TimeInterval(a.time,a.timeType); // in miliseconds
                timer.Start();
            }
            else
            {
                panel1.Controls.Clear();//open settings if no Configuration file is found
                Settings frm = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
        }
        #region Hit timer and run
        private void Timer_Tick(object sender, EventArgs e)
        {
            HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
            Run(a.url, a.time, a.timeType, a.showOutput);
        }

        public void Run(string url, int time, string timeType, bool showOutput)
        {
            int hitTime = TimeInterval(time,timeType);
            output.Text = HitClass.Hit(url, hitTime, showOutput);

        }
        #endregion

        public int TimeInterval(int time, string intervalType)
        {
            int result;
            if(intervalType=="Hours") //get milliseconds in hours
            {
                result = 3600000 * time;
                return result;
            }
            else if(intervalType=="Minutes") //Get milliseconds in minutes
            {
                result = 60000 * time;
                return result;
            }
            else if(intervalType=="Seconds") // get milliseconds in seconds
            {
                result = 1000 * time;
                return result;
            }
            else
            {
                result = 86400000; //default 24 hours if the user have enteres something else
                return result;
            }
            
        }
    }
}
