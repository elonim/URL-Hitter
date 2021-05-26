using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace URL_Hitter2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Hitter();
        }


        private void Menu_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Settings();
        }

        private void Click_Hitter(object sender, RoutedEventArgs e)
        {
            Main.Content = new Hitter();
        }
    }
}
