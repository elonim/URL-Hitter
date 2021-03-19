using System;
using System.IO;
using System.Windows.Forms;
using URL_Hitter.Hitclass;
using URL_Hitter.Singleton;

namespace URL_Hitter
{
    public partial class Hitter : Form
    {
        readonly ConfigSingleton filelocation = ConfigSingleton.GetConfigInstance(); //initialize singelton 

        public Hitter()
        {
            InitializeComponent();

            string filePath = filelocation.ConfigLocation(); //get config file location from singelton

            if (File.Exists(filePath))
            {
                var a = HitClass.ReadConfig<HitClass>(filePath);
                Run(a.url, a.time, a.timeType, a.showOutput);

                var timer = new Timer();
                timer.Tick += new EventHandler(TimerTick);
                timer.Interval = TimeInterval(a.time,a.timeType); // set interval between hits in milliseconds
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
        private void TimerTick(object sender, EventArgs e)
        {
            string filePath = filelocation.ConfigLocation(); //get config file location from singelton

            var a = HitClass.ReadConfig<HitClass>(filePath);
            Run(a.url, a.time, a.timeType, a.showOutput);
        }

        public void Run(string url, int time, string timeType, bool showOutput)
        {
            int hitTime = TimeInterval(time, timeType);
            output.Text = HitClass.Hit(url, hitTime, showOutput);//hit and show the output in the textbox

        }
        #endregion

        public int TimeInterval(int time, string intervalType)  //set the time between hits at the URL
        {
            int result;
            if (intervalType == "Hours") //get milliseconds in hours
            {
                result = 3600000 * time;
                return result;
            }
            else if (intervalType == "Minutes") //Get milliseconds in minutes
            {
                result = 60000 * time;
                return result;
            }
            else if (intervalType == "Seconds") // get milliseconds in seconds
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
