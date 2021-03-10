using System;
using System.IO;
using System.Windows.Forms;

namespace URL_Hitter
{
    public partial class Settings : Form
    {
        static readonly HitClass config = new HitClass();
        static readonly string FILEPATH = config.FILE;


        public Settings()
        {
            InitializeComponent();

            if (File.Exists(FILEPATH)) //if Config.xml exist, fill read content to object and fill boxes
            {
                HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
                urlBox.Text = a.url;
                timeBox.Text = Convert.ToString(a.time);
                timeType.Text = a.timeType;
                outputBox.Checked = a.showOutput;
            }
        }

        private void Save_Click(object sender, EventArgs e)//save settings to file
        {
            if (urlBox.Text==""||timeBox.SelectedItem==null||timeType.SelectedItem==null)
            {
                MessageBox.Show("Input missing\nURL, and time needs to be filled out","Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    var c = new HitClass(urlBox.Text, Convert.ToInt32(timeBox.Text), timeType.Text, outputBox.Checked);
                    HitClass.SaveConfig(FILEPATH, c);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            
        }
    }
}
