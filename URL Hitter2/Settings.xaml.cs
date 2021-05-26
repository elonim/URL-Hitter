using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace URL_Hitter2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            if (File.Exists(HitClass.Filepath)) //if Config.xml exist, fill read content to object and fill boxes
            {
                var a = HitClass.ReadConfig<HitClass>(HitClass.Filepath);
                URL.Text = a.url;
                Timebox.Text = Convert.ToString(a.time);
                Timetype.Text = a.timeType;
                ShowOutput.IsChecked = a.showOutput;
            }
        }


        private void Save(object sender, RoutedEventArgs e)
        {
            if (URL.Text == "" || Timebox.SelectedItem == null || Timetype.SelectedItem == null)
            {
                MessageBox.Show("Input missing\nURL, and time needs to be filled out",
                                caption: "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    var c = new HitClass(URL.Text, Convert.ToInt32(Timebox.Text), Timetype.Text, (bool)ShowOutput.IsChecked);
                    HitClass.SaveConfig(HitClass.Filepath, c);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        private void Open_URL(object sender, RoutedEventArgs e)
        {
            var url = URL.Text;
            HitClass.TestURL(url);
        }
    }
}
