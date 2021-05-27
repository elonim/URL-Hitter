using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace URL_Hitter2
{
    /// <summary>
    /// Interaction logic for Hitter.xaml
    /// </summary>
    public partial class Hitter : Page
    {

        public Hitter()
        {
            InitializeComponent();
            if (File.Exists(HitClass.Filepath))
            {
                var a = HitClass.ReadConfig<HitClass>(HitClass.Filepath);
                Task.Run(() => HitTask(a));
            }

            else
            {
                Output.Selection.Text = "\nNo Configuration found! \n" +
                                        "\tOpen Settings to Configure this application.";
            }
        }


        public delegate void Del(string a);

        public void HitTask(HitClass a)
        {
            var hitTime = HitClass.TimeInterval(a.time, a.timeType);
            while (true)
            {
                var result = HitClass.Hit(a.url, hitTime, a.showOutput);//hit and show the output in the textbox

                UpdateView(result);
                Thread.Sleep(hitTime);
            }
        }
        void UpdateView(string ansat)
        {
            Del ddg = new(ShowView);
            Dispatcher.Invoke(ddg, new object[] { ansat });
        }
        void ShowView(string a)
        {
            Output.Selection.Text = a;
        }
    }
}
