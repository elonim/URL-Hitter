using System;
using System.Windows.Forms;
using System.IO;

namespace URL_Hitter
{
    public partial class Settings : Form
    {
        static string FILEPATH = "Config.xml";


        public Settings()
        {
            InitializeComponent();

            if (File.Exists(FILEPATH)) //if Config.xml exist, fill read content to object and fill boxes
            {
                HitClass a = HitClass.ReadConfig<HitClass>(FILEPATH);
                urlBox.Text = a.url;
                timeBox.Text = Convert.ToString(a.time);
                autoStart.Checked = a.autoStart;
                outputBox.Checked = a.showOutput;
                
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new HitClass(urlBox.Text, Convert.ToInt32(timeBox.Text), autoStart.Checked, autoStart.Checked);
                HitClass.SaveConfig(FILEPATH, c);
            }
            catch (Exception)
            {

                throw;
            }


        }



    }
}
