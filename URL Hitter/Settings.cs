using System;
using System.IO;
using System.Windows.Forms;
using URL_Hitter.Hitclass;
using URL_Hitter.Singleton;
using System.Diagnostics;

namespace URL_Hitter
{
    public partial class Settings : Form
    {
        readonly ConfigSingleton filelocation = ConfigSingleton.GetConfigInstance(); //initialize singelton 

        public Settings()
        {
            InitializeComponent();
            string filePath = filelocation.ConfigLocation(); //get config file location from singelton

            if (File.Exists(filePath)) //if Config.xml exist, fill read content to object and fill boxes
            {
                var a = HitClass.ReadConfig<HitClass>(filePath);
                urlBox.Text = a.url;
                timeBox.Text = Convert.ToString(a.time);
                timeType.Text = a.timeType;
                outputBox.Checked = a.showOutput;
            }
        }

        private void Save_Click(object sender, EventArgs e)//save settings to file
        {
            SaveClick();
        }

        private void SaveClick()
        {
            string filePath = filelocation.ConfigLocation(); //get config file location from singelton

            if (urlBox.Text == "" || timeBox.SelectedItem == null || timeType.SelectedItem == null)
            {
                MessageBox.Show(text: "Input missing\nURL, and time needs to be filled out",
                                caption: "Error",
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    var c = new HitClass(urlBox.Text, Convert.ToInt32(timeBox.Text), timeType.Text, outputBox.Checked);
                    HitClass.SaveConfig(filePath, c);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void TestURL_Click(object sender, EventArgs e)
        {
            TestURL(urlBox.Text);
        }

        private void TestURL(string URL)
        {
            Process.Start(URL);
        }
    }
}
